using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour {

    public int maxWallHealth;
    public int currentWallHealth;

    public int currentState;
    public int woodReq;
    public int rockReq;
    public int mudReq;

    private int playerWood;
    private int playerRock;
    private int playerMud;

    public int[] repairReq = new int[3];
    public int[] upgradeReq = new int[3];

    private int fullyUpgraded = 2;
    private int repairAmount = 25;
    private Collider meshCollider;


	// Use this for initialization
	void Start () {

        meshCollider = GetComponent<MeshCollider>();

	}
	
	// Update is called once per frame // 
	void FixedUpdate () {

	}

    // destroy wall if less than 0 hp, else, damage it by damage // 
    public void TakeDamage(int damage){
        Debug.Log( "Im being called" );

        if (currentWallHealth>=0)
        {
            Debug.Log( "Im being called because i have health" );
            currentWallHealth -= damage;
        }
        else
        {
            // destroy structure
        }
    }

    // repair 
    void Repaired()
    {

        // if can be repaired at all
        if( currentWallHealth < maxWallHealth )
        {
            // repair
            currentWallHealth += 10;
            if( currentWallHealth > maxWallHealth )
            {
                currentWallHealth = maxWallHealth;
            }
      
        }
    }

    // upgrade
    public int Upgrade(int currentState){

        int returnVal = 0;
        if (currentState < fullyUpgraded){
            // upgrade if currently not upgraded at all // 
            if( currentState == 0 )
            {
                    returnVal = 1;                
            }
            // upgrade if upgraded once already // 
            else if( currentState == 1 )
            {
                    returnVal = 2;
            }
        }
        // don't check since can't be upgraded any further // 
        else
        {
            returnVal = 0;
        }
        return returnVal;
    }

}
