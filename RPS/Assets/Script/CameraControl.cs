using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    GameObject cameraParent;

    Vector3 defaultPostion;
    Quaternion defaultRotation;
    float defaultZoom;

	// Use this for initialization
	void Start () 
    {
        cameraParent = GameObject.Find("CameraParent");

        defaultPostion = Camera.main.transform.position;
        defaultRotation = cameraParent.transform.rotation;
        defaultZoom = Camera.main.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
        // 좌클릭 -> 카메라 이동
        if (Input.GetMouseButton(0))
        {
            Camera.main.transform.Translate(Input.GetAxisRaw("Mouse X") / 10, Input.GetAxisRaw("Mouse Y") / 10, 0);
        }

        // 우클릭 -> 카메라 회전
        if (Input.GetMouseButton(1))
        {
            cameraParent.transform.Rotate(Input.GetAxisRaw("Mouse Y") * 10, Input.GetAxisRaw("Mouse X") * 10, 0);
        }

        // 드래그휠 -> 카메라 줌
        Camera.main.fieldOfView += (20 * Input.GetAxis("Mouse ScrollWheel"));

        if (Camera.main.fieldOfView < 10)
        {
            Camera.main.fieldOfView = 10;
        }

        // 휠 클릭 -> 초기화
        if (Input.GetMouseButton(2))
        {
            Camera.main.transform.position = defaultPostion;
            cameraParent.transform.rotation = defaultRotation;
            Camera.main.fieldOfView = defaultZoom;
        }

       
	}
}
