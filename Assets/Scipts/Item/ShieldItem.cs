using System.Collections;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
  

    private void Start()

    {
        gameObject.SetActive(false);
      
    }

    private void Update()
    {
        Shield();
    }

    void Shield()
    {
        StartCoroutine(ActiveShield());
        StopCoroutine(ActiveShield());
        gameObject.SetActive(true);

    }
    IEnumerator ActiveShield()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(5f);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
