using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    float hp;
	// Use this for initialization
	void Start () {
        hp = 50;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
            hp = 0;
    }
}
