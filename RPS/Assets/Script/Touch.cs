using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {

    public AudioClip voice_01;
    public AudioClip voice_02;

    private Animator animator;
    private AudioSource univoice;
    private int motionIdol = Animator.StringToHash("Base Layer.Idol");

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        univoice = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (animator.GetCurrentAnimatorStateInfo(0).nameHash == motionIdol)
        {
            animator.SetBool("Motion_Idle", true);
        }
        else
        {
            animator.SetBool("Motion_Idle", false);
        }

        animator.SetBool("Touch", false);
        animator.SetBool("TouchHead", false);

        Ray ray;
        RaycastHit hit;

        GameObject hitObject;

        if (Input.GetMouseButton(0))
        {
            // launch laser from mouse postion to inside of monitor
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, 100))
            {
                hitObject = hit.collider.gameObject;

                if (hitObject.gameObject.tag == "Head")
                {
                    animator.SetBool("TouchHead", true);

                    Debug.Log("Head Hit");
                    univoice.clip = voice_01;
                    univoice.Play();

                    animator.SetBool("Face_Happy", true);
                    animator.SetBool("Face_Angry", false);

                    DispMsg.dispMessage("안녕! \n 오늘도 힘차게 시작해보자!");
                }
                else if (hitObject.gameObject.tag == "Breast")
                {
                    animator.SetBool("Touch", true);

                    Debug.Log("Breast Hit");
                    univoice.clip = voice_02;
                    univoice.Play();

                    animator.SetBool("Face_Happy", false);
                    animator.SetBool("Face_Angry", true);

                    DispMsg.dispMessage("꺄아아아악!");
                }
                else
                {
                    Debug.Log("Hit");

                    animator.SetBool("Touch", true);
                    univoice.clip = voice_02;
                    univoice.Play();
                }

            }
        }
	}
}
