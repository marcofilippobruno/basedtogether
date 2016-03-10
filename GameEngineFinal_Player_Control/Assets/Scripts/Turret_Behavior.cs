using UnityEngine;
using System.Collections;

public class Turret_Behavior : MonoBehaviour {

    private GameObject target = null;
    private GameObject[] targets;
    public GameObject projectile = null;
    private float detectRange = 10f;
    private float distance = 0f;
    private float turnSpeed = 100f;
    private bool canShoot = true;
    private int timer = 0;
	void Start () 
    {
        distance = detectRange;
	}
	
	void FixedUpdate () 
    {
        SearchForTarget();
        AimAtTarget();
        ShootProjectile();
	}
    void SearchForTarget()
    {
        targets = GameObject.FindGameObjectsWithTag( "Player" );
        foreach( GameObject t in targets )
        {
            Vector3 self = new Vector3(transform.position.x,0,transform.position.z);
            Vector3 other = new Vector3(t.transform.position.x,0,t.transform.position.z);
            if( Vector3.Distance( self, other ) < detectRange )
            {
                if( Vector3.Distance( self, other ) < distance )
                {
                    distance = Vector3.Distance( self, other );
                    target = t;
                }
            }
        }
    }
    void AimAtTarget()
    {
        if( target != null )
        {
            Vector3 turretToTarget = target.transform.position - transform.position;

            Quaternion newRot = Quaternion.LookRotation( turretToTarget );

            transform.rotation = Quaternion.RotateTowards( transform.rotation, newRot, turnSpeed * Time.fixedDeltaTime );
            
        }

    }
    void ShootProjectile()
    {
        if( projectile != null && target != null )
        {
            if( canShoot )
            {
                canShoot = false;
                Instantiate( projectile, transform.position, transform.rotation );
            }
            else if( !canShoot )
            {
                if( timer < 1.5 / Time.fixedDeltaTime )
                {
                    timer++;
                }
                else
                {
                    canShoot = true;
                    timer = 0;
                }

            }
        }

    }
}
