using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject currentTrack, tracksObject, player;
    public List<GameObject> tracks = new List<GameObject>();
    
    private int trackNumber;

    private float switchSpeed = 1000.0f;

    public int TrackNumber
    {
        get
        {
            return this.trackNumber;
        }
        set
        {
            if (value < 0)
            {
                this.trackNumber = 0;
            }
            else if (value >= tracks.Count)
            {
                this.trackNumber = tracks.Count - 1;
            }
            else
            {
                this.trackNumber = value;
            }
        }
    }

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private void Awake()
    {
        foreach (Transform track in tracksObject.transform)
        {
            // Add each child to the list
            tracks.Add(track.gameObject);
        }
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;



            if (endTouchPosition.x > startTouchPosition.x) // Right swipe
            {
                NextTrack();
            }

            if (endTouchPosition.x < startTouchPosition.x) // Left swipe
            {
                PreviousTrack();
            }
        }
        MovePlayer();
    }

    void NextTrack()
    {
        //Debug.Log("NextTrack");
        TrackNumber++;
        currentTrack = tracks[TrackNumber];
    }

    void PreviousTrack()
    {
        //Debug.Log("PreviousTrack");
        TrackNumber--;
        currentTrack = tracks[TrackNumber];
    }

    void MovePlayer()
    {
        float trackX = currentTrack.transform.position.x, playerX = player.transform.position.x;
        if(playerX != trackX)
        {
            //Debug.Log(rb.velocity = new Vector2(trackX - playerX, 0).normalized * switchSpeed);

            // Calculate the vector
            Vector2 direction = new Vector2(trackX - playerX, 0);

            // Normalize the vector
            Vector2 normalizedVector = direction.normalized;
            Debug.Log("Norm: " + normalizedVector);

            Vector2 mover = new Vector2(normalizedVector.x * switchSpeed, 0);

            player.transform.Translate(mover * Time.deltaTime);
            
            if(playerX >= trackX - switchSpeed * Time.deltaTime && playerX <= trackX + switchSpeed * Time.deltaTime)
            {
                player.transform.position = new Vector2(currentTrack.transform.position.x, player.transform.position.y);
            }
        }

    }
}
