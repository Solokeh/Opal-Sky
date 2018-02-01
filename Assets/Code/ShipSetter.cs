using UnityEngine;

// Only ONE of these should exist!
public class ShipSetter : MonoBehaviour {
    public Transform player;
    public GameObject alienPrefab, holderPrefab, platformPrefab, blockPrefab, exitPrefab, pointPrefab;
    public int sizeX = 10, sizeY = 10;
    public float incrementX = 0.1f, incrementY = 0.1f;
    [Range(0f, 1f)]
    public float threshold = 0.5f;

    private static ShipSetter setter;

    public void Awake() {
        setter = this;
        ShipGenerator.SetExitPrefab(exitPrefab);
        Generate();
    }

    public void Generate() {
        ShipGenerator.Generate(player, alienPrefab, holderPrefab, platformPrefab, blockPrefab, pointPrefab, sizeX, sizeY, incrementX, incrementY, threshold);
    }

    public static void GenerateShip() {
        setter.Generate();
    }
}
