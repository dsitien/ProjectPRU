using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveMovement : MonoBehaviour
{
    public float amplitude = 5f; // The height of the sine wave
    public float frequency = 1f; // The speed of the sine wave
    public Vector3 axis = Vector3.up; // The axis along which the sine wave moves
    public Vector3 direction = Vector3.forward; // The primary direction of movement

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float sineValue = Mathf.Sin(Time.time * frequency) * amplitude;
        Vector3 offset = axis * sineValue;
        transform.position = startPosition + direction * Time.time + offset;
    }
}

