using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkinAll : MonoBehaviour
{
    public ShipChangeSkin ship; // Tham chiếu tới ShipChangeSkin
    public GameObject skin;
    private void Awake()
    {
      
        skin.SetActive(false);
    }
    public void ChangeBulletAndShipSkin(int skinIndex)
    {
        if (ship != null)
        {
            ship.ChangeShipSkin(skinIndex);
        }
        else
        {
            Debug.LogError("ShipChangeSkin reference is missing in ChangeSkinAll script.");
        }
    }
    public void TurnOn()
    {
        skin.SetActive(true);
    }
    public void Close()
    {
        skin.SetActive(false );
    }
}
