using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
	public float moveSpeed;
	
	private Animator anim;
	
// Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
       
		
		
		if(Input.GetKey(KeyCode.D))
		{
		       GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		
		if(Input.GetKey(KeyCode.A))
		{
		       GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		   anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D> ().velocity.x));
		if (GetComponent<Rigidbody2D> ().velocity.x > 0)
			transform.localScale = new Vector3 (1f, 1f, 1f);
		else if (GetComponent<Rigidbody2D> ().velocity.x < 0)
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		
		
		
    }
}
