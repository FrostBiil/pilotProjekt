using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonObjects : MonoBehaviour
{
    private float summonRate = 5f;
    private float lastSummonTime = 0f;
    private int RandWeight(List<float> weights)
    {
        // Get the total sum of all the weights.
        float weightSum = 0f;
        for (int i = 0; i < weights.Count; ++i)
        {
            weightSum += weights[i];
        }


        float randomValue = Random.Range(0, weightSum);

        int index = 0;
        float tmpSum = 0f;
        while (!(tmpSum <= randomValue && (tmpSum + weights[index]) >= randomValue))
        {
            index++;
            tmpSum += weights[index];
        }
        return index;
    }

    private List<GameObject> objects = new List<GameObject>();
    private List<float> weights = new List<float>();

    [SerializeField]
    private GameObject
        allyObject,
        zoneObject,
        enemyObject,
        rationObject,
        waterObject;

    private float
        allyWeight = 1f,
        zoneWeight = 0.2f,
        enemyWeight = 2f,
        rationWeight = 3f,
        waterWeight = 1f;

    public List<GameObject> tracks = new List<GameObject>();

    private GameObject chosenObject()
    {
        int i = RandWeight(weights);
        return objects[i];
    }

    private void Awake()
    {
        /*objects.Add(allyObject, allyWeight);
        objects.Add(zoneObject, zoneWeight);
        objects.Add(enemyObject, enemyWeight);
        objects.Add(rationObject, rationWeight);
        objects.Add(waterObject, waterWeight);
        */

        objects.Add(allyObject);
        objects.Add(zoneObject);
        objects.Add(enemyObject);
        objects.Add(rationObject);
        objects.Add(waterObject);

        weights.Add(allyWeight);
        weights.Add(zoneWeight);
        weights.Add(enemyWeight);
        weights.Add(rationWeight);
        weights.Add(waterWeight);


        foreach (Transform track in transform)
        {
            // Add each child to the list
            tracks.Add(track.gameObject);
        }
    }

    void Update()
    {
        foreach (GameObject track in tracks)
        {
            summoner s = track.GetComponent<summoner>();
            if (s.lastSummonTime + s.summonRate <= Time.time)
            {
                s.Summon(chosenObject());
            }
        }
    }
}

