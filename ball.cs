using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {
    public GameObject newBall;
    float timer =  0;
    Vector3 pos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            pos = Random.onUnitSphere + transform.position;
            Instantiate(newBall, pos, Quaternion.identity);

        }
        print(timer);
	}
}
