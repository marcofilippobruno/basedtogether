using UnityEngine;
using System.Collections;

public class Wood_Wall : Walls {

	// Use this for initialization
	void Start () {

        repairAmount = 35;

        upgradeOneHealth = 125;
        upgradeTwoHealth = 175;

        // set start hp vals //
        maxWallHealth = 100;
        currentWallHealth = 100;

        // array for repair reqs //
        repairReq[0] = 2;
        repairReq[1] = 4;
        repairReq[2] = 2;

        // array for upgrade reqs //
        upgradeReq[0] = 8;
        upgradeReq[1] = 10;
        upgradeReq[2] = 2;

        // array for build reqs //
        buildReq[0] = 10;
        buildReq[1] = 14;
        buildReq[2] = 2;

	}
	


   
}
