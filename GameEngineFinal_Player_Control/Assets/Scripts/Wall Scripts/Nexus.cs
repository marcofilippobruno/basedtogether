using UnityEngine;
using System.Collections;

public class Nexus : Walls {

	// Use this for initialization
	void Start () {

        repairAmount = 15;

        upgradeOneHealth = 550;
        upgradeTwoHealth = 700;

        // set start hp vals //
        maxWallHealth = 500;
        currentWallHealth = 500;

        // array for repair reqs //
        repairReq[0] = 10;
        repairReq[1] = 15;
        repairReq[2] = 15;

        // array for upgrade reqs //
        upgradeReq[0] = 30;
        upgradeReq[1] = 40;
        upgradeReq[2] = 40;

	}
	


   
}
