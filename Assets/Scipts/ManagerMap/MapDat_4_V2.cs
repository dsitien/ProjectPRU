using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapDat_4_V2 : MonoBehaviour
{
    [Header("Enemy Object")]
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
    [SerializeField] GameObject enemy4;
    [SerializeField] GameObject enemy5;
    [SerializeField] GameObject enemy6;
    [SerializeField] GameObject boss;

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

    [Header("UI Elements")]
    [SerializeField] GameObject instructionPanel;

    [SerializeField] Button playButton;
    private bool gameStarted = false;

    private void Awake()
    {
        enemy1.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);
        enemy4.SetActive(false);
        enemy5.SetActive(false);
        enemy6.SetActive(false);
        boss.SetActive(false);
        item1.SetActive(false);
        item2.SetActive(false);
        item3.SetActive(false);

        instructionPanel.SetActive(true);
        playButton.onClick.AddListener(OnPlayButtonClick);
    }

    public void OnPlayButtonClick()
    {
        Debug.Log("hi");
        if (!gameStarted)
        {
            gameStarted = true;
            Timer.instance.StartTimer(); // Bắt đầu timer
            instructionPanel.SetActive(false);
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
        item1.SetActive(true);

        yield return new WaitForSeconds(time3);

        enemy2.SetActive(false);
        enemy3.SetActive(true);
        item1.SetActive(false);

        yield return new WaitForSeconds(time4);
        enemy3.SetActive(false);

        enemy4.SetActive(true);
        item2.SetActive(true);



        yield return new WaitForSeconds(time5);
        enemy4.SetActive(false);
        enemy5.SetActive(true);
        item2.SetActive(false);

        yield return new WaitForSeconds(time6);
        enemy5.SetActive(false);
        yield return new WaitForSeconds(5f);
        boss.SetActive(true);
        item3.SetActive(true);

    }
}
