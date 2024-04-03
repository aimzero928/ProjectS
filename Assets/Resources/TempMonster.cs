using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 3f; // ������ �̵� �ӵ�
    private Rigidbody2D rb; // ������ Rigidbody2D ������Ʈ
    private GameObject player; // �÷��̾� ������Ʈ�� ������ ����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player"); // ������ "Player"��� �̸��� ���� ������Ʈ ã��
        if (player == null)
        {
            Debug.LogError("Player not found in the scene!");
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            // ���Ͱ� �÷��̾ ���� �̵��ϵ��� ��
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
    }
}
