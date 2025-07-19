using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;

    private GameObject currentEnemy;

    void Update ()
    {
        if ( currentEnemy == null )
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy ()
    {
        currentEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}