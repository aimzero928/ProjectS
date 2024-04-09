using UnityEngine;

public class DragTrail : MonoBehaviour
{
    public GameObject trailPrefab;
    public float maxSpeed = 10f; // 최대 이동 속도

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
            // 터치 위치로 이동
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPosition.z = 0;

            // 현재 시간과 이전 위치를 기반으로 속도 계산
            float distance = Vector3.Distance(touchPosition, previousPosition);
            float deltaTime = Time.time - lastMoveTime;
            float speed = distance / deltaTime;

            // 최대 속도를 초과하면 위치 조정
            if (speed > maxSpeed)
            {
                Vector3 direction = (touchPosition - previousPosition).normalized;
                touchPosition = previousPosition + direction * maxSpeed * deltaTime;
            }

            // Trail 위치 업데이트
            currentTrail.transform.position = touchPosition;
            Debug.Log("Dragging");

            // 위치 및 시간 업데이트
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
        // 해당 오브젝트가 비활성화될 때 모든 trail을 제거
        if (currentTrail != null)
        {
            Destroy(currentTrail);
            Debug.Log("Object Disabled, Destroyed Trail");
        }
    }
}
