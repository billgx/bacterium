using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gm : MonoBehaviour {
    public GameObject foodTile;
    int foodTileDimensions = 11;

	// Use this for initialization
	void Start () {
		
        for (int x = 1; x <= foodTileDimensions ; x++)
        {
            for (int z = 1; z <= foodTileDimensions ; z++)
            {
                Instantiate(foodTile, new Vector3(x * 4 - 24f, 0, z * 4 - 24f), Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
