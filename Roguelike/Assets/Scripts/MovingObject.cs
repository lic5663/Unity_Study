using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour {

	public float moveTime = 0.1f;
	public LayerMask blockingLayer;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;
	private float inverseMoveTime;


	// Use this for initialization
	// protected virtual : available override;
	protected virtual void Start () 
	{
		boxCollider = GetComponent<BoxCollider2D> ();
		rb2D = GetComponent<Rigidbody2D> ();
		inverseMoveTime = 1f / moveTime;
	}

	protected bool Move (int xDir, int yDir, out RaycastHit2D hit)
	{
		Vector2 start = transform.position;
		Vector2 end = start + new Vector2 (xDir, yDir);

		// prevent to hit by itself
		boxCollider.enabled = false;
		hit = Physics2D.Linecast (start, end, blockingLayer);
		boxCollider.enabled = true;

		if (hit.transform == null) 
		{
			StartCoroutine (SmoothMovement (end));
			return true;
		}
		return false;
	}

	protected virtual void AttemptMove<T> (int xDir, int yDir)
		where T : Component
	{
		RaycastHit2D hit;
		bool canMove = Move (xDir, yDir, out hit);

		if (hit.transform == null)
			return;
		T hitComponenet = hit.transform.GetComponent<T> ();

		if (!canMove && hitComponenet != null)
			OnCantMove (hitComponenet);
	}

	protected IEnumerator SmoothMovement (Vector3 end)
	{
		// object to end distanece calculate by sqr value
		float sqrRemaininingDistance = (transform.position - end).sqrMagnitude;

		// Epslion ~= 0
		while (sqrRemaininingDistance > float.Epsilon) 
		{
			// calculate way to end
			Vector3 newPosition = Vector3.MoveTowards (rb2D.position, end, inverseMoveTime * Time.deltaTime);
			// object move
			rb2D.MovePosition (newPosition);
			// recalculate distance
			sqrRemaininingDistance = (transform.position - end).sqrMagnitude;
			// wait next frame before next loop
			yield return null;
		}
	}

	protected abstract void OnCantMove <T> (T component)
		where T : Component;
}
