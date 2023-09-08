using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    [Header("Track Settings")]
    [SerializeField] private Vector2 _pos = new Vector2(0, 1);
    [SerializeField] public int width;
    [SerializeField] private int count;

    private GameObject canvas;

    [Header("Prefabs to Spawn")]
    [SerializeField] public GameObject obs_placeholder;
    [SerializeField] public GameObject col1_placeholder;
    [SerializeField] public GameObject col2_placeholder;

    private float spawnInterval = 1.0f;
    private float nextSpawnTime;
    private int spawnCounter = 0;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        Debug.Log("Track Spawner Initialized");
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        // Scale the track
        float windowHeight = Screen.height;
        float windowWidth = Screen.width;
        transform.localScale = new Vector3(windowWidth / count, windowHeight * 1.2f, 1);

        // Spawn prefabs based on time
        if (Time.time >= nextSpawnTime)
        {
            spawnCounter++;
            if (spawnCounter % 4 == 0)
            {
                GameObject newObject = Instantiate(col2_placeholder, transform.position, Quaternion.identity);
                newObject.transform.SetParent(canvas.transform);
            }
            else
            {
                GameObject newObject = Instantiate(col1_placeholder, transform.position, Quaternion.identity);
                newObject.transform.SetParent(canvas.transform);
            }
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}