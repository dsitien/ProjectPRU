using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoss : MonoBehaviour
{
    public GameObject gameLossPanel;
    public string map;

    private void Awake()
    {
        gameLossPanel.SetActive(false);
    }

    public void ShowGameLossPanel()
    {
        gameLossPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TriggerGameLossPanelWithDelay(float delay)
    {
        StartCoroutine(ShowGameLossPanelAfterDelay(delay));
    }

    private IEnumerator ShowGameLossPanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ShowGameLossPanel();
    }

    public void Retry()
    {
        SceneManager.LoadScene(map);
        Time.timeScale = 1f;
    }
}
