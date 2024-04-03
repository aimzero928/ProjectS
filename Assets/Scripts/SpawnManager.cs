using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints; // spawn point���� ������ �迭
    public GameObject enemyPrefab; // ������ �� ������
    public float spawnInterval = 2f; // ���� ����
    public int maxEnemy = 10; // �ִ� ���� ������ ���� ��

    private float timer = 0f;

    void Start()
    {
        // ���� ���� �� spawn point���� ã�� �迭�� �߰�
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }

    void Update()
    {
        // ���� ������ ���� �� ����
        int currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // �ִ� ���� ������ ���� ���� ���� ������ ���� ����
        if (currentEnemyCount < maxEnemy)
        {
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                SpawnEnemy();
                timer = 0f;
            }
        }
    }

    void SpawnEnemy()
    {
        // �����ϰ� spawn point ����
        int randomIndex = Random.Range(0, spawnPoints.Length);
        GameObject selectedSpawnPoint = spawnPoints[randomIndex];

        // ���õ� spawn point���� �� ����
        Instantiate(enemyPrefab, selectedSpawnPoint.transform.position, Quaternion.identity);
    }
}
