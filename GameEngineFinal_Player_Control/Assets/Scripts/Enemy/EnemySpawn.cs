using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

    private float count = 0;
    private int maxCount = 5;
    public GameObject enemy = null;
    private GameObject sun = null;
	void Start () 
    {
        sun = GameObject.FindGameObjectWithTag( "Sun" );
	}
	

	void FixedUpdate () 
    {
        if( sun != null )
        {
            if( !sun.GetComponent<DayCycle_Manager>().IsDay() )
            {
                if( enemy != null )
                {
                    if( count < maxCount )
                    {
                        count += Time.fixedDeltaTime;
                    }
                    else
                    {
                        count = 0;
                        Instantiate( enemy, transform.position, transform.rotation );
                    }
                }
            }
            else
            {
                count = 0;
            }
        }


	}
}
