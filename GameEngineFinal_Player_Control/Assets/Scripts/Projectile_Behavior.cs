using UnityEngine;
using System.Collections;

public class Projectile_Behavior : MonoBehaviour {

    private Rigidbody rigid;
    private float speed = 20f;
    private int dmg = 20;


	void Start () 
    {
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce( rigid.transform.forward * speed, ForceMode.Impulse );
	}
	
	void FixedUpdate () 
    {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(dmg);
            Destroy(gameObject);
        }
    }
}
