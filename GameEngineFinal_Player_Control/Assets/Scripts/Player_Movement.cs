using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

    public int whichPlayer = 0;
    private int layerMask;
    private Rigidbody rigid;
    private float m_speed = 8.0f;
    public bool onGround = false;
    private float inputx = 0f;
    private float inputz = 0f;
    void Start ()
    {
        layerMask = 1 << LayerMask.NameToLayer("Terrain");
        rigid = GetComponent<Rigidbody>();
    }
	

	void FixedUpdate ()
    {
        if (rigid != null)
        {

            PlayerAction();
            Rotation();

        }
    }
    void PlayerAction()
    {
        if( whichPlayer == 1 )
        {
            inputx = Input.GetAxis( "Horizontal_P1" );
            inputz = Input.GetAxis( "Vertical_P1" );
        }
        else if( whichPlayer == 2 )
        {
            inputx = Input.GetAxis( "Horizontal_P2" );
            inputz = Input.GetAxis( "Vertical_P2" );
        }
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
            transform.Translate(new Vector3(moveX, 0, moveZ),Space.World);

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
    void Rotation()
    {
        if( whichPlayer == 2 )
        {
            float rh = Input.GetAxis( "R_Joy_H" );
            float rv = Input.GetAxis( "R_Joy_V" );
            transform.Rotate( new Vector3( 0f, rh * 5, 0f ) );
        }
        else if( whichPlayer == 1 )
        {
            float rh = 0f;
            if( Input.GetKey( KeyCode.RightArrow ) )
            {
                rh = 5f;
            }
            else if( Input.GetKey( KeyCode.LeftArrow ) )
            {
                rh = -5f;
            }
            transform.Rotate( new Vector3( 0f, rh, 0f ) );
        }

    }
}
