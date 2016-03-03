using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public GameObject target = null;
    private float height = 10f;
	void Start () 
    {
	
	}
	
	void FixedUpdate () 
    {
        if( target != null )
        {
            transform.position = new Vector3( target.transform.position.x, target.transform.position.y + height, target.transform.position.z - height );
            
        }
	}
}
