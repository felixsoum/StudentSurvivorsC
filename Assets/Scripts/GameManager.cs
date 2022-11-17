using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mermanPrefab;
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] GameObject bossPrefab;
    [SerializeField] GameObject giantPrefab;
    [SerializeField] float spawnRadius = 5f;
    [SerializeField] TMP_Text timeText;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnEnemyCoroutine());
    }

    private void Update()
    {
        timeText.text = Mathf.FloorToInt(Time.time).ToString();
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            SpawnEnemies(zombiePrefab, 5);
            yield return new WaitForSeconds(5);
            SpawnEnemies(giantPrefab, 2);
            //SpawnEnemies(bossPrefab, 1);
            yield return new WaitForSeconds(5);
            SpawnEnemies(zombiePrefab, 5);
            SpawnEnemies(mermanPrefab, 5);
            yield return new WaitForSeconds(5);
            SpawnEnemies(mermanPrefab, 10);
            yield return new WaitForSeconds(10);
        }

        //yield return StartCoroutine(SpawnEnemyCoroutine());
    }

    private void SpawnEnemies(GameObject prefab, int n)
    {
        for (int i = 0; i < n; i++)
        {
            Vector2 pointOnCircle = UnityEngine.Random.insideUnitCircle.normalized;
            pointOnCircle *= spawnRadius;

            Vector3 spawnPos = player.transform.position;
            spawnPos.x += pointOnCircle.x;
            spawnPos.y += pointOnCircle.y;

            Instantiate(prefab, spawnPos, Quaternion.identity);
        }
    }
}
