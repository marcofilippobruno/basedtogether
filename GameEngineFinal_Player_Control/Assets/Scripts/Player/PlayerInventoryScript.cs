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

	void Start () {

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

}
