using UnityEngine;

public class DropZoneMovement : MonoBehaviour
{
    public float fallSpeed = 2f; // Speed at which the object falls
    public string playerTag = "Player"; // Tag of the player GameObject
    public pointManager pm;

    public int value = 1;

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
            pm.savePoints();

            Destroy(gameObject);
        }
    }
}
