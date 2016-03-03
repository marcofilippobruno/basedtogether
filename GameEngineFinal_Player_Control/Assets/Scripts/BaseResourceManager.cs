using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaseResourceManager : MonoBehaviour {

	private static int mudAtBase;
    private static int lumberAtBase;
    private static int stoneAtBase;

    Text text;

    // Use this for initialization
	void Awake () {
        text = GetComponent<Text>();

        mudAtBase = 0;
        lumberAtBase = 10;
        stoneAtBase = 15;
	}
	
	// Update is called once per frame
	void Update () {

        text.text = 
            mudAtBase + "\n" + 
            lumberAtBase + "\n" + 
            stoneAtBase
            ;
	}

    public static void AddResources( int mud, int lumber, int stone )
    {
        mudAtBase += mud;
        lumberAtBase += lumber;
        stoneAtBase += stone;
    }

    public static void SubtractResources( int mud, int lumber, int stone )
    {
        mudAtBase -= mud;
        lumberAtBase -= lumber;
        stoneAtBase -= stone;
    }
}
