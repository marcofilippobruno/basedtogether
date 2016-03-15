using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_Placing : MonoBehaviour
{
    public GameObject[] place1 = null;
    private GameObject[,] Placeable = new GameObject[2,2];
    private int placeableIndex = 0;
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
        int id=0;
        if( place1 != null )
        {
            for( int i = 0; i < place1.Length / 2; i++ )
            {
                for( int t = 0; t < place1.Length / 2; t++ )
                {
                    Placeable[i, t] = place1[id];
                    id++;
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if( Input.GetKeyUp( KeyCode.C ) )
        {
            if( placeableIndex == 0 )
            {
                placeableIndex = 1;
                if( a != null )
                {
                    Destroy( a );
                    Vector3 placeLoc = placeLocation.transform.position;
                    a = Instantiate( Placeable[placeableIndex, 0], placeLoc, Quaternion.Euler( 270, transform.eulerAngles.y, 0 ) ) as GameObject;
                    a.transform.parent = placeLocation.transform;
                }
            }
            else if( placeableIndex == 1 )
            {
                placeableIndex = 0;
                if( a != null )
                {
                    Destroy( a );
                    Vector3 placeLoc = placeLocation.transform.position;
                    a = Instantiate( Placeable[placeableIndex, 0], placeLoc, Quaternion.Euler( 270, transform.eulerAngles.y, 0 ) ) as GameObject;
                    a.transform.parent = placeLocation.transform;
                }
            }
        }
        if (playerM.whichPlayer == 1)
        {
            BuildP1();
        }
        else if (playerM.whichPlayer == 2)
        {
            //BuildP2();
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
                a = Instantiate( Placeable[placeableIndex,0], placeLoc, Quaternion.Euler( 270, transform.eulerAngles.y, 0 ) ) as GameObject;
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
                        Instantiate( Placeable[placeableIndex, 1], placeLoc, placeLocation.transform.rotation );
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
                a = Instantiate( Placeable[0,0], placeLoc, Quaternion.Euler( 270, transform.eulerAngles.y, 0 ) ) as GameObject;
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
                        Instantiate( Placeable[0,0], placeLoc, placeLocation.transform.rotation );
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