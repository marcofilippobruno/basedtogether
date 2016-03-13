using UnityEngine;
using System.Collections;

public class Resource_Behavior : MonoBehaviour {

    public int whichResource = 0;
    //1==stone
    //2==wood
    //3==mud
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

    public void Gathered()
    {
        if (amount > 0)
        {
            amount--;
        }

        
    }
}
