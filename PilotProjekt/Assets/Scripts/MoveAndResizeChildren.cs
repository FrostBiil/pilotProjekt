using UnityEngine;

public class MoveAndResizeChildren : MonoBehaviour
{
    public float childWidth = 10.0f;
    public int trackCount = 5;
    public GameObject childPrefab;

    void Start()
    {
        // Convert the screen's top left corner to world coordinates
        Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(childWidth / 2, Screen.height, 0));

        // Set the GameObject's position to the adjusted top-left corner
        transform.position = new Vector3(topLeft.x, topLeft.y, transform.position.z);

        // Create, resize, and align child objects
        float xOffset = 0;
        for (int i = 0; i < trackCount; i++)
        {
            GameObject child = Instantiate(childPrefab, transform);
            child.transform.localScale = new Vector3(childWidth, child.transform.localScale.y, child.transform.localScale.z);
            child.transform.position = new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z);
            xOffset += childWidth;
        }
    }
}