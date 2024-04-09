using UnityEngine;

public class CameraFit : MonoBehaviour
{
    public SpriteRenderer sr;

    private void Awake()
    {
        if (sr == null)
        {
            Debug.LogError("Sprite Renderer가 할당되지 않았습니다!");
            return;
        }

        float spriteAspectRatio = sr.bounds.size.x / sr.bounds.size.y;
        float screenAspectRatio = (float)Screen.width / Screen.height;

        float cameraSize = Camera.main.orthographicSize;

        if (screenAspectRatio >= spriteAspectRatio)
        {
            // 화면이 스프라이트보다 넓은 경우
            float scale = sr.bounds.size.x / (2 * cameraSize * screenAspectRatio);
            transform.localScale = new Vector3(scale, scale, 1f);
        }
        else
        {
            // 화면이 스프라이트보다 더 긴 경우
            float scale = sr.bounds.size.y / (2 * cameraSize);
            transform.localScale = new Vector3(scale, scale, 1f);
        }
    }
}
