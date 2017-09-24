using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour {
    public int foodAmount = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int supplyFood () // returns a 1 if food successfully eaten. Can use this value and add it to bacterium health or something
    {
        if (foodAmount > 0)
        {
            foodAmount--;
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
