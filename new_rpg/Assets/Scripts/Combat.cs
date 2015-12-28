using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour {

    public GameObject opponent;
    Animation animator;
    public AnimationClip attack;
    public float attackDamage;
    public float attackRange;

    public double impactTime;
    bool impacted;
	// Use this for initialization
	void Start () {
        animator = transform.GetComponent<Animation>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space) && opponent != null)
        {
            animator[attack.name].wrapMode = WrapMode.Once;
            ClickToMove.inAttack = true;
            if (InRange())
            {
                transform.LookAt(opponent.transform.position);
                animator.Play(attack.name);
                Impact();
            }
        }
        if (animator[attack.name].time > animator[attack.name].length * 0.9) // if the animation is 99% done, we can say it has ended.
        {
            ClickToMove.inAttack = false;
            impacted = false;
        }
    }

    void Impact()
    {
        Debug.Log(impacted);
        if (animator.IsPlaying(attack.name) && !impacted)
        {
            if (animator[attack.name].time > animator[attack.name].length * impactTime && animator[attack.name].time < animator[attack.name].length * 0.9)
            {
                opponent.GetComponent<Mob>().takeDamage(attackDamage);
                impacted = true;
            }
        }
    }

    bool InRange()
    {
        if (Vector3.Distance(transform.position, opponent.transform.position) < 2)
            return true;
        return false;
    }

}
