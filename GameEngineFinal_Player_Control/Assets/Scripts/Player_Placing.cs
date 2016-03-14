using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_Placing : MonoBehaviour
{

    public GameObject Placeable;
    public GameObject Placeable2;
    public float ObjectDistance;
    private Rigidbody rigid;
    public GameObject placeLocation = null;
    private GameObject a;
    private bool readytoPlace = false;
    private bool canPlace = true;
    public Material GReen;
    public Material REd;
    private Player_Movement playerM = null;

    // Use this for initialization
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        playerM = GetComponent<Player_Movement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerM.whichPlayer == 1)
        {
            BuildP1();
        }
        else if (playerM.whichPlayer == 2)
        {
            BuildP2();
        }
    }
    void BuildP1()
    {

        if( Input.GetButtonUp( "Fire1" ))
        {
            readytoPlace = !readytoPlace;

            if( placeLocation != null && readytoPlace == true )
            {
                Vector3 placeLoc = placeLocation.transform.position;
                placeLoc.y = 1f;
                a = Instantiate( Placeable, placeLoc, Quaternion.Euler( 270, transform.eulerAngles.y, 0 ) ) as GameObject;
                a.transform.parent = placeLocation.transform;
            }
        }
        if( canPlace == true && Input.GetButtonDown( "Fire2" ) )
        {
            if( placeLocation != null )
            {
                if( a != null )
                {
                    if( a.GetComponent<GreenWallDetect>().canPlace )
                    {
                        Vector3 placeLoc = placeLocation.transform.position;
                        placeLoc.y = 1f;
                        Instantiate( Placeable2, placeLoc, placeLocation.transform.rotation );
                    }
                }

            }

        }
        if( readytoPlace == false )
        {
            Destroy( a );
        }

    }
    void BuildP2()
    {
        if (Input.GetKeyUp(KeyCode.Joystick1Button3))
        {
            readytoPlace = !readytoPlace;

            if (placeLocation != null && readytoPlace == true)
            {
                Vector3 placeLoc = placeLocation.transform.position;
                placeLoc.y = 1f;
                a = Instantiate(Placeable, placeLoc, Quaternion.Euler(270, transform.eulerAngles.y, 0)) as GameObject;
                a.transform.parent = placeLocation.transform;
            }
        }
        if (canPlace == true && Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            if (placeLocation != null)
            {
                if (a != null)
                {
                    if (a.GetComponent<GreenWallDetect>().canPlace)
                    {
                        Vector3 placeLoc = placeLocation.transform.position;
                        placeLoc.y = 1f;
                        Instantiate(Placeable2, placeLoc, placeLocation.transform.rotation);
                    }
                }

            }

        }
        if (readytoPlace == false)
        {
            Destroy(a);
        }
    }



    void OnTriggerEnter( Collider other )
    {
        if( other.CompareTag( "Building" ) )
        {

        }
    }


}