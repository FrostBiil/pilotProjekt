using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] private Transform customPivot;
    [SerializeField] private int speed = 40;
    private void Update()
    {
        transform.RotateAround(customPivot.position, Vector3.forward, speed * Time.deltaTime);
    }
}
