using UnityEngine;
using System.Collections;

public class GreenWallDetect : MonoBehaviour {

    public Material[] mat = null;
    private Renderer rend;
    public bool canPlace = false;

	void Start () 
    {
        rend = GetComponent<Renderer>();
	}

    void OnTriggerStay( Collider other )
    {
        if( mat != null )
        {
            if( other.CompareTag( "Building" ) )
            {
                if( rend.material != mat[1] )
                {
                    rend.material = mat[1];
                }
                if( canPlace )
                {
                    canPlace = false;
                }
            }
        }

    }
    void OnTriggerExit( Collider other )
    {
        if( mat != null )
        {
            if( other.CompareTag( "Building" ) )
            {
                if( rend.material != mat[0] )
                {
                    rend.material = mat[0];
                }
                if( !canPlace )
                {
                    canPlace = true;
                }
            }
        }
    }

}
