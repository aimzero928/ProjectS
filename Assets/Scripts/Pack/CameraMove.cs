using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // ī�޶� ����ٴ� ���(�÷��̾� ��)
    public float cameraSize = 5f; // ī�޶��� Size
    public SpriteRenderer backgroundSpriteRenderer; // ��� ��������Ʈ ������

    private float minCameraX, maxCameraX, minCameraY, maxCameraY;

    void Start()
    {
        // ��� ��������Ʈ�� ���� ���
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        minCameraX = backgroundSpriteRenderer.bounds.min.x + horzExtent;
        maxCameraX = backgroundSpriteRenderer.bounds.max.x - horzExtent;
        minCameraY = backgroundSpriteRenderer.bounds.min.y + vertExtent;
        maxCameraY = backgroundSpriteRenderer.bounds.max.y - vertExtent;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Ÿ���� ��ġ�� ���󰡵� Ŭ�����Ͽ� ȭ�� ���� ����
            float clampedX = Mathf.Clamp(target.position.x, minCameraX, maxCameraX);
            float clampedY = Mathf.Clamp(target.position.y, minCameraY, maxCameraY);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
