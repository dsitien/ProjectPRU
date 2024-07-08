using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map6 : MonoBehaviour
{
    [Header("Enemy Object")]
    [SerializeField] GameObject boss1;
    [SerializeField] GameObject boss2;
    [SerializeField] GameObject boss3;



    [Header("Item Object")]
    [SerializeField] GameObject item1;
    [SerializeField] GameObject item2;
    [SerializeField] GameObject item3;
    [SerializeField] GameObject item4;
    [SerializeField] GameObject item5;
    [SerializeField] GameObject item6;
    [SerializeField] GameObject item7;
    [SerializeField] GameObject item8;
    [SerializeField] GameObject item9;

    [Header("Time Delay")]
    [SerializeField] float timeBoss1;
    [SerializeField] float timeItem1;
    [SerializeField] float timeBoss2;
    [SerializeField] float timeItem2;
    [SerializeField] float timeBoss3;
    [SerializeField] float timeItem3;
    [SerializeField] float timeItem4;






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



        item1.SetActive(false);
        item2.SetActive(false);
        item3.SetActive(false);
        item4.SetActive(false);
        item5.SetActive(false);
        item6.SetActive(false);
        item7.SetActive(false);
        item8.SetActive(false);
        item9.SetActive(false);



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
        item1.SetActive(true);
        item2.SetActive(true);
        item3.SetActive(true);
        //Phase2
        yield return new WaitForSeconds(timeBoss2);
        boss2.SetActive(true);
        item1.SetActive(false);
        item2.SetActive(false);
        item3.SetActive(false);


        yield return new WaitForSeconds(timeItem2);
        item4.SetActive(true);
        item5.SetActive(true);
        item6.SetActive(true);
        //Phase3
        yield return new WaitForSeconds(timeBoss3);
        boss3.SetActive(true);
        item4.SetActive(false);
        item5.SetActive(false);
        item6.SetActive(false);

        yield return new WaitForSeconds(timeItem3);
        item7.SetActive(true);
        item8.SetActive(true);
        item9.SetActive(true);

        yield return new WaitForSeconds(timeItem4);
        item7.SetActive(false);
        item8.SetActive(false);
        item9.SetActive(false);




    }
}
