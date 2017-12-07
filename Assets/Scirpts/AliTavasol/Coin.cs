using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    private Rigidbody2D Coins;
    Vector2 Force1;
    float RandomX;
    float RandomY;

    // Use this for initialization
    void Start () {
        RandomY = UnityEngine.Random.Range(200.0f, 300.0f);
        RandomX = UnityEngine.Random.Range(-50.0f, 50.0f);
        Force1 = new Vector2(RandomX, RandomY);
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(Force1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
