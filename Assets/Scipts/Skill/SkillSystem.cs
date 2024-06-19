using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSystem : MonoBehaviour
{
    public GameObject ship;
    Gun[] guns;

    [Header("Skill 1")]
    public Image skillImg1;
    public float cooldownQ = 3f;
    bool isCooldown1 = false;
    public Button button1;

    [Header("Skill 2")]
    public Image skillImg2;
    public float cooldownW = 5f;
    bool isCooldown2 = false;
    public Button button2;

    [Header("Skill 3")]
    public Image skillImg3;
    public float cooldownE = 10f;
    bool isCooldown3 = false;
    public Button button3;

    private void Awake()
    {
        guns = ship.GetComponentsInChildren<Gun>(true);

        if (skillImg1 != null) skillImg1.fillAmount = 1;
        if (skillImg2 != null) skillImg2.fillAmount = 1;
        if (skillImg3 != null) skillImg3.fillAmount = 1;
    }

    void Start()
    {
        // Disable buttons at start if they are in cooldown
        if (button1 != null) button1.interactable = !isCooldown1;
        if (button2 != null) button2.interactable = !isCooldown2;
        if (button3 != null) button3.interactable = !isCooldown3;
    }

    void Update()
    {
        // Skill 1
        if (isCooldown1)
        {
            skillImg1.fillAmount += 1 / cooldownQ * Time.deltaTime;
            if (skillImg1.fillAmount >= 1)
            {
                skillImg1.fillAmount = 1;
                isCooldown1 = false;
                if (button1 != null) button1.interactable = true; // Enable button when cooldown is over
            }
        }

        // Skill 2
        if (isCooldown2)
        {
            skillImg2.fillAmount += 1 / cooldownW * Time.deltaTime;
            if (skillImg2.fillAmount >= 1)
            {
                skillImg2.fillAmount = 1;
                isCooldown2 = false;
                if (button2 != null) button2.interactable = true; // Enable button when cooldown is over
            }
        }

        // Skill 3
        if (isCooldown3)
        {
            skillImg3.fillAmount += 1 / cooldownE * Time.deltaTime;
            if (skillImg3.fillAmount >= 1)
            {
                skillImg3.fillAmount = 1;
                isCooldown3 = false;
                if (button3 != null) button3.interactable = true; // Enable button when cooldown is over
            }
        }

        // Check if buttons are assigned and cooldown is not active
        if (button1 != null && Input.GetKeyDown(KeyCode.Q) && !isCooldown1)
        {
            button1.onClick.Invoke();
        }

        if (button2 != null && Input.GetKeyDown(KeyCode.W) && !isCooldown2)
        {
            button2.onClick.Invoke();
        }

        if (button3 != null && Input.GetKeyDown(KeyCode.E) && !isCooldown3)
        {
            button3.onClick.Invoke();
        }
    }

    public void SkillQ()
    {
        if (isCooldown1)
        {
            Debug.Log("SkillQ is on cooldown");
        }
        else
        {
            isCooldown1 = true;
            if (skillImg1 != null) skillImg1.fillAmount = 0;
            if (button1 != null) button1.interactable = false;
            ActiveQ();
        }
    }

    public void ActiveQ()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 1 || gun.powerUpLvRequirement == 2)
            {
                gun.gameObject.SetActive(true);
                gun.isActive = true;
                Debug.Log($"Activated gun {gun.gameObject.name} with powerUpLvRequirement {gun.powerUpLvRequirement}");
            }
        }
    }

    void DisableActiveQ()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 1 || gun.powerUpLvRequirement == 2)
            {
                gun.isActive = false;
                Debug.Log($"Deactivated gun {gun.gameObject.name} with powerUpLvRequirement {gun.powerUpLvRequirement}");
            }
        }
    }

    public void SkillW()
    {
        if (isCooldown2)
        {
            Debug.Log("SkillW is on cooldown");
        }
        else
        {
            isCooldown2 = true;
            if (skillImg2 != null) skillImg2.fillAmount = 0;
            if (button2 != null) button2.interactable = false;
            ActiveW();
        }
    }

    public void ActiveW()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 3)
            {
                gun.gameObject.SetActive(true);
                gun.isActive = true;
                Debug.Log($"Activated gun {gun.gameObject.name} with powerUpLvRequirement {gun.powerUpLvRequirement}");
            }
        }
    }

    void DisableActiveW()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 3)
            {
                gun.isActive = false;
                Debug.Log($"Deactivated gun {gun.gameObject.name} with powerUpLvRequirement {gun.powerUpLvRequirement}");
            }
        }
    }

    public void SkillE()
    {
        if (isCooldown3)
        {
            Debug.Log("SkillE is on cooldown");
        }
        else
        {
            isCooldown3 = true;
            if (skillImg3 != null) skillImg3.fillAmount = 0;
            if (button3 != null) button3.interactable = false;
            ActiveE();
        }
    }

    public void ActiveE()
    {
        foreach (Gun gun in guns)
        {
            gun.shootEverySecond = 0.25f;
            Debug.Log($"Increased shoot speed for gun {gun.gameObject.name}");
        }
    }

    void DisableActiveE()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 0)
            {
                gun.shootEverySecond = 0.75f;
            }
            else
            {
                gun.shootEverySecond = 0.5f;
            }
            Debug.Log($"Reset shoot speed for gun {gun.gameObject.name}");
        }
    }
}
