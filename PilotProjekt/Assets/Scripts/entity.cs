using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class entity : MonoBehaviour
{
    public bool isHarmful = false;
    //public CircleCollider2D cC;
    [SerializeField] private Vector2 _vel = new Vector2(0, 1);
    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] private List<string> _posList = new List<string> { "left", "center", "right" };
    //[SerializeField] private string[] _pos;

    private void Start()
    {
        rb.velocity = _vel;
    }

    private void Update()
    {
        //rb.velocity = _vel;   
    }

    /*private void OnTriggerEnter(Collider other)
    {
        
    }*/


    public void Die()
    {
        Destroy(gameObject);
    }

}
