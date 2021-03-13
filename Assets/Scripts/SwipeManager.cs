using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class TouchPressEvent: UnityEvent<float, float>
{
}

public class SwipeManager : MonoBehaviour
{
    #region "PRIVATE_ENUMS"

    protected enum SwipeDirection {
        UP, DOWN, LEFT, RIGHT, NONE
    }

    protected enum TouchState
    {
        MOVING, STOPPED
    }

    #endregion

    #region "PRIVATE_PROPERTIES"

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    Camera mainCamera;

    SwipeDirection currentDirection = SwipeDirection.NONE, previousDirection = SwipeDirection.NONE;

    float seconds = 0.0f;

    private TouchState state = TouchState.STOPPED;

    float secondsOnTouch = 0.0f;
    #endregion

    #region "EVENTS"
    [SerializeField]
    UnityEvent onRightTouch = new UnityEvent();
    [SerializeField]
    UnityEvent onLeftTouch = new UnityEvent();
    [SerializeField]
    UnityEvent onUpTouch = new UnityEvent();
    [SerializeField]
    UnityEvent onDownTouch = new UnityEvent();
    [SerializeField]
    TouchPressEvent onTouchPressed = new TouchPressEvent();
    #endregion

    #region "CUSTOMIZABLE_PROPERTIES"
    [SerializeField]
    float secondsToWait = 0.25f;
    #endregion

    #region "PUBLIC_VARIABLES"
    public static float currentTouchVelocity = 0.0f;
    #endregion

    #region "CLASS_METHODS"
    public void Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
                state = TouchState.MOVING;
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                float velocity = CalculateVelocity(firstPressPos, secondPressPos);

                currentTouchVelocity = Mathf.Abs(velocity);

                state = TouchState.STOPPED;

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);



                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && (currentSwipe.x > -0.5f && currentSwipe.x < 0.5f))
                {
                    if (currentDirection != SwipeDirection.UP)
                    {
                        onUpTouch.Invoke();
                        currentDirection = SwipeDirection.UP;
                    }

                }
                //swipe down
                if (currentSwipe.y < 0 && (currentSwipe.x > -0.5f && currentSwipe.x < 0.5f))
                {
                    if (currentDirection != SwipeDirection.DOWN)
                    {
                        onDownTouch.Invoke();
                        currentDirection = SwipeDirection.DOWN;
                    }

                }
                //swipe left
                if (currentSwipe.x < 0 && (currentSwipe.y > -0.5f && currentSwipe.y < 0.5f))
                {
                    if (currentDirection != SwipeDirection.LEFT)
                    {
                        onLeftTouch.Invoke();
                        currentDirection = SwipeDirection.LEFT;
                    }

                }
                //swipe right
                if (currentSwipe.x > 0 && (currentSwipe.y > -0.5f && currentSwipe.y < 0.5f))
                {
                    if (currentDirection != SwipeDirection.RIGHT)
                    {
                        onRightTouch.Invoke();
                        currentDirection = SwipeDirection.RIGHT;
                    }
                }
            }
        }
    }

    public void MouseSwipe()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            state = TouchState.MOVING;
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            float velocity = CalculateVelocity(firstPressPos, secondPressPos);

            currentTouchVelocity = Mathf.Abs(velocity);

            state = TouchState.STOPPED;

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe upwards
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                if (currentDirection != SwipeDirection.UP)
                {
                    onUpTouch.Invoke();
                    currentDirection = SwipeDirection.UP;
                }

            }
            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                if (currentDirection != SwipeDirection.DOWN)
                {
                    onDownTouch.Invoke();
                    currentDirection = SwipeDirection.DOWN;
                }

            }
            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                if (currentDirection != SwipeDirection.LEFT)
                {
                    onLeftTouch.Invoke();
                    currentDirection = SwipeDirection.LEFT;
                }

            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                if (currentDirection != SwipeDirection.RIGHT)
                {
                    onRightTouch.Invoke();
                    currentDirection = SwipeDirection.RIGHT;
                }
            }
        }
    }

    public void OnDuringTouchMouse()
    {
        if (Input.GetMouseButton(0))
        {
            var pointConverted = mainCamera.ScreenToWorldPoint(Input.mousePosition); 
            onTouchPressed.Invoke(pointConverted.x, pointConverted.y);
        }
    }


    public void OnDuringTouch()
    {
        if(Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if(t.phase != TouchPhase.Ended)
            {
                var pointConverted = mainCamera.ScreenToWorldPoint(t.position);
                onTouchPressed.Invoke(pointConverted.x, pointConverted.y);
            }
        }
    }



    private void ResetDirectionCounter()
    {
        if(previousDirection != currentDirection)
        {
            previousDirection = currentDirection;
            seconds = 0.0f;
        }
        else
        {
            if(seconds < secondsToWait)
            {
                seconds += Time.deltaTime;
            }
            else
            {
                currentDirection = SwipeDirection.NONE;
            }
        }
    }

    private void CountTimeOnScreen()
    {
       if(state == TouchState.MOVING)
        {
            secondsOnTouch += Time.deltaTime;
        }
       else if(state == TouchState.STOPPED)
        {
            secondsOnTouch = 0.0f;
        }
    }

  

    private float CalculateVelocity(Vector2 initialPosition, Vector2 finalPosition)
    {
        Vector3 initialPositionConverted = mainCamera.ScreenToWorldPoint(initialPosition);
        Vector3 finalPositionConverted = mainCamera.ScreenToWorldPoint(finalPosition);
        initialPositionConverted.z = finalPositionConverted.z = 0;
        float velocity = Vector3.Distance(finalPositionConverted, initialPositionConverted) / secondsOnTouch;
        return velocity;
    }
    #endregion

    #region "UNITY_METHODS"

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.touchSupported)
        {
            //Swipe();
            OnDuringTouch();
        }
        else if (Input.mousePresent)
        {
            //MouseSwipe();
            OnDuringTouchMouse();
        }
        ResetDirectionCounter();
        CountTimeOnScreen();
    }

    #endregion  
}
