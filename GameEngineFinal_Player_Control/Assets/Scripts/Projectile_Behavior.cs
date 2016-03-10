using UnityEngine;
using System.Collections;

public class Projectile_Behavior : MonoBehaviour {

    private Rigidbody rigid;
    private float speed = 20f;


	void Start () 
    {
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce( rigid.transform.forward * speed, ForceMode.Impulse );
	}
	
	void FixedUpdate () 
    {
	    
	}
}
