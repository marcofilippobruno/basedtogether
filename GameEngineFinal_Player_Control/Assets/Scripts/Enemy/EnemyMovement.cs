using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform structure;
    GameObject target = null;
    Walls wall;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;


    void Awake ()
    {
        target = GameObject.FindGameObjectWithTag( "Building" );
        structure = target.transform;
        wall = target.GetComponent <Walls> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
    }


    void Update ()
    {
        if(enemyHealth.currentHealth > 0 && wall.currentWallHealth > 0)
        {
            nav.SetDestination (structure.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
