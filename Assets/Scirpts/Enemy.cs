using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int Health = 10;
    public Enemy S;
    void Start ()
    {
        S = this;
    }
	// Update is called once per frame
	void Update ()
    {
        
	}
    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Damaged");
        }
    }
}