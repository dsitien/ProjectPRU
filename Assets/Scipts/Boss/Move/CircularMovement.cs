using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    public float radius = 5f; // The radius of the circle
    public float speed = 1f; // The speed of rotation
    float angle;
    private Vector3 centerPosition;

    void Start()
    {
        centerPosition = transform.position;
    }

    void Update()
    {
        angle += speed * Time.deltaTime;
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        transform.position = centerPosition + new Vector3(x, y, 0);
    }
}
