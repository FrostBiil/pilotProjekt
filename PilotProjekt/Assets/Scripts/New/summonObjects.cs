using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonObjects : MonoBehaviour
{
    private float summonRate = 5f;
    private float lastSummonTime = 0f;
    private int RandWeight(float[] weights)
    {
        // Get the total sum of all the weights.
        float weightSum = 0f;
        for (int i = 0; i < weights.Length; ++i)
        {
            weightSum += weights[i];
        }

        // Step through all the possibilities, one by one, checking to see if each one is selected.
        int index = 0;
        int lastIndex = weights.Length - 1;
        while (index < lastIndex)
        {
            // Do a probability check with a likelihood of weights[index] / weightSum.
            if (Random.Range(0, weightSum) < weights[index])
            {
                return index;
            }

            // Remove the last item from the sum of total untested weights and try again.
            weightSum -= weights[index++];
        }

        // No other item was selected, so return very last index.
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
                s.Summon(chooseObject());
            }
        }
    }

    private void chooseObject()
    {
        int i = RandWeight(weights);

        return objects[i];
    }

}

