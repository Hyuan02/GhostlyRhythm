using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class MovingManager : MonoBehaviour
{
    #region "CUSTOMIZABLE_PROPERTIES"
    #endregion

    #region "PRIVATE_PROPERTIES"
    private int currentTrailIndex = 2;
    private float currentVelocityY = 0;
    private Trail currentTrail = null;
    private float currentY;

    private const float MIN_Y = -4.25f;
    private const float MAX_Y = 4.25f;


    #endregion


    #region "CLASS METHODS"
    public void MovingPlayerToRight()
    {
        MovingPlayer(MovingType.RIGHT);
    }
    public void MovingPlayerToLeft()
    {
        MovingPlayer(MovingType.LEFT);
    }

    public void StartPlayer()
    {
        currentTrailIndex = 2;
        currentTrail = TrailsManager.instance.OccupyTrail(currentTrailIndex);
        currentY = currentTrail.trailObject.transform.position.y;
        this.transform.position = new Vector3(this.transform.position.x, currentTrail.trailObject.transform.position.y, this.transform.position.z);
    }

    public void MovingPlayer(MovingType direction)
    {
        ApplyForceToPlayer(direction, SwipeManager.currentTouchVelocity);
    }

    void ApplyForceToPlayer(MovingType type, float velocityY)
    {
        switch (type)
        {
            case MovingType.RIGHT:
                MoveToNextTrail(velocityY);
                break;
            case MovingType.LEFT:
                MoveToPreviousTrail(velocityY);
                break;
        }
    }

    private void MoveToNextTrail(float velocityY)
    {
        if (currentTrailIndex < TrailsManager.instance.trailsLength - 1)
        {
            currentTrailIndex++;
            currentTrail = TrailsManager.instance.OccupyTrail(currentTrailIndex);
            currentVelocityY = velocityY;
        }
    }

    private void MoveToPreviousTrail(float velocityY)
    {
        if (currentTrailIndex > 0)
        {
            currentTrailIndex--;
            currentTrail = TrailsManager.instance.OccupyTrail(currentTrailIndex);
            currentVelocityY = velocityY;
        }
    }


    public void ReceiveTouch(float positionX, float positionY)
    {

        currentY = Mathf.Clamp(positionY, MIN_Y, MAX_Y);
        DetermineTrail(positionY);
    }

    private void DetermineTrail(float pointY)
    {
        if(pointY < -4)
        {
            currentTrail = TrailsManager.instance.OccupyTrail(4);
        }
        else if(pointY > 4){
            currentTrail = TrailsManager.instance.OccupyTrail(0);
        }
        else
        {
            currentTrail = TrailsManager.instance.OccupyTrailThroughPoint(pointY);
        }
    }
    #endregion


    #region "UNITY_METHODS"
    private void Start()
    {
        StartPlayer();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, new Vector3(this.transform.position.x, currentY, this.transform.position.z)) > 0.01f)
        {
            this.transform.position = new Vector3(this.transform.position.x, Mathf.Lerp(this.transform.position.y, currentY, Time.deltaTime * 10), 2);
        }
    }
    #endregion

}
