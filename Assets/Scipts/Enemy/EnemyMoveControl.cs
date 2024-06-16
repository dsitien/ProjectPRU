using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveControl : MonoBehaviour
{
    public EnemyMoveDown horizontalMovementScript;
    public EnemyMoveLeRi verticalMovementScript;
    public float distanceMin ;
    public float distanceMax ;
    private float distance ;

    private float initialVerticalPosition;

    void Start()
    {
        initialVerticalPosition = transform.position.y;
        EnableHorizontalMovement();
    }

    void Update()
    {
        float traveledVerticalDistance = Mathf.Abs(transform.position.y - initialVerticalPosition);
       
        if (traveledVerticalDistance >= distance)
        {
            EnableVerticalMovement();
        }
    }

    void EnableHorizontalMovement()
    {
        horizontalMovementScript.isActive = true;
        verticalMovementScript.isActive = false;
        initialVerticalPosition = transform.position.y;
        distance = UnityEngine.Random.Range(distanceMin, distanceMax);
    }

    void EnableVerticalMovement()
    {
        horizontalMovementScript.isActive = false;
        verticalMovementScript.isActive = true;
    }
}
