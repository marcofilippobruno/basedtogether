using UnityEngine;
using System.Collections;

public class Player_Placing : MonoBehaviour {

    public Transform Placeable;
    public float ObjectDistance_notworking;

	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
        Build();
	}

    void Build()
    {    
        if( Input.GetButtonDown( "Fire1" ) )
        {
            Instantiate( Placeable, transform.position, Quaternion.Euler( 270, transform.eulerAngles.y, 0 ) );
        }

    }

}
