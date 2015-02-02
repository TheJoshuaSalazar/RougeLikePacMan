using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float speed = 0.4f;
	private Vector2 dest = Vector2.zero;

	// Use this for initialization
	void Start () 
	{
		dest = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector2 newPosition = Vector2.MoveTowards (transform.position,
	                                         dest, speed);

		rigidbody2D.MovePosition (newPosition);

		if ((Vector2)transform.position == dest)
		{
				if (Input.GetKey (KeyCode.UpArrow) && valid (Vector2.up))
						dest = (Vector2)transform.position + Vector2.up;
				if (Input.GetKey (KeyCode.RightArrow) && valid (Vector2.right))
						dest = (Vector2)transform.position + Vector2.right;
				if (Input.GetKey (KeyCode.DownArrow) && valid (-Vector2.up))
						dest = (Vector2)transform.position - Vector2.up;
				if (Input.GetKey (KeyCode.LeftArrow) && valid (-Vector2.right))
						dest = (Vector2)transform.position - Vector2.right;
		}

		Vector2 dir = dest - (Vector2)transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);
	}

	bool valid(Vector2 dir)
	{
		bool isHit;
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
		isHit = (hit.collider == collider2D);
		return isHit;
	}
}
