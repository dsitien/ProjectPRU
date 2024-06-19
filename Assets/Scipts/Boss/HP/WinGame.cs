using System.Collections;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameObject winGamePanel;

    private void Awake()
    {
        winGamePanel.SetActive(false);
    }

    public void ShowWinGamePanel()
    {
        winGamePanel.SetActive(true);
        Time.timeScale = 0f;
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
}
