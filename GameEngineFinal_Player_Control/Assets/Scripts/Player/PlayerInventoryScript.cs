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

	void Start () {

        // initialize inventory to empty 
        for( int i = 0; i < inventory.Length; i++ )
        {
            inventory[i] = 0;
        }


	}
	
	void FixedUpdate () {

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

    /*
    void Upgrade()
    {
        if( Input.GetKeyDown( KeyCode.E ) )
        {
            SpendResources(tempUpgradeReq);
        }
    }

    void Repair()
    {
        if( Input.GetKeyDown( KeyCode.R ) )
        {
            SpendResources( tempRepairReq );
        }
    }*/

    void OnTriggerStay( Collider other )
    {
        if( other.CompareTag( "Building" ) )
        {
            tempRepairReq = other.GetComponent<Stone_Wall>().repairReq;
            tempUpgradeReq = other.GetComponent<Stone_Wall>().upgradeReq;

            if( Input.GetKeyDown( KeyCode.R ) )
            {
                SpendResources( tempRepairReq );
            } else if( Input.GetKeyDown( KeyCode.E ) )
            {
                SpendResources( tempUpgradeReq );
            }
        }
    }
    void OnTriggerExit( Collider other )
    {
        if( other.CompareTag( "Building" ) )
        {
            tempRepairReq = null;
            tempUpgradeReq = null;
        }
    }

}
