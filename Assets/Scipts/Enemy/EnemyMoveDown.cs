using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveDown : MonoBehaviour
{
	public float speed;
	private Camera mainCamera;
	private float destroyYPosition;
	public float offsetDestroy = 1f;
    public bool isActive = true;

    void Start()
	{
		mainCamera = Camera.main;
		destroyYPosition = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane)).y -offsetDestroy;
	}

	void FixedUpdate()
	{
        if (!isActive) return;
        Vector2 pos = transform.position;
		pos.y -= speed * Time.fixedDeltaTime;

		transform.position = pos;

		// Kiểm tra nếu đối tượng đi qua vị trí y của camera
		if (pos.y < destroyYPosition)
		{
			Destroy(gameObject);
		}
	}
}
