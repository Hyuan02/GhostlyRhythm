using System.Collections;
using System.Collections.Generic;


public enum MovingType
{
    LEFT, RIGHT
}


/// <summary>
/// State used by the trails
/// EMPTY is Trail that is empty
/// PROBABLE is a Trail that is candidate to the player to move.
/// OCCUPIED is a Trail that the player is using.
/// </summary>
public enum TrailState
{
    EMPTY,
    PROBABLE,
    OCCUPIED
}