using UnityEngine;

public class DragTrail : MonoBehaviour
{
    public GameObject trailPrefab;
    private GameObject currentTrail;

    private bool isDragging = false;
    private Vector3 touchPosition;

    void Update()
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

    public void OnDragStart()
    {
        isDragging = true;
        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        touchPosition.z = 0;
        currentTrail = Instantiate(trailPrefab, touchPosition, Quaternion.identity);
        Debug.Log("Drag Start");
    }

    public void OnDrag()
    {
        if (currentTrail != null)
        {
            // 터치 위치로 이동
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPosition.z = 0;
            currentTrail.transform.position = touchPosition;
            Debug.Log("Dragging");
        }
    }

    public void OnDragEnd()
    {
        isDragging = false;
        if (currentTrail != null)
        {
            Destroy(currentTrail);
            Debug.Log("Drag End");
        }
    }
}
