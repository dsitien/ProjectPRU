using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveRightToLeft : MonoBehaviour
{
    public float speed;
    private Camera mainCamera;
    private float destroyXPosition;
    public float offsetDestroy = 1f;
    public bool isActive = true;

    void Start()
    {
        mainCamera = Camera.main;
        destroyXPosition = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane)).x - offsetDestroy;
    }

    void FixedUpdate()
    {
        if (!isActive) return;
        Vector2 pos = transform.position;
        pos.x -= speed * Time.fixedDeltaTime;

        transform.position = pos;

        // Kiểm tra nếu đối tượng đi qua vị trí x của camera
        if (pos.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
}
