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



    [Header("Time Delay")]
    [SerializeField] float time1;
    [SerializeField] float time2;
    [SerializeField] float time3;
    [SerializeField] float time4;
    [SerializeField] float time5;
    [SerializeField] float time6;
    [SerializeField] float time7;






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



        // Hiển thị thông báo nhiệm vụ
        instructionPanel.SetActive(true);

        playButton.onClick.AddListener(OnPlayButtonClick);
    }

    public void OnPlayButtonClick()
    {
        
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
        yield return new WaitForSeconds(time1);
        boss1.SetActive(true);

        yield return new WaitForSeconds(time2);
        item1.SetActive(true);

        //Phase2
        yield return new WaitForSeconds(time3);
        boss2.SetActive(true);




        yield return new WaitForSeconds(time4);
        item2.SetActive(true);
        item1.SetActive(false);
        //Phase3
        yield return new WaitForSeconds(time5);
        boss3.SetActive(true);


        yield return new WaitForSeconds(time6);
        item3.SetActive(true);
        yield return new WaitForSeconds(time7);
        item2.SetActive(false);

        yield return new WaitForSeconds(5f);
        item3.SetActive(false);


    }
}
