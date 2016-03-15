using UnityEngine;
using System.Collections;

public class Turret_Behavior : MonoBehaviour {

    private GameObject target = null;
    private GameObject[] targets;
    public GameObject projectile = null;
    public GameObject bulletSpawnPoint = null;
    private float detectRange = 20f;
    private float distance = 0f;
    private float turnSpeed = 200f;
    private bool canShoot = false;
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
        targets = GameObject.FindGameObjectsWithTag("Enemy");
        for( int i = 0; i < targets.Length; i++ )
        {
            Vector3 self = new Vector3( transform.position.x, 0, transform.position.z );
            Vector3 other = new Vector3( targets[i].transform.position.x, 0, targets[i].transform.position.z );
            if( Vector3.Distance( self, other ) < detectRange )
            {
                distance = Vector3.Distance( self, other );
                target = targets[i];
            }
        }
    }
    void AimAtTarget()
    {
        if( target != null)
        {
            Vector3 self = new Vector3(transform.position.x,0,transform.position.z);
            Vector3 other = new Vector3(target.transform.position.x,0,target.transform.position.z);
            if( Vector3.Distance( self, other ) < detectRange )
            {
                Vector3 turretToTarget = target.transform.position - transform.position;
                Quaternion newRot = Quaternion.LookRotation( turretToTarget );
                transform.rotation = Quaternion.RotateTowards( transform.rotation, newRot, turnSpeed * Time.fixedDeltaTime );
            }
            else
            {
                canShoot = false;
            }
        }
        else
        {
            Quaternion newRot = Quaternion.LookRotation(Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRot, turnSpeed * Time.fixedDeltaTime);
        }

    }
    void ShootProjectile()
    {
        if( projectile != null && target != null )
        {
            if( canShoot )
            {
                canShoot = false;
                Instantiate( projectile, bulletSpawnPoint.transform.position, transform.rotation );
            }
            else if( !canShoot )
            {
                if( timer < 0.3 / Time.fixedDeltaTime )
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
