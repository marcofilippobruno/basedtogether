using UnityEngine;
using System.Collections;

public class Resource_Behavior : MonoBehaviour {

    public int whichResource = 0;
    //1==stone
    //2==wood
    //3==mud

    void Start ()
    {
        if (whichResource != 0)
        {

        }
	}
	
	void Update ()
    {
	
	}

    public void Gathered()
    {
        Debug.Log("gathered");
    }
}
