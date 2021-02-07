using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Transform))]
public class MovingDollyBehaviour : MonoBehaviour
{


    #region "VARIABLES"
    [SerializeField]
    [Range(0.01f, 50)]
    float speedX = 0.5f;
    #endregion

    #region "SCRIPT_FUNCTIONS"
    void MoveTransform()
    {
        this.transform.Translate(new Vector3(speedX, 0));
    }
    #endregion

    #region "UNITY_FUNCTIONS"
    void FixedUpdate()
    {
        MoveTransform();
    }
    #endregion
}
