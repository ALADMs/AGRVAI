using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDoInimigo : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab do inimigo a ser spawnado
    public float spawnInterval = 2f; // Intervalo de tempo entre os spawns
    public Vector2 spawnAreaSize = new Vector2(5f, 5f); // Tamanho da área de spawn

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(
            transform.position.x + Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            transform.position.y + Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
        );

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
