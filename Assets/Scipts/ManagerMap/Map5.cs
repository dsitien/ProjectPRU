using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map5 : MonoBehaviour
{
    [Header("Enemy Object")]
    [SerializeField] GameObject boss1;
    [SerializeField] GameObject boss2;
    [SerializeField] GameObject boss3;
    [SerializeField] GameObject boss4;


    [Header("Item Object")]
    [SerializeField] GameObject item1;
    [SerializeField] GameObject item2;
    [SerializeField] GameObject item3;

    [Header("Time Delay")]
    [SerializeField] float timeBoss1;
    [SerializeField] float timeBoss2;
    [SerializeField] float timeBoss3;
    [SerializeField] float timeBoss4;

    [SerializeField] float timeItem1; 
    [SerializeField] float timeItem2;
    [SerializeField] float timeItem3; 




    [Header("UI Elements")]
    [SerializeField] GameObject instructionPanel;

    [SerializeField] Button playButton;
    private bool gameStarted = false;

    // Start is called before the first frame update
    private void Awake()
    {

        boss1.SetActive(false);
        boss2.SetActive(false);
        boss3.SetActive(false);
        boss4.SetActive(false);

       
        item1.SetActive(false);
        item2.SetActive(false);
        item3.SetActive(false);



        // Hiển thị thông báo nhiệm vụ
        instructionPanel.SetActive(true);

        playButton.onClick.AddListener(OnPlayButtonClick);
    }

    public void OnPlayButtonClick()
    {
        Debug.Log("hi");
        if (!gameStarted)
        {
            gameStarted = true;
            instructionPanel.SetActive(false);
            Timer.instance.StartTimer();
            StartCoroutine(StartMission());
        }
    }

    private IEnumerator StartMission()
    {
        //Phase1
        yield return new WaitForSeconds(timeBoss1);
        boss1.SetActive(true);
        yield return new WaitForSeconds(timeItem1);
        item1.SetActive(true );
        //Phase2
        yield return new WaitForSeconds(timeBoss2);
        boss1.SetActive(false);
        item1.SetActive(false);
        boss2.SetActive(true); 
        
        yield return new WaitForSeconds(timeItem2);
        item2.SetActive(true );
        //Phase3
        yield return new WaitForSeconds(timeBoss3);
        boss2.SetActive(false);
        item2.SetActive(false);
        boss3.SetActive(true);
        yield return new WaitForSeconds(timeItem3);
        item3.SetActive(true);
          //Phase4
        yield return new WaitForSeconds(timeBoss4);
        boss3.SetActive(false);
        item3.SetActive(false);
        boss4.SetActive(true);

        yield return new WaitForSeconds(50f);

    }
}
