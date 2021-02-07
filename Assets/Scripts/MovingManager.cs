using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class MovingManager : MonoBehaviour
{
    #region "CUSTOMIZABLE_PROPERTIES"
    [SerializeField]
    List<GameObject> trails = new List<GameObject>();
    #endregion

    #region "PRIVATE_PROPERTIES"
    private int currentTrailIndex = 1;
    private float currentVelocityY = 0;
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
        if (currentTrailIndex < 2)
        {
            currentTrailIndex++;
            currentVelocityY = velocityY;
        }
    }

    private void MoveToPreviousTrail(float velocityY)
    {
        if (currentTrailIndex > 0)
        {
            currentTrailIndex--;
            currentVelocityY = velocityY;
        }
    }

    #endregion


    #region "UNITY_METHODS"
    private void Awake()
    {
        this.transform.position = new Vector3(this.transform.position.x, trails[currentTrailIndex].transform.position.y, this.transform.position.z);
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, new Vector3(this.transform.position.x, trails[currentTrailIndex].transform.position.y, this.transform.position.z)) > 0.01f)
        {
            this.transform.position = new Vector3(this.transform.position.x, Mathf.Lerp(this.transform.position.y, trails[currentTrailIndex].transform.position.y, Time.deltaTime * currentVelocityY), 2);
        }
    }
    #endregion

}
