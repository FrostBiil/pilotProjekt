using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeManager : MonoBehaviour
{
    [SerializeField] private GameObject currentTrack;
    [SerializeField] private GameObject tracksObject;
    public List<GameObject> tracks = new List<GameObject>();
    
    private int _trackNumber;
    public int TrackNumber
    {
        get
        {
            return this._trackNumber;
        }
        set
        {
            if (value < 0)
            {
                this._trackNumber = 0;
            }
            else if (value >= tracks.Count)
            {
                this._trackNumber = tracks.Count - 1;
            }
            else
            {
                this._trackNumber = value;
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
}
