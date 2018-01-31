using UnityEngine;

public abstract class ShipGenerator : MonoBehaviour {
    public enum Tile { Free, Platform, Block, Enemy, Entry, Exit };

    private static GameObject shipHolder;
    public static GameObject exit;

    public static void SetExitPrefab(GameObject exitPrefab) {
        exit = exitPrefab;
    }

    public static void Generate(Transform player, GameObject alienPrefab, GameObject holderPrefab, GameObject platformPrefab, GameObject blockPrefab, int sizeX, int sizeY, float incrementX = 0.1f, float incrementY = 0.1f, float threshold = 0.5f) {
        if (shipHolder) {
            Destroy(shipHolder);
        }
        shipHolder = Instantiate(holderPrefab);
        Tile[,] ship = new Tile[sizeX, sizeY];
        float x = Random.Range(-99999f, 99999f), y = Random.Range(-99999f, 99999f);
        float offsetX = 0f, offsetY = 0f;
        for (int iY = 0; iY < (sizeY - 5); iY++, offsetY += incrementY, offsetX = 0f) {
            for (int iX = 0; iX < sizeX; iX++, offsetX += incrementX) {
                float randomNum = Mathf.PerlinNoise(x + offsetX, y + offsetY);
                if (randomNum > threshold) {
                    ship[iX, iY] = Tile.Platform;
                } else {
                    ship[iX, iY] = Tile.Free;
                }
            }
        }
        bool entryPlaced = false;
        for (int iX = 0; iX < sizeX; iX++) {
            for (int iY = (sizeY - 6); iY >= 0; iY--) {
                if (ship[iX, iY] == Tile.Platform) {
                    if (iY == 0) {
                        ship[iX, iY] = Tile.Block;
                    } else {
                        if ((iY + 1) < sizeY) {
                            if (!entryPlaced) {
                                ship[iX, iY + 1] = Tile.Entry;
                                entryPlaced = true;
                            }
                            if (Random.Range(0, 20) == 0) {
                                ship[iX, iY + 1] = Tile.Exit;
                            } else if (Random.Range(0, 20) == 0) {
                                ship[iX, iY + 1] = Tile.Enemy;
                            }
                        }
                        if (Random.Range(0, 5) == 0) {
                            for (int iY2 = (iY - 1); iY2 >= 0; iY2--) {
                                if (ship[iX, iY2] == Tile.Free) {
                                    break;
                                } else {
                                    ship[iX, iY2] = Tile.Free;
                                }
                            }
                        } else {
                            for (int iY2 = iY; iY2 >= 0; iY2--) {
                                if (ship[iX, iY2] == Tile.Free) {
                                    break;
                                } else {
                                    ship[iX, iY2] = Tile.Block;
                                }
                            }
                        }
                    }
                }
            }
        }
        BoxCollider2D col = platformPrefab.GetComponent<BoxCollider2D>();
        float platformSizeX = col.size.x;
        //float platformSizeY = col.size.y;
        Vector2 pos = Vector2.zero;
        for (int iY = 0; iY < sizeY; iY++, pos.y++, pos.x = 0f) {
            for (int iX = 0; iX < sizeX; iX++, pos.x += platformSizeX) {
                Tile tile = ship[iX, iY];
                if (tile == Tile.Platform) {
                    CreatePlatform(platformPrefab, new Vector2(pos.x, pos.y + 1.32f), shipHolder.transform);
                } else if (tile == Tile.Block) {
                    int blockSizeY = 1;
                    for (int i = (iY + 1); i < sizeY; i++) {
                        if (ship[iX, i] == Tile.Block) {
                            blockSizeY++;
                            ship[iX, i] = Tile.Free;
                        } else {
                            break;
                        }
                    }
                    CreateBlock(blockPrefab, new Vector2(pos.x, pos.y + (blockSizeY / 2f) + 0.5f), new Vector2(platformSizeX, blockSizeY), shipHolder.transform);
                } else if (tile == Tile.Enemy) {
                    CreateAlien(alienPrefab, pos, shipHolder.transform);
                } else if (tile == Tile.Exit) {
                    CreateExit(exit, new Vector2(pos.x, pos.y + 1f), shipHolder.transform);
                } else if (tile == Tile.Entry) {
                    PlacePlayer(player, pos);
                }
            }
        }
        pos = Vector2.zero;
        for (int iY = 0; iY < 2; iY++, pos.y += sizeY) {
            CreateBlock(blockPrefab, new Vector2(((sizeX * platformSizeX) / 2f) - (platformSizeX / 2f), pos.y), new Vector2(sizeX * platformSizeX, 1f), shipHolder.transform);
        }
        pos = new Vector2(-0.5f - (platformSizeX / 2f), -1f);
        for (int iX = 0; iX < 2; iX++, pos.x += (sizeX * platformSizeX) + 1f) {
            CreateBlock(blockPrefab, new Vector2(pos.x, sizeY / 2f), new Vector2(1f, sizeY + 1f), shipHolder.transform);
        }
    }

    private static void CreatePlatform(GameObject platformPrefab, Vector2 pos, Transform parent) {
        Instantiate(platformPrefab, pos, Quaternion.identity, parent);
    }

    private static void CreateBlock(GameObject blockPrefab, Vector2 pos, Vector2 size, Transform parent) {
        GameObject block = Instantiate(blockPrefab, pos, Quaternion.identity, parent);
        block.GetComponent<SpriteRenderer>().size = size;
    }

    private static void PlacePlayer(Transform player, Vector2 pos) {
        pos.y += (player.GetComponent<CapsuleCollider2D>().size.y);
        player.position = pos;
    }

    private static void CreateExit(GameObject exit, Vector2 pos, Transform parent) {
        Instantiate(exit, pos, Quaternion.identity, parent);
    }

    private static void CreateAlien(GameObject alien, Vector2 pos, Transform parent) {
        Instantiate(alien, pos, Quaternion.identity, parent);
    }
}
