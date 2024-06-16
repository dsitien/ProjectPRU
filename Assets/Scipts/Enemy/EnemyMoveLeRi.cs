using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveLeRi : MonoBehaviour
{
    public float speed = 5f;
    private float halfScreenWidth;
    private bool movingRight = true;
    public bool isActive = true;

    void Start()
    {
        // Tính toán một nửa chiều rộng màn hình bằng đơn vị thế giới
        halfScreenWidth = Camera.main.orthographicSize * Camera.main.aspect * 0.9f;
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (!isActive) return;
        // Di chuyển nhân vật theo chiều ngang
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);
        }

        // Kiểm tra nếu nhân vật đi qua nửa màn hình theo chiều ngang thì đổi hướng
        if (transform.position.x > halfScreenWidth)
        {
            movingRight = false;
        }
        else if (transform.position.x < -halfScreenWidth)
        {
            movingRight = true;
        }
    }
}
