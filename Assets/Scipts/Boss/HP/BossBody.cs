using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BossBody : MonoBehaviour
{
    public float MaxHealth = 100;
    public float currentHealth;
    public GameObject explosion;

    public Image healthBarFill;


    GunScript3[] guns;
    int powerUpGun = 0;

   // Laser[] lazers;

    public enum BossPhase { PhaseOne, PhaseTwo, PhaseThree }
    public BossPhase currentPhase;


    bool IsTwo = false;
    bool IsThree = false;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        currentPhase = BossPhase.PhaseOne;
        //     levelControler.instance.AddEnemy();

        guns = transform.GetComponentsInChildren<GunScript3>();

        foreach (GunScript3 gun in guns)
        {

            gun.isActive = true;

            if (gun.powerUpRequirement != 0)
            {
                gun.gameObject.SetActive(false);
            }
        }



        //lazers = transform.GetComponentsInChildren<Laser>();
        //foreach (Laser laser in lazers)
        //{
        //    laser.isAutoShoot = true;
        //    if (laser.powerUpRequirement != 0)
        //    {
        //        laser.gameObject.SetActive(false);
        //    }


        //}





    }

    // Update is called once per frame
    void Update()
    {
        CheckPhaseChange();
    }

     void UpdateHealthBar()
    {
        healthBarFill.fillAmount = currentHealth / MaxHealth;
    }

    public void Hit()
    {
      
            currentHealth--;
            currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);
            UpdateHealthBar();
            if (currentHealth == 0)
            {
                DestroyShip();
            }
            
   
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("BulletPlayer"))
        {
            Hit();
            Debug.Log("hi");
        }

       




    }


    void DestroyShip()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        
        Debug.Log("die");
        // levelControler.instance.RemoveEnemy();
        Destroy(gameObject);
    }



    void AddGuns()//nâng cấp súng
    {
        powerUpGun++;
        foreach (GunScript3 gun in guns)
        {
            if (gun.powerUpRequirement == powerUpGun)
            {
                gun.gameObject.SetActive(true);
            }
            else if (gun.powerUpRequirement > powerUpGun)
            {
                gun.gameObject.SetActive(false);
            }
        }


        //foreach (Laser laser in lazers)
        //{
        //    if (laser.powerUpRequirement == powerUpGun)
        //    {
        //        laser.gameObject.SetActive(true);
        //    }
        //    else if (laser.powerUpRequirement > powerUpGun)
        //    {
        //        laser.gameObject.SetActive(false);
        //    }


        //}





    }


    void CheckPhaseChange()
    {

        if (currentHealth <= MaxHealth * 0.7f && currentPhase != BossPhase.PhaseTwo && !IsTwo)
        {
            IsTwo = true;
            Debug.Log("2");
            AddGuns();

        }
        else if (currentHealth <= MaxHealth * 0.3f && currentPhase != BossPhase.PhaseThree && !IsThree)
        {
            IsThree = true;
            Debug.Log("3");
            AddGuns();

        }
    }








}
