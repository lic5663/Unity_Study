using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject {

	// player's attack damage to wall
	public int wallDamage = 1;
	public int pointsPerFood = 10;
	public int pointsPerSoda = 20;
	public float restartLevelDelay = 1f;

	private Animator animator;
	private int food;

	// not MovingObject's start, use player's start
	protected override void Start () 
	{
		animator = GetComponent<Animator> ();
		food = GameManager.instance.playerFoodPoints;

		// call MovingObject's start
		base.Start ();
	}

	// This called when GameObject disable moment
	private void OnDisable()
	{
		GameManager.instance.playerFoodPoints = food;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!GameManager.instance.playersTurn)
			return;

		int horizontal = 0;
		int vertical = 0;

		horizontal = (int)Input.GetAxisRaw ("Horizontal");
		vertical = (int)Input.GetAxisRaw ("Vertical");

		// prevent player move diagonal
		if (horizontal != 0)
			vertical = 0;

		// player move input moment
		if (horizontal != 0 || vertical != 0)
			AttemptMove<Wall> (horizontal, vertical);
	}

	// player move event
	protected override void AttemptMove <T> (int xDir, int yDir)
	{
		food--;
		base.AttemptMove <T> (xDir, yDir);

		RaycastHit2D hit;

		CheckIfGameOver ();

		// move end -> player's turn end
		GameManager.instance.playersTurn = false;
	}

	// interaction other (item, exit ..)
	// OnTriggerEnter2D is API function
	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Exit") 
		{
			Invoke ("Restart", restartLevelDelay);
			enabled = false;
		} 
		else if (other.tag == "Food") 
		{
			food += pointsPerFood;
			other.gameObject.SetActive (false);
		}
		else if (other.tag == "Soda")
		{
			food += pointsPerSoda;
			other.gameObject.SetActive (false);
		}
	}

	protected override void OnCantMove <T> (T component)
	{
		Wall hitWall = component as Wall;
		hitWall.DamageWall (wallDamage);
		animator.SetTrigger ("playerChop");
	}

	private void Restart()
	{
		// last loaded scene load. but we have only one scene Main
		Application.LoadLevel (Application.loadedLevel);
	}

	public void LoseFood(int loss)
	{
		animator.SetTrigger ("playerHit");
		food -= loss;
		CheckIfGameOver ();
	}

	private void CheckIfGameOver()
	{
		if (food <= 0)
			GameManager.instance.GameOver ();
	}
}
