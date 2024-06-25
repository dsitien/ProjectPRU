﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public Vector2 direction = new Vector2(0, 1);
	public float speed;
	public Vector2 velocity;

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

        Destroy(gameObject, 4);
		//DontDestroyOnLoad(gameObject);
	}

	// Update is called once per frame
	void Update()
	{
		velocity = direction * speed;
	}
	private void FixedUpdate()
	{
		Vector2 pos = transform.position;
		pos += velocity * Time.fixedDeltaTime;

		
		transform.position = pos;

	}
	//Destroy if go out camera
	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("BulletEnemy")) {
			Destroy(gameObject);
            if (audioManager != null)
            {
                audioManager.PlaySFX("BulletDestroy");
            }
            Destroy(collision.gameObject);
		}
    }
}
