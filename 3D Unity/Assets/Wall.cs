using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour 
{
    public float speed;
    public float delete_time;

	// Use this for initialization
	void Start () 
    {
        Destroy(gameObject, delete_time);
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
	}
}
