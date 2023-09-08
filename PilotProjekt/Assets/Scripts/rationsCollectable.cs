using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rationsCollectable : MonoBehaviour
{
    public bool isHarmful = false;
    [SerializeField] private Vector2 _vel = new Vector2(0, 1);
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject pM;

    public int pointValue = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = _vel;
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
            Debug.Log("Points added: " + pointValue);
            //pM.add(pointValue);
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
