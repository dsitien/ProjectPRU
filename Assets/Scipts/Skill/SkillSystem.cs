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
        //skill 1
        if (isCooldown1)
        {
            skillImg1.fillAmount += 1 / cooldownQ * Time.deltaTime;
            if (skillImg1.fillAmount >= 1)
            {
                skillImg1.fillAmount = 1;
                isCooldown1 = false;
                if (button1 != null) button1.interactable = true; // Enable button when cooldown is over
            }
            if (skillImg1.fillAmount >= 0.2f && skillImg1.fillAmount <= 1f)
            {
                DisableActiveQ();
            }
        }

        //skill 2
        if (isCooldown2)
        {
            skillImg2.fillAmount += 1 / cooldownW * Time.deltaTime;
            if (skillImg2.fillAmount >= 1)
            {
                skillImg2.fillAmount = 1;
                isCooldown2 = false;
                if (button2 != null) button2.interactable = true; // Enable button when cooldown is over
            }
            if (skillImg2.fillAmount >= 0.25f && skillImg2.fillAmount <= 1f)
            {
                DisableActiveW();
            }
        }

        //skill 3
        if (isCooldown3)
        {
            skillImg3.fillAmount += 1 / cooldownE * Time.deltaTime;
            if (skillImg3.fillAmount >= 1)
            {
                skillImg3.fillAmount = 1;
                isCooldown3 = false;
                if (button3 != null) button3.interactable = true; // Enable button when cooldown is over
            }
            if (skillImg3.fillAmount >= 0.5f && skillImg3.fillAmount <= 1f)
            {
                DisableActiveE();
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
            Debug.Log("Cooldown1");
        }
        else
        {
           // Debug.Log("Skill 1 activated");
            isCooldown1 = true;
            if (skillImg1 != null) skillImg1.fillAmount = 0;
            if (button1 != null) button1.interactable = false;
            ActiveQ();
        }
    }

    public void SkillW()
    {
        if (isCooldown2)
        {
            Debug.Log("Cooldown2");
        }
        else
        {
            ActiveW();
            isCooldown2 = true;
            if (skillImg2 != null) skillImg2.fillAmount = 0;
            if (button2 != null) button2.interactable = false;
          
        }
    }

    public void SkillE()
    {
        if (isCooldown3)
        {
            Debug.Log("Cooldown3");
        }
        else
        {
          
            isCooldown3 = true;
            if (skillImg3 != null) skillImg3.fillAmount = 0;
            if (button3 != null) button3.interactable = false; 
            ActiveE();
        }
    }
    public void ActiveQ()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 1 || gun.powerUpLvRequirement == 2)
            {
                gun.isActive = true;
                gun.gameObject.SetActive(true);

            }
        }
      
    }
    public void ActiveW()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 1)
            {
                gun.isActive = true;
                gun.gameObject.SetActive(true);
            }
        }

   
    }
    public void ActiveE()
    {
        foreach (Gun gun in guns)
        {
                gun.shootEverySecond = 0.25f;
            
        }
    }

    void DisableActiveQ()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 1 || gun.powerUpLvRequirement == 2)
            {
                gun.isActive = false;
                gun.gameObject.SetActive(false);
            }
        }
    }

    void DisableActiveW()
    {
        foreach (Gun gun in guns)
        {
            if (gun.powerUpLvRequirement == 2)
            {
                gun.isActive = false;
                gun.gameObject.SetActive(false);
            }
        }
    }

    void DisableActiveE()
    {
        foreach (Gun gun in guns)
        {
            if(gun.powerUpLvRequirement == 0)
            {
                gun.shootEverySecond = 0.75f;
            }
            else
            {
                gun.shootEverySecond = 0.5f;
            }
        }
    }
}
