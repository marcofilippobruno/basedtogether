using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BagResourceManager : MonoBehaviour {

    private int backpackSize;
    private int[] inventory = new int[3];

    Text text;

    // Use this for initialization
	void Awake () {
        text = GetComponent<Text>();

        backpackSize = BackPackResourceManager.GetBackpackSize();
        inventory[0] = 10;
        inventory[1] = 10;
        inventory[2] = 10;
	}
	
	// Update is called once per frame
	void Update () {

        text.text = 
            inventory[0] + "\n" + 
            inventory[1] + "\n" + 
            inventory[2]
            ;
	}

    public void AddResources( int mud, int lumber, int stone )
    {
        inventory[0] += mud;
        inventory[1] += lumber;
        inventory[2] += stone;

        for( int i = 0; i < inventory.Length; i++ )
        {
            if( inventory[i] > backpackSize )
            {
                inventory[i] = backpackSize;
            }
        }
    }

    public void SubtractResources( int mud, int lumber, int stone )
    {
        inventory[0] -= mud;
        inventory[1] -= lumber;
        inventory[2] -= stone;

        for( int i = 0; i < inventory.Length; i++ )
        {
            if( inventory[i] < backpackSize )
            {
                inventory[i] = 0;
            }
        }
    }

    public int[] GetResources()
    {
        return inventory;
    }

    public int GetResourcesSum()
    {
        int sum = 0;
        
        for(int i = 0; i < inventory.Length; i++)
        {
            sum += inventory[i];
        }

        return sum;
    }
}
