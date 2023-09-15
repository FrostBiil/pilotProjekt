using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundUIGenerator : MonoBehaviour
{
    public ObjectsDatabaseSO objectsDatabase;
    public float fallSpeed = 5f; // Speed at which objects fall
    public float spawnInterval = 3f; // Time interval between spawns

    public Transform parentTransform; // Reference to the parent transform

    private Vector3[] spawnLocations; // Array of spawn locations

    private void Start()
    {
        for (int i = 0; i < spawnLocations.Length; i++)
        {
            //objectsDatabase.objectsData[i].Position;
        }
    }

    private void Update()
    {
        
    }

}
