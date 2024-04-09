using UnityEngine;

public class DragTrail : MonoBehaviour
{
    public GameObject trailPrefab;
    public float maxSpeed = 10f; // �ִ� �̵� �ӵ�

    private GameObject currentTrail;
    private bool isDragging = false;
    private Vector3 touchPosition;
    private Vector3 previousPosition;
    private float lastMoveTime;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnDragStart();
        }
        else if (Input.GetMouseButton(0))
        {
            if (isDragging)
            {
                OnDrag();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                OnDragEnd();
            }
        }
    }

    private void OnDragStart()
    {
        isDragging = true;
        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        touchPosition.z = 0;
        currentTrail = Instantiate(trailPrefab, touchPosition, Quaternion.identity);
        Debug.Log("Drag Start");

        lastMoveTime = Time.time;
        previousPosition = touchPosition;
    }

    private void OnDrag()
    {
        if (currentTrail != null)
        {
            // ��ġ ��ġ�� �̵�
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPosition.z = 0;

            // ���� �ð��� ���� ��ġ�� ������� �ӵ� ���
            float distance = Vector3.Distance(touchPosition, previousPosition);
            float deltaTime = Time.time - lastMoveTime;
            float speed = distance / deltaTime;

            // �ִ� �ӵ��� �ʰ��ϸ� ��ġ ����
            if (speed > maxSpeed)
            {
                Vector3 direction = (touchPosition - previousPosition).normalized;
                touchPosition = previousPosition + direction * maxSpeed * deltaTime;
            }

            // Trail ��ġ ������Ʈ
            currentTrail.transform.position = touchPosition;
            Debug.Log("Dragging");

            // ��ġ �� �ð� ������Ʈ
            previousPosition = touchPosition;
            lastMoveTime = Time.time;
        }
    }

    private void OnDragEnd()
    {
        isDragging = false;
        if (currentTrail != null)
        {
            Destroy(currentTrail);
            Debug.Log("Drag End");
        }
    }

    private void OnDisable()
    {
        // �ش� ������Ʈ�� ��Ȱ��ȭ�� �� ��� trail�� ����
        if (currentTrail != null)
        {
            Destroy(currentTrail);
            Debug.Log("Object Disabled, Destroyed Trail");
        }
    }
}
