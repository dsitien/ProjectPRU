using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkMovement : MonoBehaviour
{
    public float range = 5f; // Range within which the boss can move
    public float interval = 1f; // Time between each move
    public float speed = 1f; // Speed of movement

    private Vector3 targetPosition;
    private float timer;

    void Start()
    {
        SetNewTargetPosition();
        timer = interval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SetNewTargetPosition();
            timer = interval;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    void SetNewTargetPosition()
    {
        float x = Random.Range(-range, range);
        float y = Random.Range(-range, range);
        targetPosition = new Vector3(x, y, 0);
    }
}
