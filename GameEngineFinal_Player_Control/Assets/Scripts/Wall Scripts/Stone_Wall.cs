using UnityEngine;
using System.Collections;

public class Stone_Wall : Walls {

	// Use this for initialization
	void Start () {

        repairAmount = 25;

        upgradeOneHealth = 75;
        upgradeTwoHealth = 100;

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

   
}
