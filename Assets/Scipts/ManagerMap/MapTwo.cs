using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTwo : MonoBehaviour
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

    private void Awake()
    {
        enemy1.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);
        boss.SetActive(false);
    }
    private IEnumerator Start()
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
    }
}
