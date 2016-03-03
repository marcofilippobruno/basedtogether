using UnityEngine;
using System.Collections;

public class Player_Movement_P2 : MonoBehaviour {

    private int layerMask;
    private Rigidbody rigid;
    private float m_speed = 8.0f;
    public bool onGround = false;
    void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("Terrain");
        rigid = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if (rigid != null)
        {

            PlayerAction();

        }
    }
    void PlayerAction()
    {
        float inputx = Input.GetAxis("Horizontal_P2");
        float inputz = Input.GetAxis("Vertical_P2");
        float moveX = inputx * m_speed * Time.fixedDeltaTime;
        float moveZ = inputz * m_speed * Time.fixedDeltaTime;
        if (RayCast(-1))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
        if (moveX != 0.0f || moveZ != 0.0f)
        {
            transform.Translate(new Vector3(moveX, 0, moveZ));
        }
    }
    bool RayCast(int direction)
    {
        bool hit = Physics.Raycast(rigid.position, direction * Vector3.up, 0.5f + 0.05f, layerMask);
        if (hit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
