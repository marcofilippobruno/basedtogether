﻿using UnityEngine;
using System.Collections;

public class Stone_Wall : Walls {
    private GameObject turretThis = null;
    private Vector3 turretLoc;
    private bool canPlace = true;
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

        // array for build reqs //
        if( whichBuilding == 1 )
        {
            buildReq[0] = 10;
            buildReq[1] = 4;
            buildReq[2] = 14;
        }
        else if( whichBuilding == 2 )
        {
            buildReq[0] = 12;
            buildReq[1] = 2;
            buildReq[2] = 16;
        }

        turretLoc = transform.position;
        turretLoc.y = 5f;

	}
    public void CreateTurret( GameObject turret )
    {
        canPlace = false;
        turretThis = Instantiate( turret, turretLoc, Quaternion.Euler( 0, 0, 0 ) ) as GameObject;
    }
    public bool GetTurret()
    {
        return canPlace;
    }
    public void Init()
    {
        if( whichBuilding == 1 )
        {
            buildReq[0] = 10;
            buildReq[1] = 4;
            buildReq[2] = 14;
        }
        else if( whichBuilding == 2 )
        {
            buildReq[0] = 12;
            buildReq[1] = 2;
            buildReq[2] = 16;
        }
    }


   
}
