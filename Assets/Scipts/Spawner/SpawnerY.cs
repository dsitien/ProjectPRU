using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerY : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int maxEnemy = 10;
    [SerializeField] private float timeMin = 0.2f;
    [SerializeField] private float timeMax = 0.8f;
    private int enemiesSpawned = 0;
    private BoxCollider2D boxCollider;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        StartCoroutine(SpawnerEnemy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnerEnemy()
    {
        while (enemiesSpawned < maxEnemy)
        {
            if (enemy == null)
            {
                yield break;
            }
            yield return new WaitForSeconds(Random.Range(timeMin, timeMax));
            float minY = -boxCollider.bounds.size.y / 2f;
            float maxY = boxCollider.bounds.size.y / 2f;

            Vector3 spawnPosition = transform.position;
            spawnPosition.y = Random.Range(minY, maxY);

            Instantiate(enemy, spawnPosition, Quaternion.identity);
            enemiesSpawned++;
        }
    }
}
