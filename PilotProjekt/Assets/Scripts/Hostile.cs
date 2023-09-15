using UnityEngine;

public class Hostile : MonoBehaviour
{
    public float fallSpeed = 2f; // Speed at which the object falls
    public string playerTag = "Player"; // Tag of the player GameObject
    public pointManager pm;

    private bool isFalling = true;

    private void Update()
    {
        if (isFalling)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        }

        if (transform.position.y <= -5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == playerTag)
        {
            Debug.Log("GAMEOVER! You got a score of: " + pm.safePoints + " Points!");
            Destroy(gameObject);
            Time.timeScale = 0.0f;
        }
    }
}
