using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour
{
    private GameObject pMO;
    private pointManager pM;

    void Awake()
    {
        pMO = GameObject.Find("Point Manager");
        pM = pMO.GetComponent<pointManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Lost Game");
        Destroy(gameObject);
    }
}
