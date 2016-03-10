using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaseResourceManager : MonoBehaviour {

    private static int[] baseInventory = new int[3];
    public int[] startingInventory = new int[3];

    Text text;

    // Use this for initialization
	void Awake () {
        text = GetComponent<Text>();

        baseInventory[0] = startingInventory[0];
        baseInventory[1] = startingInventory[1];
        baseInventory[2] = startingInventory[2];
	}
	
	// Update is called once per frame
	void Update () {

        text.text = 
            baseInventory[0] + "\n" + 
            baseInventory[1] + "\n" + 
            baseInventory[2]
            ;
	}

    public static void AddResources( int mud, int lumber, int stone )
    {
        baseInventory[0] += mud;
        baseInventory[1] += lumber;
        baseInventory[2] += stone;
    }

    public static void SubtractResources( int mud, int lumber, int stone )
    {
        baseInventory[0] -= mud;
        baseInventory[1] -= lumber;
        baseInventory[2] -= stone;
    }
}
