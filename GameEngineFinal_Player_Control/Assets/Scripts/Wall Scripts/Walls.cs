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
    public void TakeDamage(int damage){
        if (currentWallHealth <= 0){

            Destroy( gameObject );
        }
        else
        {
            currentWallHealth -= damage;
        }
    }

    // check for required resources, repair if requirements met // 
    void Repaired(int[] repairReq){

        SetVals();


        // if can be repaired at all
        if( currentWallHealth < maxWallHealth )
        {
            if( playerWood >= repairReq[0] && playerRock >= repairReq[1] && playerMud >= repairReq[2] )
            {
                currentWallHealth += 10;
                if( currentWallHealth > maxWallHealth )
                {
                    currentWallHealth = maxWallHealth;
                }

                // reduce player resources
                //BagResourceManager.SubtractResources( repairReq[0], repairReq[1], repairReq[2] );
            }
        }
    }

    // check for required resources, upgrade or not // 
    public int Upgrade(int currentState){

        SetVals();

        int returnVal = 0;
        if (currentState < fullyUpgraded){
            // upgrade if currently not upgraded at all // 
            if( currentState == 0 )
            {
                if( playerWood >= woodReq && playerRock >= rockReq && playerMud >= mudReq )
                {
                    // reduce player resources
                   // BagResourceManager.SubtractResources( mudReq, woodReq, rockReq );
                    returnVal = 1;
                }
            }
            // upgrade if upgraded once already // 
            else if( currentState == 1 )
            {
                if( playerWood >= woodReq && playerRock >= rockReq && playerMud >= mudReq )
                {
                    // reduce player resources
                   // BagResourceManager.SubtractResources( mudReq, woodReq, rockReq );
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

    void SetVals()
    {
       // playerWood = BagResourceManager.lumberInBag;
       // playerRock = BagResourceManager.stoneInBag;
       // playerMud = BagResourceManager.mudInBag;
    }

}
