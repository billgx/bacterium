using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

    public GameObject gameManager;
    gm bactCount; // bacteria count of the game manager

    public GameObject foodTile;
    public food food;
    public int foodCount = 0; // counter used to see how much food is in bacterium's belly

    private int eatCount = 0; // counts the number of successful eat();
    public float eatTime = 0.5f; // time in seconds between eat()

    private int reproduceCount = 0; // used to count number of reproduce() method calls
    public int eatsToReproduce = 2; // used to set the number of eats triggering a reproduce
    public static int lifetimeReproduction = 2; // number of times to instantiate a new bacterium before death


        // how much food in bacterium stomach. It needs to be above zero or bacteria should die.


    public GameObject newBall;
    private Rigidbody ballRigidBody;
    float timer =  0;

 
    Vector3 pos; // position for new bacterium

	// Use this for initialization
	void Start () {
        bactCount = gameManager.GetComponent<gm>();
        ballRigidBody = newBall.GetComponent<Rigidbody>();
        ballRigidBody.maxDepenetrationVelocity = 1;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        //dieTimer += Time.deltaTime;

        if (timer > eatTime) // && foodCount > 0)

        {
            timer = 0;
            eat();

            if (eatCount % eatsToReproduce == 0) // eatsToReproduce is the number of eat() calls to reproduce() making a new bacterium
            {
                reproduce();
            }
         }


        if (reproduceCount >= lifetimeReproduction)
        {
            die();
            print("Been busy, now dying");
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
        
        if (foodTile == null)
        {
            die();
            print("food tile is null");
            return;
        }
        else
        {
            int foodAmt = food.supplyFood();
            foodCount += foodAmt;
            eatCount++;
        }
    }

    public void reproduce()
    {
        pos = Random.onUnitSphere * 1.5f + transform.position; // offsets the new bacterium in a random direction 1 unit away
        pos = new Vector3(pos.x, 0, pos.z); // sets the y position to zero for the random position
        Instantiate(newBall, pos, Quaternion.identity); 
        //newBall.transform.SetParent(transform, false); // experimenting with making new ball child of original ball
        reproduceCount++;
        bactCount.addBacteria(newBall);
    }

    public void die()
    {
        bactCount.removeBacteria(this.gameObject);
        Destroy(this.gameObject);
        print("died");

    }
}
