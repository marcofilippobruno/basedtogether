using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class P1_BagResourceManager : MonoBehaviour {

    private static int backpackSize;
    private static int[] p1_inventory = new int[3];
    public int[] startingInventory = new int[3];

    Text text;

    // Use this for initialization
	void Awake () {
        text = GetComponent<Text>();

        backpackSize = P1_BackPackResourceManager.GetBackpackSize();
        p1_inventory[0] = startingInventory[0];
        p1_inventory[1] = startingInventory[1];
        p1_inventory[2] = startingInventory[2];
	}
	
	// Update is called once per frame
	void Update () {

        text.text = 
            p1_inventory[0] + "\n" + 
            p1_inventory[1] + "\n" + 
            p1_inventory[2]
            ;
	}

    public static void AddResources( int mud, int lumber, int stone )
    {
        p1_inventory[0] += mud;
        p1_inventory[1] += lumber;
        p1_inventory[2] += stone;

        for( int i = 0; i < p1_inventory.Length; i++ )
        {
            if( p1_inventory[i] > backpackSize )
            {
                p1_inventory[i] = backpackSize;
            }
        }
    }

    public static void SubtractResources( int mud, int lumber, int stone )
    {
        p1_inventory[0] -= mud;
        p1_inventory[1] -= lumber;
        p1_inventory[2] -= stone;

        for( int i = 0; i < p1_inventory.Length; i++ )
        {
            if( p1_inventory[i] < backpackSize )
            {
                p1_inventory[i] = 0;
            }
        }
    }

    public static int[] GetResources()
    {
        return p1_inventory;
    }

    public static int GetResourcesSum()
    {
        int sum = 0;
        
        for(int i = 0; i < p1_inventory.Length; i++)
        {
            sum += p1_inventory[i];
        }

        return sum;
    }
}
