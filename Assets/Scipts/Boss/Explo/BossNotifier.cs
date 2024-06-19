using UnityEngine;

public class BossNotifier : MonoBehaviour
{
    private void OnDestroy()
    {
        // Find the WinGame script and call TriggerWinGamePanelWithDelay
        WinGame winGameScript = FindObjectOfType<WinGame>();
        if (winGameScript != null)
        {
            winGameScript.TriggerWinGamePanelWithDelay(2f);
        }
    }
}
