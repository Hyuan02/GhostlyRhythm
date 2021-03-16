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

    public Trail[] EmptyTrails
    {
        get
        {
            return trailsOfGame.FindAll(e => e.state == TrailState.EMPTY).ToArray();
        }
    }

    public Trail[] ProbableTrails
    {
        get
        {
            return trailsOfGame.FindAll(e => e.state == TrailState.PROBABLE).ToArray();
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

    public Trail OccupyTrailThroughPoint(float pointY)
    {
       var trailSelected = trailsOfGame.FindIndex(e =>
        {
            return pointY <= e.trailObject.transform.position.y + 1.5 &&
            pointY >= e.trailObject.transform.position.y - 1.5; 
        });

        return OccupyTrail(trailSelected);
    }
}

