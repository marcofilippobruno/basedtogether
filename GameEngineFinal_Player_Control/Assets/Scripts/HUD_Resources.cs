using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD_Resources : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public GameObject base_inventory;

    public Text p1_bag;
    public Text p1_backpack;
    public Text p1_base;
    public Text p2_bag;
    public Text p2_backpack;
    public Text p2_base;

    private static int[] p1_inventory = new int[3];
    private static int[] p2_inventory = new int[3];
    private int backpack_sum = 0;

	void Start () {
        //p1_inventory = player1.PlayerInventory.inventory;
        //p2_inventory = player2.PlayerInventory.inventory;
	}
	
	void Update () {

        p1_bag.text =
            p1_inventory[0] + "\n" +
            p1_inventory[1] + "\n" +
            p1_inventory[2]
            ;

        backpack_sum = GetResourcesSum( p1_inventory );
        p1_backpack.text =
            backpack_sum.ToString() + " / 30";
            ;

        //p1_base.text =
        //    base_inventory.inventory.ToString();
        //    ;

        p2_bag.text =
            p2_inventory[0] + "\n" +
            p2_inventory[1] + "\n" +
            p2_inventory[2]
            ;

        backpack_sum = GetResourcesSum( p2_inventory );
        p2_backpack.text =
            backpack_sum.ToString() + " / 30";
        ;

        //p2_base.text =
        //    base_inventory.inventory.ToString();
        //    ;
	}

    public static int GetResourcesSum(int[] array)
    {
        int sum = 0;

        for( int i = 0; i < array.Length; i++ )
        {
            sum += array[i];
        }

        return sum;
    }
}
