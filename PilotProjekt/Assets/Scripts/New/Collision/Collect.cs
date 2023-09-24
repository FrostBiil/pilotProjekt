using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private GameObject pMO;
    private pointManager pM;
    [SerializeField] private int value = 1;

    void Awake()
    {
        pMO = GameObject.Find("Point Manager");
        pM = pMO.GetComponent<pointManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        pM.add(value);
        Destroy(gameObject);
    }
}
