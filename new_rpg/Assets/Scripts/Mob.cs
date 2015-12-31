using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {

    public float speed = 1;
    public float range = 4.5f;
    public float hitRange = 1;
    public float hp;
    public float damage;
    CharacterController cc;
    GameObject player;

    

	// Use this for initialization

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cc = transform.GetComponent<CharacterController>();
        hp = 15;
        damage = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!IsDead())
        {
            if (InRange(range))
            {
                if (!InRange(hitRange))
                    Chase();
                else {
                    // hit the player
                    Attack();
                }
            }
        }
        else
        {
            // being dead
            Die();
        }
	}

    bool InRange(float range)
    {
        if (Vector3.Distance(transform.position, player.transform.position) < range)
            return true;
        return false;
    }

    void Chase()
    {
        transform.LookAt(player.transform);
        cc.SimpleMove(transform.forward * speed);
    }

    void OnMouseOver()
    {
        player.transform.GetComponent<Combat>().opponent = gameObject;
    }

    public bool IsDead()
    {
        return hp <= 0;
    }

    public void takeDamage(float damage)
    {
        hp -= damage;
        if (hp < 0)
            hp = 0;
    }

    void Attack()
    {
        // Play any animations here
        player.GetComponent<Player>().TakeDamage(damage);

    }

    void Die()
    {
        // Play some death animation here if one is present.
        Destroy(gameObject);
    }
}
