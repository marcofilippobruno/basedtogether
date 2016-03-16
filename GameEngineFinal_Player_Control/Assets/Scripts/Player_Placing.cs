using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_Placing : MonoBehaviour
{
    public GameObject[] place1 = null;
    private GameObject[,] Placeable = new GameObject[3,2];
    private int placeableIndex = 0;
    public float ObjectDistance;
    private Rigidbody rigid;
    public GameObject placeLocation = null;
    public GameObject a;
    private bool readytoPlace = false;
    private bool canPlace = true;
    public Material GReen;
    public Material REd;
    private Player_Movement playerM = null;
    public GameObject turretPrefab = null;
    public GameObject turretPrefab2 = null;
    private GameObject turret = null;
    private bool showTurret = false;
    private Vector3 turretLoc;
    private Stone_Wall stoneWall = null;
    private PlayerInventoryScript inventory;
    private Stone_Wall sw = new Stone_Wall();
    private Wood_Wall ww = new Wood_Wall();
    private Stone_Wall tower = new Stone_Wall();
    // Use this for initialization
    void Awake()
    {
        sw.whichBuilding = 1;
        sw.Init();
        tower.whichBuilding = 2;
        tower.Init();
        ww.Init();
        rigid = GetComponent<Rigidbody>();
        playerM = GetComponent<Player_Movement>();
        inventory = GetComponent<PlayerInventoryScript>();
        int id=0;
        if( place1 != null )
        {
            for( int i = 0; i < 3; i++ )
            {
                for( int t = 0; t < 2; t++ )
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
                placeableIndex = 2;
                if( a != null )
                {
                    Destroy( a );
                    Vector3 placeLoc = placeLocation.transform.position;
                    a = Instantiate( Placeable[placeableIndex, 0], placeLoc, Quaternion.Euler( 270, transform.eulerAngles.y, 0 ) ) as GameObject;
                    a.transform.parent = placeLocation.transform;
                }
            }
            else if( placeableIndex == 2 )
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
        if( Input.GetButtonUp( "Fire1" ) && canPlace )
        {
            readytoPlace = !readytoPlace;

            if( placeLocation != null && readytoPlace == true )
            {
                Vector3 placeLoc = placeLocation.transform.position;
                placeLoc.y = 1f;
                a = Instantiate( Placeable[placeableIndex, 0], placeLoc, Quaternion.Euler( 270, transform.eulerAngles.y, 0 ) ) as GameObject;
                a.transform.parent = placeLocation.transform;
            }
        }
        if( Input.GetButtonDown( "Fire2" ) )
        {
            if( placeLocation != null )
            {
                if( a != null )
                {
                    if( a.GetComponent<GreenWallDetect>().canPlace )
                    {
                        if( placeableIndex == 0 )
                        {
                            if( inventory.CanBuildWall( sw ) )
                            {
                                inventory.BuildStoneWall(sw);
                                BuildWall();
                            }
                        }
                        else if( placeableIndex == 1 )
                        {
                            if( inventory.CanBuildWall( sw ) )
                            {
                                inventory.BuildStoneWall( sw );
                                BuildWall();
                            }
                        }
                        else if( placeableIndex == 2 )
                        {
                            if( inventory.CanBuildWall( ww ) )
                            {
                                inventory.BuildWoodWall( ww );
                                BuildWall();
                            }
                        }

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
        readytoPlace = true;
        if( showTurret && stoneWall.GetTurret())
        {
            if( turret == null )
            {
                Vector3 placeLoc = turretLoc;
                placeLoc.y = 5f;
                turret = Instantiate( turretPrefab, placeLoc, Quaternion.Euler( 0, 0, 0 ) ) as GameObject;
                canPlace = true;
            }

        }
        else
        {
            if( turret != null )
            {
                Destroy( turret );
            }
        }
        if (Input.GetKeyUp(KeyCode.Joystick1Button0)&&inventory.CanBuildTurret())
        {
            if( showTurret )
            {
                if( stoneWall.GetTurret() )
                {
                    inventory.BuildTurret();
                    stoneWall.CreateTurret( turretPrefab2 );
                }
            }

        }
        if (readytoPlace == false)
        {
            Destroy(turret);
        }
    }

    void BuildWall()
    {
        Vector3 placeLoc = placeLocation.transform.position;
        placeLoc.y = 1f;
        Instantiate( Placeable[placeableIndex, 1], placeLoc, placeLocation.transform.rotation );
    }

    void OnTriggerStay( Collider other )
    {
        if( playerM.whichPlayer == 2 )
        {
            if( other.CompareTag( "Building" ) )
            {
                if( other.GetComponent<Stone_Wall>()!=null )
                {
                    if( other.GetComponent<Stone_Wall>().whichBuilding == 2 )
                    {
                        showTurret = true;
                        turretLoc = other.transform.position;
                        stoneWall = other.GetComponent<Stone_Wall>();
                    }
                }

            }
        }
    }
    void OnTriggerExit( Collider other )
    {
        if( playerM.whichPlayer == 2 )
        {
            if( other.CompareTag( "Building" ) )
            {
                if( other.GetComponent<Stone_Wall>() != null )
                {
                    if( other.GetComponent<Stone_Wall>().whichBuilding == 2 )
                    {
                        showTurret = false;
                    }
                }

            }
        }
    }

}