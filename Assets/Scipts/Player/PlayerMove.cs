using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] float moveSpeed;
	private bool isDragging;
	private Camera mainCamera;

	void Start()
	{
		isDragging = false;
		mainCamera = Camera.main;
	}

	void Update()
	{
		// Check for mouse button down
		if (Input.GetMouseButtonDown(0))
		{
			// Check if the mouse is over the player
			Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = 0; // Ensure z is 0 if using a 2D plane
			if (Vector2.Distance(mousePos, transform.position) < 0.5f) // Adjust the distance as needed
			{
				isDragging = true;
			}
		}

		// Check for mouse button up
		if (Input.GetMouseButtonUp(0))
		{
			isDragging = false;
		}

		// Drag the player
		if (isDragging)
		{
			Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = 0; // Ensure z is 0 if using a 2D plane

			// Clamp the position within the camera bounds
			Vector3 clampedMousePos = ClampPositionToCameraBounds(mousePos);

			transform.position = clampedMousePos;
		}
	}

	private Vector3 ClampPositionToCameraBounds(Vector3 position)
	{
		// Get the camera's bounds in world coordinates
		Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
		Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

		// Clamp the position within the bounds
		position.x = Mathf.Clamp(position.x, bottomLeft.x + 0.5f, topRight.x - 0.5f);
		position.y = Mathf.Clamp(position.y, bottomLeft.y + 0.5f, topRight.y - 0.5f);

		return position;
	}

	
}
