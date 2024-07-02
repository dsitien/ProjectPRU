using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapOne : MonoBehaviour
{
    [Header("Enemy Object")]
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
    [SerializeField] GameObject boss;

    [SerializeField] GameObject item;

    [Header("Time Delay")]
    [SerializeField] float time1;
    [SerializeField] float time2;
    [SerializeField] float time3;
    [SerializeField] float time4;
    [SerializeField] float time5;

    [Header("UI Elements")]
    [SerializeField] GameObject instructionPanel;

    [SerializeField] Button playButton;
    private bool gameStarted = false;

    private void Awake()
    {
        enemy1.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);
        boss.SetActive(false);
        item.SetActive(false);

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

        item.SetActive(true);

        yield return new WaitForSeconds(time3);
        enemy2.SetActive(false);
        enemy3.SetActive(true);
        item.SetActive(false);

        yield return new WaitForSeconds(time4);
        enemy3.SetActive(false);
        boss.SetActive(true);

        yield return new WaitForSeconds(20f);
    }
}
