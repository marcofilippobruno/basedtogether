using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour {

    public int maxWallHealth;
    public int currentWallHealth;

    public int currentState;
    public int upgradeOneHealth;
    public int upgradeTwoHealth;

    public int[] repairReq = new int[3];
    public int[] upgradeReq = new int[3];

    public int repairAmount;
    private Collider meshCollider;

    public GameObject attacker = null;

	// Use this for initialization
	void Start () {

        currentState = 0;

        meshCollider = GetComponent<MeshCollider>();

	}

    void Update()
    {
        if( currentWallHealth <= 0 )
        {
            //Destroy( gameObject );
            if( gameObject.activeSelf )
            {
                Debug.Log( "deactive" );
                //attacker.GetComponent<EnemyMovement>().dis = 100000f;
                gameObject.SetActive( false );
            }
        }
    }

    // destroy wall if less than 0 hp, else, damage it by damage // 
    public void TakeDamage(int damage){
        //Debug.Log( "Im being called" );

        if (currentWallHealth>=0)
        {
            //Debug.Log( "Im being called because i have health" );
            currentWallHealth -= damage;
        }
    }

    // repair 
    public void Repaired()
    {
        //Debug.Log( "rep" + repairAmount );
        // if can be repaired at all
        if( currentWallHealth < maxWallHealth )
        {
            // repair
            currentWallHealth += repairAmount;
            if( currentWallHealth > maxWallHealth )
            {
                currentWallHealth = maxWallHealth;
            }
      
        }
    }

    // upgrade
    public void Upgrade(int state){

        // if being upgraded to state 1
        if( state == 0 )
        {
            maxWallHealth = upgradeOneHealth;
            currentWallHealth = upgradeOneHealth;
            currentState++;

        }
        // if being upgraded to state 2
        else if( state == 1 )
        {
            maxWallHealth = upgradeTwoHealth;
            currentWallHealth = upgradeTwoHealth;
            currentState++;
        }
        // if can't be upgraded
        else if (state > 1) {
            currentWallHealth = maxWallHealth;
        }
    }

}
