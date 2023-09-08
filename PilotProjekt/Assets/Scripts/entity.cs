using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class entity : MonoBehaviour
{
    private Vector2 m_Position;
    private Vector2 m_Direction;
    private bool m_isHarmful;
    private int m_Speed;

    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Movement()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        
    }


    private void Die()
    {
        
    }

}
