using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gm : MonoBehaviour { // lays the food tiles on the ground.
    public GameObject foodTile;
    int foodTileDimensions = 11;
    public int bactCount = 0;
    //public List<GameObject> bacteriaList = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
        for (int x = 1; x <= foodTileDimensions ; x++)
        {
            for (int z = 1; z <= foodTileDimensions ; z++)
            {
                Instantiate(foodTile, new Vector3(x * 4 - 24f, -0.39f, z * 4 - 24f), Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addBacteria(GameObject b)
    {

        bactCount++;
        print("Bacteria count: " + bactCount);
        //bacteriaList.Add(b);
    }

    public void removeBacteria(GameObject b)
    {
        bactCount--;
        print("Bacteria count: " + bactCount);

        //bacteriaList.Remove(b);
    }
}
