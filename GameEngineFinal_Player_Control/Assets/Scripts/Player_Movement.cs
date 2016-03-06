using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

    public int whichPlayer = 0;
    public Camera cam = null;
    public GameObject spawnPoint = null;
    private int layerMask;
    private Rigidbody rigid;
    private float m_speed = 8.0f;
    private bool onGround = false;
    private float inputx = 0f;
    private float inputz = 0f;
    private float turnSpeed = 450f;
    public float health = 100f;
    private float maxHealth = 100f;
    private float healAmount = 0.2f;
   

    void Start ()
    {
        layerMask = 1 << LayerMask.NameToLayer("Terrain");
        rigid = GetComponent<Rigidbody>();
    }
	

	void FixedUpdate ()
    {
        if (rigid != null)
        {
            if (Input.GetKey(KeyCode.P))
            {
                health -= 0.5f;
            }
            PlayerAction();
            Rotation();
            CheckHealth();
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
    void CheckHealth()
    {
        if (spawnPoint != null)
        {
            if (health <= 0f)
            {
                health = 100f;
                rigid.transform.position = new Vector3(spawnPoint.transform.position.x, 1f, spawnPoint.transform.position.z);
            }
        }
        if (health > maxHealth)
        {
            health = maxHealth;
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
            P2Turn();
        }
        else if( whichPlayer == 1 )
        {
            P1Turn();
        }

    }
    void P1Turn()
    {
        if(cam!=null)
        {
            Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit floorHit;

            if (Physics.Raycast(camRay, out floorHit, 200f, layerMask))
            {
                Vector3 playerToMouse = floorHit.point - transform.position;
                playerToMouse.y = 0f;

                Quaternion newRot = Quaternion.LookRotation(playerToMouse);

                rigid.rotation = Quaternion.RotateTowards(rigid.rotation, newRot, turnSpeed * Time.fixedDeltaTime);
            }
        }
    }
    void P2Turn()
    {
        float rh = Input.GetAxis("R_Joy_H") * 5f;
        float rv = Input.GetAxis("R_Joy_V") * 5f;

        if(rh!=0||rv!=0)
        {
            Vector3 targetPos = new Vector3(rigid.position.x+rh,rigid.position.y,rigid.position.z+rv);
            Quaternion targetRot = Quaternion.LookRotation(targetPos - rigid.transform.position, Vector3.up);
            rigid.rotation = Quaternion.RotateTowards(rigid.rotation, targetRot, turnSpeed * Time.fixedDeltaTime);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("HealVolume"))
        {
            if (health < maxHealth)
            {
                health += healAmount;
            }
        }
    }
}
