using UnityEngine;
using System.Collections;

public class Resource_Behavior : MonoBehaviour {

    public int whichResource = 0;
    //1==mud
    //2==wood
    //3==stone
    private int amount = 0;

    void Start ()
    {
        if (whichResource != 0)
        {
            amount = Random.Range(3, 5);
        }
	}
	
	void FixedUpdate ()
    {
        if (amount <= 0)
        {
            gameObject.SetActive(false);
        }
	}

    public int Gathered()
    {
        if (amount > 0)
        {
            amount--;
        }
        return Random.Range(5, 5);

        
    }
}
