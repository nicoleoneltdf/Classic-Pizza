using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject anana;
    public Vector2 segundosEntreSpawnMinMax ;
    float nextSpawnTime;

    Vector2 screenHalfSizeWorldUnits;
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float segundosEntreSpawn = Mathf.Lerp(segundosEntreSpawnMinMax.y, segundosEntreSpawnMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + segundosEntreSpawn;
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y);
            Instantiate(anana, spawnPosition, Quaternion.identity);
        }
    }
}
