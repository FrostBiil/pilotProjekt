using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class youSpinMeRightRound : MonoBehaviour //https://www.youtube.com/watch?v=PGNiXGX2nLU
{
    public float rotationSpeed = 45.0f; // Adjust this to control the rotation speed.

    private Vector3 pivotOffset;

    void Start()
    {
        // Calculate the initial pivot offset
        pivotOffset = transform.position - transform.parent.position;
    }

    void Update()
    {
        // Rotate the object around its center.
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
