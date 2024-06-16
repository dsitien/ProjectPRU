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

    [Header("Time Delay")]
    [SerializeField] float time1;
    [SerializeField] float time2;
    [SerializeField] float time3;
    [SerializeField] float time4;

    [Header("UI Elements")]
    [SerializeField] GameObject instructionPanel; // Panel thông báo
    [SerializeField] Text instructionText; // Text thông báo

    private bool gameStarted = false;

    private void Awake()
    {
        enemy1.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);
        boss.SetActive(false);

        // Hiển thị thông báo nhiệm vụ
        instructionPanel.SetActive(true);
        instructionText.text = "Press any key or click to start the mission!";
        
    }

    private void Update()
    {
        if (!gameStarted && (Input.anyKeyDown || Input.GetMouseButtonDown(0)))
        {
            gameStarted = true;
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

        yield return new WaitForSeconds(time3);
        enemy2.SetActive(false);
        enemy3.SetActive(true);

        yield return new WaitForSeconds(time4);
        enemy3.SetActive(false);
        boss.SetActive(true);

        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene("Level1");
    }
}
