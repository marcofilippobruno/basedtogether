using UnityEngine;
using System.Collections;

public class Stone_Wall : Walls {

    private int upgradeOneHealth = 75;
    private int upgradeTwoHealth = 100;

	// Use this for initialization
	void Start () {

        //set upgrade state //
        currentState = 0;

        // set start hp vals //
        maxWallHealth = 50;
        currentWallHealth = 50;

        // array for repair reqs //
        repairReq[0] = 2;
        repairReq[1] = 2;
        repairReq[2] = 4;

        // array for upgrade reqs //
        upgradeReq[0] = 5;
        upgradeReq[1] = 5;
        upgradeReq[2] = 5;

	}
	

	void FixedUpdate () {
	    
	}

    // upgrade stone walls

    public void UpgradeStoneWall( int upgradeVal )
    {
        // if can't be upgraded
        if( upgradeVal == 0 )
        {
            maxWallHealth = maxWallHealth;
            currentWallHealth = currentWallHealth;

        }
        // if being upgraded to state 1
        else if( upgradeVal == 1 )
        {
            maxWallHealth = upgradeOneHealth;
            currentWallHealth = upgradeOneHealth;
        }
        // if being upgraded to state 2
        else if( upgradeVal == 2 )
        {
            maxWallHealth = upgradeTwoHealth;
            currentWallHealth = upgradeTwoHealth;
        }

    }
}
