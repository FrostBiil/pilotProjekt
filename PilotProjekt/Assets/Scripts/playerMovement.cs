using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust the speed as needed
    private Vector3 targetPosition = new Vector3(0, -4f, 0);

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;

    private void Update()
    {
        // Calculate the target position with a fixed y-coordinate of -25
        targetPosition = new Vector3(targetPosition.x, -4f, targetPosition.z);

        // Check for swipe gesture on a mobile device
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    touchEndPos = touch.position;
                    float swipeDistance = touchEndPos.x - touchStartPos.x;

                    if (Mathf.Abs(swipeDistance) > 50) // Adjust the threshold as needed
                    {
                        if (swipeDistance > 0)
                        {
                            // Swipe right
                            goRight();
                        }
                        else
                        {
                            // Swipe left
                            goLeft();
                        }
                    }
                    break;
            }
        }

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void goLeft()
    {
        if (transform.position == new Vector3(0, -4f, 0))
        {
            targetPosition = new Vector3(-1.7f, -4, 0);
        }
        else if (transform.position == new Vector3(1.7f, -4, 0))
        {
            targetPosition = new Vector3(0, -4f, 0);
        }
    }

    private void goRight()
    {
        if (transform.position == new Vector3(0, -4f, 0))
        {
            targetPosition = new Vector3(1.7f, -4, 0);
        }
        else if (transform.position == new Vector3(-1.7f, -4, 0))
        {
            targetPosition = new Vector3(0, -4f, 0);
        }
    }
}
