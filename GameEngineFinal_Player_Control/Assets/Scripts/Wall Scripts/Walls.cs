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
    public int whichBuilding = 0;

    public int[] buildReq = new int[3];
     

	// Use this for initialization
	void Start () {

        currentState = 0;

        meshCollider = GetComponent<MeshCollider>();

	}
	
	// Update is called once per frame // 
	void FixedUpdate () {
        if( currentWallHealth <= 0 )
        {
            Destroy( gameObject );
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
        else
        {
            // destroy structure
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
