using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class entity : MonoBehaviour
{
    private Vector2 m_vel;
    private bool m_isHarmful;

    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();   
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
