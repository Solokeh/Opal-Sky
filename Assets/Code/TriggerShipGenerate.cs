using UnityEngine;

public class TriggerShipGenerate : MonoBehaviour {
    public GameObject alienPrefab, holderPrefab, platformPrefab, blockPrefab, pointPrefab;
    public int minSizeX = 10, maxSizeX = 100, minSizeY = 10, maxSizeY = 100;
    public float minIncrementX = 0.05f, maxIncrementX = 0.2f;
    public float minIncrementY = 0.05f, maxIncrementY = 0.2f;
    [Range(0f, 1f)]
    public float minThreshold = 0.4f;
    [Range(0f, 1f)]
    public float maxThreshold = 0.6f;
    [Tooltip("The lower, the higher the change for spawn.")]
    public int minEnemySpawnRate = 10;
    [Tooltip("The lower, the higher the change for spawn.")]
    public int maxEnemySpawnRate = 20;
    [Tooltip("The lower, the higher the change for spawn.")]
    public int minExitSpawnRate = 20;
    [Tooltip("The lower, the higher the change for spawn.")]
    public int maxExitSpawnRate = 50;

    private int sizeX, sizeY, enemySpawnRate, exitSpawnRate;
    private float incrementX, incrementY, threshold;

    private void Start() {
        sizeX = Random.Range(minSizeX, maxSizeX);
        sizeY = Random.Range(minSizeY, maxSizeY);
        incrementX = Random.Range(minIncrementX, maxIncrementX);
        incrementY = Random.Range(minIncrementY, maxIncrementY);
        threshold = Random.Range(minThreshold, maxThreshold);
        enemySpawnRate = Random.Range(minEnemySpawnRate, maxEnemySpawnRate);
        exitSpawnRate = Random.Range(minExitSpawnRate, maxExitSpawnRate);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if ((collision.CompareTag("Player")) && (Input.GetButtonDown("Interact"))) {
            ShipGenerator.Generate(collision.transform, alienPrefab, holderPrefab, platformPrefab, blockPrefab, pointPrefab, sizeX, sizeY, incrementX, incrementY, threshold, enemySpawnRate, exitSpawnRate);
        }
    }
}
