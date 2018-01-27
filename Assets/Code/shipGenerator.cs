using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipGenerator : MonoBehaviour {
    public enum Tile { Free, Platform, Entry };

    public static void Generate(Transform player, GameObject platformPrefab, int sizeX, int sizeY, float incrementX = 0.1f, float incrementY = 0.1f, float threshold = 0.5f) {
        GameObject shipHolder = new GameObject("Ship");
        Tile[,] ship = new Tile[sizeX, sizeY];
        float x = Random.Range(-99999f, 99999f), y = Random.Range(-99999f, 99999f);
        float offsetX = 0f, offsetY = 0f;
        for (int iY = 0; iY < sizeY; iY++, offsetY += incrementY, offsetX = 0f) {
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
            for (int iY = (sizeY - 1); iY >= 0; iY--) {
                if (ship[iX, iY] == Tile.Platform) {
                    if ((!entryPlaced) && ((iY + 1) < sizeY)) {
                        ship[iX, iY + 1] = Tile.Entry;
                        entryPlaced = true;
                    }
                    for (int iY2 = (iY - 1); iY2 >= 0; iY2--) {
                        if (ship[iX, iY2] == Tile.Free) {
                            break;
                        } else {
                            ship[iX, iY2] = Tile.Free;
                        }
                    }
                }
            }
        }
        BoxCollider2D col = platformPrefab.GetComponent<BoxCollider2D>();
        float platformSizeX = col.size.x;
        float platformSizeY = col.size.y;
        Vector2 pos = Vector2.zero;
        for (int iY = 0; iY < sizeY; iY++, pos.y += platformSizeY, pos.x = 0f) {
            for (int iX = 0; iX < sizeX; iX++, pos.x += platformSizeX) {
                Tile tile = ship[iX, iY];
                if (tile == Tile.Platform) {
                    CreatePlatform(platformPrefab, pos, shipHolder.transform);
                } else if (tile == Tile.Entry) {
                    PlacePlayer(player, pos);
                }
            }
        }
    }

    private static void CreatePlatform(GameObject platformPrefab, Vector2 pos, Transform parent) {
        Instantiate(platformPrefab, pos, Quaternion.identity, parent);
    }

    private static void PlacePlayer(Transform player, Vector2 pos) {
        pos.y += player.GetComponent<CapsuleCollider2D>().size.y;
        player.position = pos;
    }
}
