using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 5;


    Animator anim;
    GameObject structure;
    Walls wall;
    EnemyHealth enemyHealth;
    EnemyMovement enemyM;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        structure = GameObject.FindGameObjectWithTag ("Building");
        wall = structure.GetComponent <Walls> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
        enemyM = GetComponent<EnemyMovement>();
    }

    void OnTriggerEnter (Collider other)
    {
        if (structure != null)
        {
            if (other.gameObject.GetInstanceID() == structure.GetInstanceID())
            {
                playerInRange = true;
            }
        }
    }


    void OnTriggerExit (Collider other)
    {
        if (structure != null)
        {
            if (other.gameObject.GetInstanceID() == structure.GetInstanceID())
            {
                playerInRange = false;
            }
        }
    }


    void FixedUpdate ()
    {
        timer += Time.fixedDeltaTime;
        structure = enemyM.GetTarget();
        if (structure != null)
        {
            wall = structure.GetComponent<Walls>();
        }

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack ();
        }
    }


    void Attack ()
    {
        timer = 0f;

        if( wall.currentWallHealth > 0 )
        {
            wall.TakeDamage (attackDamage);
        }
    }
}
