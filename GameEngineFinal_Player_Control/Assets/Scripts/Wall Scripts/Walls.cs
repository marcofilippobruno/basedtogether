using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour {

    public int maxWallHealth;
    public int currentWallHealth;

    public int currentState;
    public int woodReq;
    public int rockReq;
    public int mudReq;

    public int[] repairReq = new int[3];

    private int fullyUpgraded = 2;
    private int repairAmount = 25;
    private Collider meshCollider;
    private GameObject instantiatedObj;


	// Use this for initialization
	void Start () {
        meshCollider = GetComponent<MeshCollider>();
        instantiatedObj = GetComponent<GameObject>();
	}
	
	// Update is called once per frame // 
	void Update () {
	
	}

    // destroy wall if less than 0 hp, else, damage it by damage // 
    void TakeDamage(int damage){
        if (currentWallHealth <= 0){

            Destroy( instantiatedObj );
        }
        else
        {
            currentWallHealth -= damage;
        }
    }

    // check for required resources, repair if requirements met // 
    void Repaired(int[] repairReq){
        // if can be repaired at all
        if( currentWallHealth < maxWallHealth )
        {
            if( repairReq[0] <= woodReq && repairReq[1] <= rockReq && repairReq[2] <= mudReq )
            {
                currentWallHealth += 10;
                if( currentWallHealth > maxWallHealth )
                {
                    currentWallHealth = maxWallHealth;
                }

                // reduce player resources
            }

        }
    }

    // check for required resources, upgrade or not // 
    public int Upgrade(int currentState, int wood, int rock, int mud){
        int returnVal = 0;
        if (currentState < fullyUpgraded){
            // upgrade if currently not upgraded at all // 
            if( currentState == 0 )
            {
                if( wood >= woodReq && rock >= rockReq && mud >= mudReq )
                {
                    // reduce player resources
                    returnVal = 1;
                }
            }
            // upgrade if upgraded once already // 
            else if( currentState == 1 )
            {
                if( wood >= woodReq && rock >= rockReq && mud >= mudReq )
                {
                    // reduce player resources
                    returnVal = 2;
                }
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
