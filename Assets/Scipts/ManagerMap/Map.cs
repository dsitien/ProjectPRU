using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class Map : MonoBehaviour
{

    [Header("Enemy Object")]
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
    [SerializeField] GameObject enemy4; 
   
    [SerializeField] GameObject boss;

    [Header("Item Object")]
    [SerializeField] GameObject item1;  
    [SerializeField] GameObject item2;  
    [SerializeField] GameObject item3;

    [Header("Time Delay")]
    [SerializeField] float time1;
    [SerializeField] float time2;
    [SerializeField] float time3;
    [SerializeField] float time4;
   
     [SerializeField] float timeBoss;



    [Header("UI Elements")]
    [SerializeField] GameObject instructionPanel;

    [SerializeField] Button playButton;
    private bool gameStarted = false;

    // Start is called before the first frame update
    private void Awake()
    {

        enemy1.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);
        enemy4.SetActive(false);
     
        boss.SetActive(false);
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
        yield return new WaitForSeconds(time1);
        enemy1.SetActive(true);

        yield return new WaitForSeconds(time2);
        enemy1.SetActive(false);
        enemy2.SetActive(true);
        item1.SetActive(true) ;

      

        yield return new WaitForSeconds(time3);
        enemy2.SetActive(false);
        enemy3.SetActive(true);
        item1.SetActive(false);


        yield return new WaitForSeconds(time4);
        enemy3.SetActive(false);
        enemy4.SetActive(true);

        
        yield return new WaitForSeconds(timeBoss);
        enemy4.SetActive(false);
        boss.SetActive(true);
        item3.SetActive(true);

        

        yield return new WaitForSeconds(50f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
