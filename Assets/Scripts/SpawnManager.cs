using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints; // spawn point들을 저장할 배열
    public GameObject enemyPrefab; // 생성할 적 프리팹
    public float spawnInterval = 2f; // 생성 간격
    public int maxEnemy = 10; // 최대 생성 가능한 적의 수

    private float timer = 0f;

    void Start()
    {
        // 게임 시작 시 spawn point들을 찾아 배열에 추가
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }

    void Update()
    {
        // 현재 생성된 적의 수 추적
        int currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // 최대 생성 가능한 적의 수를 넘지 않으면 생성 가능
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
        // 랜덤하게 spawn point 선택
        int randomIndex = Random.Range(0, spawnPoints.Length);
        GameObject selectedSpawnPoint = spawnPoints[randomIndex];

        // 선택된 spawn point에서 적 생성
        Instantiate(enemyPrefab, selectedSpawnPoint.transform.position, Quaternion.identity);
    }
}
