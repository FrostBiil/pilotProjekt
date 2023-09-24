using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDown : MonoBehaviour
{
    [SerializeField]
    private float speed = 500.0f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        
    }
}
