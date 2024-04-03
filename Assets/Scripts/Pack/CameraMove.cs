using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // 카메라가 따라다닐 대상(플레이어 등)
    public float cameraSize = 5f; // 카메라의 Size
    public SpriteRenderer backgroundSpriteRenderer; // 배경 스프라이트 렌더러

    private float minCameraX, maxCameraX, minCameraY, maxCameraY;

    void Start()
    {
        // 배경 스프라이트의 영역 계산
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
            // 타겟의 위치를 따라가되 클램핑하여 화면 내에 유지
            float clampedX = Mathf.Clamp(target.position.x, minCameraX, maxCameraX);
            float clampedY = Mathf.Clamp(target.position.y, minCameraY, maxCameraY);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
