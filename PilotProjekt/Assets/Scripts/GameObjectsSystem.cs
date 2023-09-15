using System.Collections;
using UnityEngine;

public class GameObjectSystem : MonoBehaviour
{
    public ObjectsDatabaseSO objectsDatabase; // Reference to your ObjectsDatabaseSO
    public float fallSpeed = 5f; // Speed at which objects fall
    public LayerMask collisionLayer; // Layer to check for collisions
    public float spawnInterval = 3f; // Time interval between spawns
    public pointManager pm; // Reference to your pointManager script

    public Transform parentTransform; // Reference to the parent transform


    private Vector3[] spawnLocations; // Array of spawn locations

    private void Start()
    {
        // Define spawn locations
        spawnLocations = new Vector3[]
        {
            new Vector3(0f, 5f, 0f),
            new Vector3(-1.7f, 5f, 0f),
            new Vector3(1.7f, 5f, 0f)
        };

        // Start spawning objects at intervals
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Check how many lanes are currently occupied
            int occupiedLanes = 0;
            foreach (Vector3 location in spawnLocations)
            {
                Collider[] colliders = Physics.OverlapSphere(location, 0.5f, collisionLayer);
                if (colliders.Length > 0)
                {
                    occupiedLanes++;
                }
            }

            // Spawn a collectable object in an unoccupied lane if there are fewer than 2 occupied lanes
            if (occupiedLanes < 2)
            {
                int randomLaneIndex = Random.Range(0, spawnLocations.Length);
                Vector3 spawnPos = spawnLocations[randomLaneIndex];

                // Get a random object prefab from the database
                GameObject selectedPrefab = GetRandomPrefabFromDatabase();

                if (selectedPrefab != null)
                {
                    GameObject spawnedObject = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);

                    // Make the spawned object a child of the specified parent transform
                    if (parentTransform != null)
                    {
                        spawnedObject.transform.SetParent(parentTransform);
                    }
                }
            }


            // Wait for the specified spawn interval before spawning the next object
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private GameObject GetRandomPrefabFromDatabase()
    {
        if (objectsDatabase != null && objectsDatabase.objectsData.Count > 0)
        {
            int randomIndex = Random.Range(0, objectsDatabase.objectsData.Count);
            return objectsDatabase.objectsData[randomIndex].Prefab;
        }

        return null;
    }

    private void FallObject(GameObject obj)
    {
        StartCoroutine(FallCoroutine(obj));
    }

    private IEnumerator FallCoroutine(GameObject obj)
    {
        while (obj != null && obj.activeSelf && obj.transform.position.y > -5f)
        {
            obj.transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
            yield return null;
        }

        if (obj != null && obj.activeSelf)
        {
            Destroy(obj); // Destroy the object after it reaches the bottom
        }
    }
}
