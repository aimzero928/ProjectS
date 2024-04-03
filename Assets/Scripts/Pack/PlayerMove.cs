using UnityEngine;

public class Players : MonoBehaviour
{
    public VariableJoystick joy;
    public float speed;

    Rigidbody rigid;
    Animator anim;
    Vector3 moveVec;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        // 1. Input Value
        float x = joy.Horizontal;
        float z = joy.Vertical;

        // 2. Move Position 
        moveVec = new Vector3(x, 0, z) * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);
    }
}