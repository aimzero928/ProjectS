using UnityEngine;

public class CameraFit : MonoBehaviour
{
    public SpriteRenderer sr;

    private void Awake()
    {
        if (sr == null)
        {
            Debug.LogError("Sprite Renderer�� �Ҵ���� �ʾҽ��ϴ�!");
            return;
        }

        float spriteAspectRatio = sr.bounds.size.x / sr.bounds.size.y;
        float screenAspectRatio = (float)Screen.width / Screen.height;

        float cameraSize = Camera.main.orthographicSize;

        if (screenAspectRatio >= spriteAspectRatio)
        {
            // ȭ���� ��������Ʈ���� ���� ���
            float scale = sr.bounds.size.x / (2 * cameraSize * screenAspectRatio);
            transform.localScale = new Vector3(scale, scale, 1f);
        }
        else
        {
            // ȭ���� ��������Ʈ���� �� �� ���
            float scale = sr.bounds.size.y / (2 * cameraSize);
            transform.localScale = new Vector3(scale, scale, 1f);
        }
    }
}
