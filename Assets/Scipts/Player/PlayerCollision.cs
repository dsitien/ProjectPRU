using System;
using System.Collections;
using Unity.Burst.Intrinsics;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerCollision : MonoBehaviour
{
    public GameObject explosion;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isShielded = false; // Biến để kiểm tra xem người chơi có đang trong trạng thái bảo vệ hay không

    Gun[] guns;
    private GameObject ship;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        ship = GameObject.Find("Ship");
        guns = ship.GetComponentsInChildren<Gun>(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy") || collision.CompareTag("BulletEnemy") || collision.CompareTag("Boss"))
        {
            hit();
        }


        //=========================================

        GunItem item = collision.GetComponent<GunItem>();
        if (collision.CompareTag("Item"))
        {
            if (item.VP1)
            {
                ActiveAllGun();
                StartCoroutine(DisableAfterTime("VP1"));
            }
            if (item.VP2)
            {
                ActiveAllGun2();
                StartCoroutine(DisableAfterTime("VP2"));
            }
            if (item.VP3)
            {
                ActiveAllGun3();
                StartCoroutine(DisableAfterTime("VP3"));
            }
            if (item.VP4)
            {
                ActiveAllGun4();
                StartCoroutine(DisableAfterTime("VP4"));
            }

            Destroy(item.gameObject);
        }

    }


    private IEnumerator DisableAfterTime(string vpType)
    {
        yield return new WaitForSeconds(5f);

        switch (vpType)
        {
            case "VP1":
                DeactivateAllGun();
                break;
            case "VP2":
                DeactivateAllGun2();
                break;
            case "VP3":
                DeactivateAllGun3();
                break;
            case "VP4":
                DeactivateAllGun4();
                break;
        }

    }



    private void ActiveAllGun()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 5)
            {
                Debug.Log("start");
                gun.gameObject.SetActive(true);
                gun.isActive = true;

            }
        }
    }

    private void ActiveAllGun2()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 7)
            {
                Debug.Log("start2");
                gun.gameObject.SetActive(true);
                gun.isActive = true;

            }
        }
    }


    private void ActiveAllGun3()
    {
        foreach (Gun gun in guns)
        {
            Debug.Log("start3");
            gun.shootEverySecond = 0.25f;
        }
    }


    private void ActiveAllGun4()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 6)
            {
                Debug.Log("start4");
                gun.gameObject.SetActive(true);
                gun.isActive = true;

            }
        }
    }

    //====================================

    private void DeactivateAllGun()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 5)
            {
                Debug.Log("end");
                gun.gameObject.SetActive(false);
                gun.isActive = false;
            }
        }
    }

    private void DeactivateAllGun2()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 7)
            {
                Debug.Log("end2");
                gun.gameObject.SetActive(false);
                gun.isActive = false;

            }
        }
    }


    private void DeactivateAllGun3()
    {
        foreach (Gun gun in guns)
        {
            Debug.Log("end3");
            gun.shootEverySecond = 0.75f; // or the default value
        }
    }

    private void DeactivateAllGun4()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 6)
            {
                Debug.Log("end4");
                gun.gameObject.SetActive(false);
                gun.isActive = false;

            }
        }
    }






    /// <summary>
    /// /////////////////////////////////////////////
    /// </summary>
    public void hit()
    {
        PlayerHeart.health--;
        if (PlayerHeart.health <= 0)
        {
            PlayerHeart.health = 0;
            Instantiate(explosion, transform.position, Quaternion.identity);
            GetComponent<PlayerMove>().enabled = false;

            GameLoss gameLoss = GameObject.Find("LossGame").GetComponent<GameLoss>();
            gameLoss.TriggerGameLossPanelWithDelay(2f);
        }
        else
        {
            StartCoroutine(GetHurt());
        }
    }


   public bool gethurt = false;
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        gethurt = true;
        for (int i = 0; i < 8; i++)
        {

            SetTransparency(0.5f);
            yield return new WaitForSeconds(0.2f);
            SetTransparency(1f);
            yield return new WaitForSeconds(0.2f);
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
        gethurt =false;

    }

    void SetTransparency(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }



    public void Heal()
    {
        PlayerHeart.health++;
        if (PlayerHeart.health > 3)
        {
            PlayerHeart.health = 3;
        }
    }
}
