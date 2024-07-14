using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject explosion;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isShielded = false;

    private Gun[] guns;
    private GameObject ship;
    private AudioManager audioManager;
    private GameObject shieldObject;

    private void Start()
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
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        ship = GameObject.Find("Ship");
        guns = ship.GetComponentsInChildren<Gun>(true);

       
        shieldObject = GameObject.Find("Shield");
        if (shieldObject != null)
        {
            shieldObject.SetActive(false); 
        }
        else
        {
            Debug.LogWarning("Shield not found in the scene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("BulletEnemy") || collision.CompareTag("Boss")|| collision.CompareTag("Rock"))
        {
            hit();
        }

        GunItem item = collision.GetComponent<GunItem>();
        if (collision.CompareTag("Item"))
        {
            if (audioManager != null)
            {
                audioManager.PlaySFX("Heal");
            }
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

        if (collision.CompareTag("Shield"))
        {
            ActivateShield();
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator DisableAfterTime(string vpType)
    {
        yield return new WaitForSeconds(4f);

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

    public void hit()
    {
        if (isShielded)
        {
            return; 
        }

        PlayerHeart.health--;
        if (PlayerHeart.health <= 0)
        {
            PlayerHeart.health = 0;
            Instantiate(explosion, transform.position, Quaternion.identity);
            GetComponent<PlayerMove>().enabled = false;
            if (audioManager != null)
            {
                audioManager.PlaySFX("Dead");
            }
            GameLoss gameLoss = GameObject.Find("LossGame").GetComponent<GameLoss>();
            gameLoss.TriggerGameLossPanelWithDelay(1f);
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
        if (audioManager != null)
        {
            audioManager.PlaySFX("GiveDame");
        }
        for (int i = 0; i < 8; i++)
        {
            SetTransparency(0.5f);
            yield return new WaitForSeconds(0.2f);
            SetTransparency(1f);
            yield return new WaitForSeconds(0.2f);
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
        gethurt = false;
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
        if (audioManager != null)
        {
            audioManager.PlaySFX("Heal");
        }
        if (PlayerHeart.health > 3)
        {
            PlayerHeart.health = 3;
        }
    }

    public void ActivateShield()
    {
        if (isShielded)
        {
            return; 
        }
        if (audioManager != null)
        {
            audioManager.PlaySFX("Heal");
        }
        isShielded = true;
        Physics2D.IgnoreLayerCollision(6, 7, true);
        if (shieldObject != null)
        {
            shieldObject.SetActive(true);
        }
        StartCoroutine(ShieldDuration());
    }

    private IEnumerator ShieldDuration()
    {
        yield return new WaitForSeconds(4f);
        isShielded = false;
        Physics2D.IgnoreLayerCollision(6, 7, false);
        if (shieldObject != null)
        {
            shieldObject.SetActive(false);
        }
    }
}
