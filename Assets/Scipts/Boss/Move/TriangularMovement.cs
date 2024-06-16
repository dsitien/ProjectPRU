using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangularMovement : MonoBehaviour
{
    public float sideLength = 5f; // Length of each side of the triangle
    public float speed = 1f; // Speed of movement

    private Vector3[] vertices;
    private int currentVertex = 0;
    private Vector3 targetPosition;

    void Start()
    {
        vertices = new Vector3[3];
        vertices[0] = transform.position;
        vertices[1] = vertices[0] + new Vector3(sideLength, 0, 0); // right
        vertices[2] = vertices[0] + new Vector3(sideLength / 2, Mathf.Sqrt(3) * sideLength / 2, 0); // top

        targetPosition = vertices[1];
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentVertex = (currentVertex + 1) % 3;
            targetPosition = vertices[currentVertex];
        }
    }
}

