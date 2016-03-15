using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform structure;
    public GameObject target = null;
    Walls wall;
    EnemyHealth enemyHealth;
    private float dis = 100000f;
    NavMeshAgent nav;
    private Rigidbody rigid = null;
    private EnemyAttack ea;


    void Awake ()
    {
        target = GameObject.FindGameObjectWithTag( "Building" );
        structure = target.transform;
        wall = target.GetComponent <Walls> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
        rigid = GetComponent<Rigidbody>();
        ea = GetComponent<EnemyAttack>();
    }


    void FixedUpdate ()
    {
        if( target != null )
        {
            dis = Vector3.Distance( rigid.transform.position, target.transform.position );
        }
        else
        {
            ea.Reset();
            dis = 100000f;
        }
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Building");
        for(int i = 0; i < targets.Length; i++)
        {
            Vector3 selfLoc = rigid.transform.position;
            selfLoc.y = 0f;
            Vector3 targetLoc = targets[i].transform.position;
            targetLoc.y = 0f;

            if (dis > Vector3.Distance(selfLoc, targetLoc))
            {
                target = targets[i];
                wall = target.GetComponent<Walls>();
                dis = Vector3.Distance( selfLoc, targetLoc );
            }
        }

        if( target != null )
        {
            structure = target.transform;
            if( enemyHealth.currentHealth > 0 && target != null )
            {
                nav.SetDestination( structure.position );
            }
            else
            {
                nav.enabled = false;
            }
        }

        

        
        


    }
    public GameObject GetTarget()
    {
        return target;
    }
}
