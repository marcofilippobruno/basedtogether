using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BagResourceManager : MonoBehaviour {

	public static int mudInBag;
    public static int lumberInBag;
    public static int stoneInBag;

    Text text;

    // Use this for initialization
	void Awake () {
        text = GetComponent<Text>();

        mudInBag = 0;
        lumberInBag = 10;
        stoneInBag = 15;
	}
	
	// Update is called once per frame
	void Update () {

        text.text = 
            mudInBag + "\n" + 
            lumberInBag + "\n" + 
            stoneInBag
            
            ;

	}

    public static void AddResources(int mud, int lumber, int stone)
    {
        mudInBag += mud;
        lumberInBag += lumber;
        stoneInBag += stone;
    }

    public static void SubtractResources( int mud, int lumber, int stone )
    {
        mudInBag -= mud;
        lumberInBag -= lumber;
        stoneInBag -= stone;
    }
}
