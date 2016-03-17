using UnityEngine;
using System.Collections;

public class PlayerInventoryScript : MonoBehaviour {

    /*
     * inventory[] is players current resource inventory
     * index 0: mud
     * index 1: lumber
     * index 2: stone
     */
    public int[] inventory = new int[3];
    

    private int[] tempUpgradeReq;
    private int[] tempRepairReq;
    private int tempUgradeIndex;
    private GameObject target = null;
    private int[] stoneWallCosts = new int[3];
    private int[] woodWallCosts = new int[3];
    private int[] towerCosts = new int[3];

    public int[] buildReqTurret = new int[3];

	void Start () {

        buildReqTurret[0] = 6;
        buildReqTurret[1] = 6;
        buildReqTurret[2] = 8;

        stoneWallCosts[0] = 10;
        stoneWallCosts[1] = 14;
        stoneWallCosts[2] = 2;

        woodWallCosts[0] = 10;
        woodWallCosts[1] = 14;
        woodWallCosts[2] = 2;

        towerCosts[0] = 12;
        towerCosts[1] = 2;
        towerCosts[2] = 16;
        // initialize inventory to empty 
        for( int i = 0; i < inventory.Length; i++ )
        {
            inventory[i] = 500;
        }
        tempUgradeIndex = 0;

	}
	
	void FixedUpdate () 
    {
        if( target != null )
        {
            if( Input.GetKeyUp( KeyCode.R ) )
            {
                // spends resources
                SpendResources( tempRepairReq );
                Debug.Log( inventory[0] );
                // upgrades wall
                target.GetComponent<Walls>().Repaired();
            }
            // UPGRADE INPUT //
            if( Input.GetKeyUp( KeyCode.E ) )
            {
                if( tempUgradeIndex < 2 )
                {
                    SpendResources( tempUpgradeReq );
                    target.GetComponent<Walls>().Upgrade( tempUgradeIndex );
                }
                else
                {
                    // feedback for no upgrade
                }
            }
        }

	}


    public void SpendResources(int[]requirements)
    {

        if( (inventory[0] >= requirements[0]) && 
            (inventory[1] >= requirements[1]) && 
            (inventory[2] >= requirements[2]) )
        {
            for( int i = 0; i < inventory.Length; i++ )
            {
                inventory[i] -= requirements[i];
            }

        }
        else
        {
            // feedback for no expenditure, sound maybe?
        } 

    }
    public void GainResource(int whichResource,int amount)
    {
        if (whichResource > 0)
        {
            inventory[whichResource - 1] += amount;
        }
    }


    void OnTriggerStay( Collider other )
    {
        if( other.CompareTag( "Building" ) )
        {
            tempRepairReq = other.GetComponent<Walls>().repairReq;
            tempUpgradeReq = other.GetComponent<Walls>().upgradeReq;
            tempUgradeIndex = other.GetComponent<Walls>().currentState;
            target = other.gameObject;
            // need icons to show if operations can be operated

            // REPAIR INPUT //

        }
    }
    // 
    void OnTriggerExit( Collider other )
    {
        if( other.CompareTag( "Building" ) )
        {
            tempRepairReq = null;
            tempUpgradeReq = null;
            tempUgradeIndex = 0;
            target = null;
        }
    }

    public bool CanBuildWall( int which)
    {
        bool canBuild = false;
        if( which == 1 )
        {
            if( (inventory[0] >= stoneWallCosts[0]) &&(inventory[1] >= stoneWallCosts[1]) &&(inventory[2] >= stoneWallCosts[2]) )
            {
                canBuild = true;

            }
        }
        else if(which==2)
        {
            if( (inventory[0] >= towerCosts[0]) && (inventory[1] >= towerCosts[1]) && (inventory[2] >= towerCosts[2]) )
            {
                canBuild = true;

            }
        }
        else if(which==3)
        {
            if( (inventory[0] >= woodWallCosts[0]) && (inventory[1] >= woodWallCosts[1]) && (inventory[2] >= woodWallCosts[2]) )
            {
                canBuild = true;

            }
        }
        return canBuild;
    }


    public bool CanBuildTurret()
    {
        bool canBuild = false;

        if( (inventory[0] >= buildReqTurret[0]) &&
            (inventory[1] >= buildReqTurret[1]) &&
            (inventory[2] >= buildReqTurret[2]) )
        {
            canBuild = true;
        }

        return canBuild;
    }
    public void BuildTurret()
    {
        for( int i = 0; i < 3; i++ )
        {
            inventory[i] -= buildReqTurret[i];
        }
    }
    public void BuildStoneWall()
    {
        for( int i = 0; i < 3; i++ )
        {
            inventory[i] -= stoneWallCosts[i];
        }
    }
    public void BuildWoodWall()
    {
        for( int i = 0; i < 3; i++ )
        {
            inventory[i] -= woodWallCosts[i];
        }
    }
    public void BuildTower()
    {
        for( int i = 0; i < 3; i++ )
        {
            inventory[i] -= towerCosts[i];
        }
    }
}
