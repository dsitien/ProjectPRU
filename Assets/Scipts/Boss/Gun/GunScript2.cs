using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript2 : MonoBehaviour
{

    public BulletScript2 bullet2;
    public Transform bulletPos;

    public bool autoShoot = false;
    public float shootIntervalSecconds = 0.5f;
    public float shootDelaySecconds = 0.0f;
    float shootTimer = 0f;
    float delayTimer = 0f;


    public bool isActive = false;
    //vô hiệu súng địch khi ở ngoài màn hình


    public int powerUpRequirement = 0;


    private GameObject player;
    public float autoShootDistance = 10;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (!isActive)
        {
            return;
        }


        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < autoShootDistance)
        {
            if (autoShoot)
            {

                if (delayTimer >= shootDelaySecconds)
                {
                    if (shootTimer >= shootIntervalSecconds)
                    {
                        Shoot();
                        shootTimer = 0;
                    }
                    else
                    {
                        shootTimer += Time.deltaTime;
                    }
                    delayTimer = 0;
                }
                else
                {
                    delayTimer += Time.deltaTime;
                }
            }
        }


    }


    public void Shoot()
    {
        GameObject go = Instantiate(bullet2.gameObject, transform.position, Quaternion.identity);
        //Khi một đối tượng sử dụng Quaternion.identity làm giá trị quay, nó sẽ không xoay so với hệ tọa độ gốc.




    }


}
