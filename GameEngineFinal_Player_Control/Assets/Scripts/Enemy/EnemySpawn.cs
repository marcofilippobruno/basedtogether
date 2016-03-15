using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

    public int count = 0;
    public int maxCount = 300;
    public GameObject enemy = null;
	void Start () 
    {
	    
	}
	

	void FixedUpdate () 
    {
        if( enemy != null )
        {
            if( count < maxCount )
            {
                count++;
            }
            else
            {
                count = 0;
                Instantiate( enemy, transform.position, transform.rotation );
            }
        }

	}
}
