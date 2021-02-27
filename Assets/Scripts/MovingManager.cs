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

    #endregion


    #region "UNITY_METHODS"
    private void Start()
    {
        StartPlayer();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, new Vector3(this.transform.position.x, currentTrail.trailObject.transform.position.y, this.transform.position.z)) > 0.01f)
        {
            this.transform.position = new Vector3(this.transform.position.x, Mathf.Lerp(this.transform.position.y, currentTrail.trailObject.transform.position.y, Time.deltaTime * currentVelocityY), 2);
        }
    }
    #endregion

}
