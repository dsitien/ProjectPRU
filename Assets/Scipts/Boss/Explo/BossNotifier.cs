using UnityEngine;

public class BossNotifier : MonoBehaviour
{
    public bool enableNotifier = true;

    private void OnDestroy()
    {
        if (enableNotifier)
        {
            // Tìm script WinGame và gọi hàm TriggerWinGamePanelWithDelay
            WinGame winGameScript = FindObjectOfType<WinGame>();
            if (winGameScript != null)
            {
                winGameScript.TriggerWinGamePanelWithDelay(2f);
            }
            else
            {
                Debug.LogWarning("WinGame script not found in the scene.");
            }
        }
    }
}
