﻿using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

    public int whichPlayer = 0;
    public Camera cam = null;
    public GameObject spawnPoint = null;
    private int layerMask;
    private Rigidbody rigid;
    private float m_speed = 8.0f;
    public bool onGround = false;
    private float inputx = 0f;
    private float inputz = 0f;
    private float turnSpeed = 450f;
    public float health = 100f;
    private float maxHealth = 100f;
    private float healAmount = 0.2f;
    public float moveForce = 30f;
    private float maxSpeed = 15f;
    private float upForce = 50f;
    public bool onRamp = false;
    public GameObject tool = null;
    public GameObject rHand = null;
    private int whichTool = 0;
    public int gatherTimer = 0;
    private PlayerInventoryScript inventory;


    void Start ()
    {
        layerMask = 1 << LayerMask.NameToLayer("Terrain");
        rigid = GetComponent<Rigidbody>();
        inventory = GetComponent<PlayerInventoryScript>();
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
            ToolStep(whichPlayer);
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
        float moveX = inputx * moveForce;
        float moveZ = inputz * moveForce;
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
            if (rigid.velocity.magnitude<maxSpeed)
            {
                if (onRamp)
                {
                    rigid.AddForce(new Vector3(moveX, upForce, moveZ));
                }
                else
                {
                    rigid.AddForce(new Vector3(moveX, 0f, moveZ));
                }
            }
        }
        if (!onGround || (onGround && onRamp))
        {
            rigid.AddForce(new Vector3(0f, -30f, 0f));
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

    void ToolStep(int wPlayer)
    {
        if( tool != null )
        {
            tool.transform.position = rHand.transform.position;
            tool.transform.rotation = rHand.transform.rotation;
            if( wPlayer == 1 )
            {
                if( Input.GetKeyDown( KeyCode.F ) )
                {
                    whichTool = 0;
                    tool.GetComponent<Rigidbody>().useGravity = true;
                    tool.GetComponent<Rigidbody>().AddRelativeForce( new Vector3( 8f, 0, 0 ), ForceMode.Impulse );
                    tool.GetComponent<Tool_Behavior>().Throw();
                    tool = null;
                }
            }
            else if( wPlayer == 2 )
            {
                if( Input.GetKeyDown( KeyCode.Joystick1Button3 ) )
                {
                    whichTool = 0;
                    tool.GetComponent<Rigidbody>().useGravity = true;
                    tool.GetComponent<Rigidbody>().AddRelativeForce( new Vector3( 8f, 0, 0 ), ForceMode.Impulse );
                    tool.GetComponent<Tool_Behavior>().Throw();
                    tool = null;
                }
            }

        }
        else
        {
            gatherTimer = 0;
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
        else if (other.CompareTag("Resource"))
        {
            int whichR = other.GetComponent<Resource_Behavior>().whichResource;
            if (whichR==whichTool)
            {
                if (gatherTimer >= 5 / Time.fixedDeltaTime)
                {
                    inventory.GainResource(whichTool, other.GetComponent<Resource_Behavior>().Gathered());
                    gatherTimer = 0;
                }
                else
                {
                    gatherTimer++;
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Resource"))
        {
            gatherTimer = 0;
        }
    }
    void OnCollisionStay(Collision other)
    {
        if (other.collider.CompareTag("Ramp"))
        {
            onRamp = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Ramp"))
        {
            onRamp = false;
        }
    }
    void OnCollisionEnter( Collision other )
    {
        if( other.collider.CompareTag( "Tool" ) )
        {
            if(other.gameObject.GetComponent<Tool_Behavior>().canPickUp()&&tool==null)
            {
                tool = other.gameObject;
                tool.GetComponent<Tool_Behavior>().pickUp();
                whichTool = tool.GetComponent<Tool_Behavior>().whichTool;
                tool.GetComponent<Rigidbody>().useGravity = false;
            }

        }
    }
}
