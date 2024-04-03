using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 3f; // 몬스터의 이동 속도
    private Rigidbody2D rb; // 몬스터의 Rigidbody2D 컴포넌트
    private GameObject player; // 플레이어 오브젝트를 저장할 변수

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player"); // 씬에서 "Player"라는 이름의 게임 오브젝트 찾기
        if (player == null)
        {
            Debug.LogError("Player not found in the scene!");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // 몬스터가 플레이어를 향해 이동하도록 함
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
    }
}
