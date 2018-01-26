﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSetter : MonoBehaviour {
    public GameObject platformPrefab;
    public int sizeX = 10, sizeY = 10;
    public float incrementX = 0.1f, incrementY = 0.1f;
    [Range(0f, 1f)]
    public float threshold = 0.5f;

    public void Awake() {
        ShipGenerator.Generate(platformPrefab, sizeX, sizeY, incrementX, incrementY, threshold);
    }
}