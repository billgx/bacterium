using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

    public GameObject foodTile;
    public food food;
    static float reproduceTime = 2; // time in seconds between instantiating new bacterium
    private int reproduceCount = 0;
    public static int lifetimeReproduction = 3; // number of times to instantiate a new bacterium before death
    public int foodCount = 1;

        // how much food in bacterium stomach. It needs to be above zero or bacteria should die.

    //static float eatTime = 1;
    /* need to determine relationship between eating and 
     * reproducing. I'm thinking three eats = reproduce. 
     * also, not eating should affect health and eventually = die().
*/

    public GameObject newBall;
    float timer =  0;
 
    Vector3 pos; // position for new bacterium

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > reproduceTime) // && foodCount > 0)

        {
            timer = 0;
            //reproduce();
            eat();
         }

        if (reproduceCount >= lifetimeReproduction)
        {
            die();
        }
	}
        

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "food")
        {
            foodTile = collision.collider.gameObject; // connects the foodTile to this bacterium
            food = foodTile.GetComponent<food>();
        }
    }

    public void eat()
    {
        int foodAmt = food.supplyFood();
        if (foodAmt > 0)
        {
            foodCount += food.supplyFood();

        }
        else
        {
            foodCount--;
            if (foodCount < 0)
            {
                die();
            }

        }
        print("Eating. Food Count = " + foodCount);


    }

    public void reproduce()
    {
        pos = Random.onUnitSphere + transform.position; // offsets the new bacterium in a random direction 1 unit away
        pos = new Vector3(pos.x, 0, pos.z); // sets the y position to zero for the random position
        Instantiate(newBall, pos, Quaternion.identity); 
        reproduceCount++;
    }

    public void die()
    {
        Destroy(this.gameObject);
    }
}
