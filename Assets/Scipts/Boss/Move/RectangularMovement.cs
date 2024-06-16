using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangularMovement : MonoBehaviour
{
    public float width = 5f; // Width of the rectangle
    public float height = 3f; // Height of the rectangle
    public float speed = 1f; // Speed of movement

    private Vector3[] vertices;
    private int currentVertex = 0;
    private Vector3 targetPosition;

    void Start()
    {
        vertices = new Vector3[4];
        vertices[0] = transform.position;
        vertices[1] = vertices[0] + new Vector3(width, 0, 0); // right
        vertices[2] = vertices[1] + new Vector3(0, height, 0); // up
        vertices[3] = vertices[2] + new Vector3(-width, 0, 0); // left

        targetPosition = vertices[1];
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentVertex = (currentVertex + 1) % 4;
            targetPosition = vertices[currentVertex];
        }
    }
}
