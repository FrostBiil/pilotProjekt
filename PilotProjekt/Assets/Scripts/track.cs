using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track : MonoBehaviour
{
    [SerializeField] private Vector2 _pos = new Vector2(0, 1);
    [SerializeField] public int width;
    [SerializeField] private int count;

    private float spawnInterval = 1.0f;
    private float nextSpawnTime;
    private int spawnCounter = 0;

    public GameObject obs_placeholder;
    public GameObject col1_placeholder;
    public GameObject col2_placeholder;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        // Scale the empty GameObject
        float windowHeight = Screen.height;
        float windowWidth = Screen.width;

        transform.localScale = new Vector3(windowWidth / count, windowHeight * 1.2f, 1);

        // Spawn the prefabs
        if (Time.time >= nextSpawnTime)
        {
            spawnCounter++;
            if (spawnCounter % 4 == 0)
            {
                Instantiate(col2_placeholder, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(col1_placeholder, transform.position, Quaternion.identity);
            }
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void generateObstacle()
    {
        Instantiate(obs_placeholder, transform.position, Quaternion.identity);
    }

    private void generateCollitatable()
    {
        // Your existing code for generating a collitatable
    }
}