using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summoner : MonoBehaviour
{
    public float
        lastSummonTime = 0,
        summonRate = Random.Range(1, 5);
    
    void Awake()
    {
        lastSummonTime = Time.time;
    }



    public void Summon(GameObject thingy)
    {
        lastSummonTime = Time.time;
        summonRate = Random.Range(1, 5);

        GameObject newPrefabInstance = Instantiate(thingy, transform.position, Quaternion.identity);

        // Make the new instance a child of this GameObject
        newPrefabInstance.transform.parent = transform;
    }

    
}
