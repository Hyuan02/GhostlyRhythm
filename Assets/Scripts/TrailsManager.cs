using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrailsManager : MonoBehaviour
{
    public static TrailsManager instance;

    [SerializeField]
    List<Trail> trailsOfGame = new List<Trail>();

    public Trail OccupiedTrail
    {
        get
        {
            return trailsOfGame.Find(e => e.state == TrailState.OCCUPIED); 
        }
    }

    public int trailsLength {
        get
        {
            return trailsOfGame.Count;
        }
    }
        

    private void Awake()
    {
        instance = this;
    }

    public Trail OccupyTrail (int index)
    {
        trailsOfGame.ForEach(e =>
        {
            e.state = TrailState.EMPTY;
        });
        if(index >= 0 && index < trailsOfGame.Count)
        {
            var trailToMove = trailsOfGame[index];
            trailToMove.state = TrailState.OCCUPIED;
            if (index > 0)
            {
                var previousTrail = trailsOfGame[index - 1];
                    previousTrail.state = TrailState.PROBABLE;
            }
            if (index < trailsOfGame.Count - 1)
            {
                var nextTrail = trailsOfGame[index + 1];
                nextTrail.state = TrailState.PROBABLE;
            }
            return trailToMove;
        }
        return null;
    }
}

