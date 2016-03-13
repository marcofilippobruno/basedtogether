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

	void Start () {

        // initialize inventory to empty 
        for( int i = 0; i < inventory.Length; i++ )
        {
            inventory[i] = 500;
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


    void OnTriggerStay( Collider other )
    {
        if( other.CompareTag( "Building" ) )
        {
            tempRepairReq = other.GetComponent<Walls>().repairReq;
            tempUpgradeReq = other.GetComponent<Walls>().upgradeReq;
            tempUgradeIndex = other.GetComponent<Walls>().currentState;

            // need icons to show if operations can be operated

            // REPAIR INPUT //
            if( Input.GetKeyDown( KeyCode.R ) )
            {
                // spends resources
                SpendResources( tempRepairReq );
                Debug.Log( inventory[0] );
                // upgrades wall
                other.GetComponent<Walls>().Repaired();
            } 
            // UPGRADE INPUT //
            else if( Input.GetKeyDown( KeyCode.E ) )
            {
                if( tempUgradeIndex < 1 )
                {
                    SpendResources( tempUpgradeReq );
                    other.GetComponent<Walls>().Upgrade( tempUgradeIndex );
                }
                else
                {
                    // feedback for no upgrade
                }
            }
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
        }
    }

}
