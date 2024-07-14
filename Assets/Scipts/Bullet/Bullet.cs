using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction = new Vector2(0, 1);
    public float speed;
    public Vector2 velocity;
    public GameObject explosion;

    private AudioManager audioManager;
    void Start()
    {
        GameObject audioManagerObject = GameObject.Find("AudioManager");
        if (audioManagerObject != null)
        {
            audioManager = audioManagerObject.GetComponent<AudioManager>();
        }
        else
        {
            Debug.LogWarning("AudioManager not found in the scene");
        }

        Destroy(gameObject, 3);
        velocity = direction * speed;
    }
    void Update()
    {
      
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos += velocity * Time.fixedDeltaTime;


        transform.position = pos;

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletEnemy")){
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }
        if (collision.CompareTag("Enemy"))
        {
           
            if (audioManager != null)
            {
                audioManager.PlaySFX("BulletDestroy");
            }

            Destroy(gameObject);
        }
        if (collision.CompareTag("Boss") || collision.CompareTag("Rock"))
        {
            Destroy(gameObject);
            if (audioManager != null)
            {
                audioManager.PlaySFX("BulletDestroy");
            }
            
        }
    }
}