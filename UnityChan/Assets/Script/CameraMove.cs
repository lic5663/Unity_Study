using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float height, dist;
    public Transform target;

    Transform transform;

	// Use this for initialization
	void Start () {
        transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = target.position - (Vector3.forward * dist) + (Vector3.up * height);
        transform.LookAt(target);
	}
}
