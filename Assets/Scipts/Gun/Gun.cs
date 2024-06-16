using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public int powerUpLvRequirement = 0;
	public Bullet bullet;
	Vector2 direction;

	public float shootEverySecond;

	bool canShoot = true;

	public bool isActive = false;
	
	void Start()
	{
		direction = (transform.localRotation * Vector2.up).normalized;
	}

	void Update()
	{
		if (!isActive) return;

		// Tính toán hướng bắn
		direction = (transform.localRotation * Vector2.up).normalized;

		// Tự động bắn
		if(canShoot )
		{
			if (!isActive) return;
			StartCoroutine(Shooting());
		}
	}

	private IEnumerator Shooting()
	{	canShoot = false;
		GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
		Bullet goBullet = go.GetComponent<Bullet>();
		goBullet.direction = direction;
		AudioManager.Instance.PlaySFX("Dead");
		yield return new WaitForSeconds(shootEverySecond); 
		canShoot = true;
	}
}
