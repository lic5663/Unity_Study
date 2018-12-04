using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	// GameManager is only one.
	public static GameManager instance = null;

	public BoardManager boardScript;
	public int level = 3;

	// Use this for initialization
	void Awake () 
	{
		// GameManager is only one.
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		// next to secene, GameManager must still alive
		DontDestroyOnLoad (gameObject);

		boardScript = GetComponent<BoardManager> ();
		InitGame ();
	}

	void InitGame()
	{
		boardScript.SetupScene (level);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
