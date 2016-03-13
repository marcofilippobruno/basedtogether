using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform structure;
    GameObject target = null;
    Walls wall;
    EnemyHealth enemyHealth;
    private float dis = 100000f;
    NavMeshAgent nav;



    void Awake ()
    {
        target = GameObject.FindGameObjectWithTag( "Building" );
        structure = target.transform;
        wall = target.GetComponent <Walls> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
    }


    void FixedUpdate ()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Building");
        for(int i = 0; i < targets.Length; i++)
        {
            Vector3 selfLoc = transform.position;
            selfLoc.y = 0f;
            Vector3 targetLoc = targets[i].transform.position;
            targetLoc.y = 0f;
            if (dis > Vector3.Distance(selfLoc, targetLoc))
            {
                dis = Vector3.Distance(selfLoc, targetLoc);
                target = targets[i];
            }
        }
        structure = target.transform;
        if (target != null)
        {
            if (enemyHealth.currentHealth > 0 && wall.currentWallHealth > 0)
            {
                nav.SetDestination(structure.position);
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
