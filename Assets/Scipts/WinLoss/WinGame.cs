using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class WinGame : MonoBehaviour
{
    public GameObject winGamePanel;
    public Text scoretxt; 
    public Text timetxt; 
    public Text bosstxt;
    public string map;
    public int requiredScore; 
    public float maxTime; 
    private int playerScore;
    public Button next;

    private void Start()
    {
        winGamePanel.SetActive(false);
        next.gameObject.SetActive(false);
        next.onClick.AddListener(OnNextButtonClick);
    }

    public void ShowWinGamePanel()
    {
        winGamePanel.SetActive(true);
        Time.timeScale = 0f;
        bosstxt.color = Color.green;
        // Lấy điểm người chơi từ một script khác (nếu cần)
        playerScore = FindObjectOfType<ScoreManager>().GetScore();

        // Kiểm tra thời gian và cập nhật màu sắc văn bản
        float elapsedTime = Timer.instance.GetElapsedTime();

        if(elapsedTime > maxTime)
        {
            timetxt.color = Color.red;
        }
        if(playerScore < requiredScore)
        {
            scoretxt.color = Color.red;
        }
        if (playerScore >= requiredScore)
        {
           
            scoretxt.color = Color.green;
        }
        if (elapsedTime <= maxTime)
        {
            timetxt.color = Color.green;
        }

        if (playerScore >= requiredScore && elapsedTime <= maxTime)
        {
            next.gameObject.SetActive(true);
        }
        else
        {
            next.gameObject.SetActive(false);
        }

    }

    public void TriggerWinGamePanelWithDelay(float delay)
    {
        StartCoroutine(ShowWinGamePanelAfterDelay(delay));
    }

    private IEnumerator ShowWinGamePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ShowWinGamePanel();
    }

    private void OnNextButtonClick()
    {
        SceneManager.LoadScene(map);
        Time.timeScale = 1f;
    }
}
