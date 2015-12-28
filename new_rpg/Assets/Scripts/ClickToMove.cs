using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

    Vector3 position;
    public float speed;
    CharacterController cc;
    // Use this for initialization

    Animation animator;
    public AnimationClip run;
    public AnimationClip idle;
    public static bool inAttack;
	void Start () {
        cc = transform.GetComponent<CharacterController>();
        position = transform.position;
        animator = transform.GetComponent<Animation>();
        // run = 
	}
	
	// Update is called once per frame
	void Update () {
        if (!inAttack)
        {
            if (Input.GetMouseButton(0))
            {
                // find where the player clicked
                LocatePosition();
            }
            // move the player
            ClickAndMove();
        }
    }

    public void LocatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.tag != "Player")
            {
                position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
        }
    }

    public void ClickAndMove()
    {
        if (Vector3.Distance(transform.position, position) > 1)
        {
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position);
            newRotation.x = 0;
            newRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            cc.SimpleMove(transform.forward * speed);
            animator.Play(run.name);
        } else
        {
            animator.CrossFade(idle.name);
        }
    }
}
