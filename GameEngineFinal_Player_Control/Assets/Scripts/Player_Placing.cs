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

    // Use this for initialization
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Build();
    }
    void Build()
    {

        if( Input.GetButtonUp( "Fire1" ) )
        {
            readytoPlace = !readytoPlace;

            if( placeLocation != null && readytoPlace == true )
            {
                a = Instantiate( Placeable, placeLocation.transform.position, Quaternion.Euler( 270, transform.eulerAngles.y, 0 ) ) as GameObject;
                a.transform.parent = placeLocation.transform;
            }
        }



        if( canPlace == true && Input.GetButtonDown( "Fire2" ) )
        {
            if( placeLocation != null )
            {
                Instantiate( Placeable2, placeLocation.transform.position, placeLocation.transform.rotation );
            }

        }

        if( readytoPlace == false )
        {
            Destroy( a );
        }

    }



    void OnTriggerEnter( Collider col )
    {
        if( col.gameObject.tag == "Building" )
        {
            Renderer rend = col.gameObject.GetComponent<Renderer>();
            rend.material = REd;
            Debug.Log( "Building" );
        }
        if( col.gameObject.tag != "Building" )
        {
            Renderer rend = col.gameObject.GetComponent<Renderer>();
            rend.material = GReen;
            canPlace = true;
        }
    }


}