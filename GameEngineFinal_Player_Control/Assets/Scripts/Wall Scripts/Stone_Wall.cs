using UnityEngine;
using System.Collections;

public class Stone_Wall : Walls {

	// Use this for initialization
	void Start () {

        repairAmount = 25;

        upgradeOneHealth = 150;
        upgradeTwoHealth = 250;

        // set start hp vals //
        maxWallHealth = 125;
        currentWallHealth = 125;

        // array for repair reqs //
        repairReq[0] = 2;
        repairReq[1] = 2;
        repairReq[2] = 4;

        // array for upgrade reqs //
        upgradeReq[0] = 8;
        upgradeReq[1] = 2;
        upgradeReq[2] = 10;

	}
	



   
}
