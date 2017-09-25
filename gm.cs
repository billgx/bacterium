using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gm : MonoBehaviour { // lays the food tiles on the ground.
    public GameObject foodTile;
    int foodTileDimensions = 11;
    public int bactCount = 0;

	// Use this for initialization
	void Start () {
		
        for (int x = 1; x <= foodTileDimensions ; x++)
        {
            for (int z = 1; z <= foodTileDimensions ; z++)
            {
                Instantiate(foodTile, new Vector3(x * 4 - 24f, -0.4f, z * 4 - 24f), Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addBacteria()
    {
        bactCount++;
        print("Bacteria count: " + bactCount);
    }

    public void removeBacteria()
    {
        bactCount--;
        print("Bacteria count: " + bactCount);
    }
}
