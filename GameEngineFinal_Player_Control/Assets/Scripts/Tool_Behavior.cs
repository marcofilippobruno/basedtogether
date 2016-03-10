using UnityEngine;
using System.Collections;

public class Tool_Behavior : MonoBehaviour {
    public int whichTool = 0;
    private bool canBePickUp = true;
    //whichTool==1 pickaxe
    //whichTool==2 axe
    //whichTool==3 shovel
	void Start () 
    {
	    
	}
	
	void Update () 
    {
	    
	}
    public bool canPickUp()
    {
        return canBePickUp;
    }
    public void pickUp()
    {
        canBePickUp = false;
    }
}
