using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterCollectable : MonoBehaviour
{
    public bool isHarmful = false;
    [SerializeField] private Vector2 _vel = new Vector2(0, 1);
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject _pM;

    [SerializeField] private int _pointValue = 3;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        _rb.velocity = _vel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered collision with " + collision.gameObject.name);

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Points added: " + _pointValue);
            //pM.add(3);
            Die();
        }

        if (collision.CompareTag("Destroy"))
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
