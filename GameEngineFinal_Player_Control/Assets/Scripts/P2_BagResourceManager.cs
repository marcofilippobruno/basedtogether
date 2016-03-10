using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class P2_BagResourceManager : MonoBehaviour {

    private static int backpackSize;
    private static int[] p2_inventory = new int[3];
    public int[] startingInventory = new int[3];

    Text text;

    // Use this for initialization
	void Awake () {
        text = GetComponent<Text>();

        backpackSize = P2_BackPackResourceManager.GetBackpackSize();
        p2_inventory[0] = startingInventory[0];
        p2_inventory[1] = startingInventory[1];
        p2_inventory[2] = startingInventory[2];
	}
	
	// Update is called once per frame
	void Update () {

        text.text = 
            p2_inventory[0] + "\n" + 
            p2_inventory[1] + "\n" + 
            p2_inventory[2]
            ;
	}

    public static void AddResources( int mud, int lumber, int stone )
    {
        p2_inventory[0] += mud;
        p2_inventory[1] += lumber;
        p2_inventory[2] += stone;

        for( int i = 0; i < p2_inventory.Length; i++ )
        {
            if( p2_inventory[i] > backpackSize )
            {
                p2_inventory[i] = backpackSize;
            }
        }
    }

    public static void SubtractResources( int mud, int lumber, int stone )
    {
        p2_inventory[0] -= mud;
        p2_inventory[1] -= lumber;
        p2_inventory[2] -= stone;

        for( int i = 0; i < p2_inventory.Length; i++ )
        {
            if( p2_inventory[i] < backpackSize )
            {
                p2_inventory[i] = 0;
            }
        }
    }

    public static int[] GetResources()
    {
        return p2_inventory;
    }

    public static int GetResourcesSum()
    {
        int sum = 0;
        
        for(int i = 0; i < p2_inventory.Length; i++)
        {
            sum += p2_inventory[i];
        }

        return sum;
    }
}
