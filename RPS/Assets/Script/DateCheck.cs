using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateCheck : MonoBehaviour {

    System.DateTime now;

    int nowMonth;
    int nowDay;

    public AudioClip voice_date0101;
    public AudioClip voice_date0115;
    public AudioClip voice_date0203;
    public AudioClip voice_date0211;
    public AudioClip voice_date0214;
    public AudioClip voice_date0304;
    public AudioClip voice_date0314;
    public AudioClip voice_date0319;
    public AudioClip voice_date0401;
    public AudioClip voice_date0421;
    public AudioClip voice_date0422;
    public AudioClip voice_date0503;
    public AudioClip voice_date0504;
    public AudioClip voice_date0505;
    public AudioClip voice_date0602;
    public AudioClip voice_date0707;
    public AudioClip voice_date0720;
    public AudioClip voice_date0813;
    public AudioClip voice_date0915;
    public AudioClip voice_date0922;
    public AudioClip voice_date1008;
    public AudioClip voice_date1010;
    public AudioClip voice_date1103;
    public AudioClip voice_date1123;
    public AudioClip voice_date1224;
    public AudioClip voice_date1225;
    public AudioClip voice_date1231;

    public AudioClip[,] voice_date;

    private AudioSource univoice;





	// Use this for initialization
	void Start () {
        voice_date = new AudioClip[12 + 1, 31 + 1];

        voice_date[1, 1] = voice_date0101;
        voice_date[1, 15] = voice_date0115;
        voice_date[2, 3] = voice_date0203;
        voice_date[2, 11] = voice_date0211;
        voice_date[2, 14] = voice_date0214;
        voice_date[3, 4] = voice_date0304;
        voice_date[3, 14] = voice_date0314;
        voice_date[3, 19] = voice_date0319;
        voice_date[4, 1] = voice_date0401;
        voice_date[4, 21] = voice_date0421;
        voice_date[4, 22] = voice_date0422;
        voice_date[5, 3] = voice_date0503;
        voice_date[5, 4] = voice_date0504;
        voice_date[5, 5] = voice_date0505;
        voice_date[6, 2] = voice_date0602;
        voice_date[7, 7] = voice_date0707;
        voice_date[7, 20] = voice_date0720;
        voice_date[8, 13] = voice_date0813;
        voice_date[9, 15] = voice_date0915;
        voice_date[9, 22] = voice_date0922;
        voice_date[10, 8] = voice_date1008;
        voice_date[10, 10] = voice_date1010;
        voice_date[11, 3] = voice_date1103;
        voice_date[11, 23] = voice_date1123;
        voice_date[12, 24] = voice_date1224;
        voice_date[12, 25] = voice_date1225;
        voice_date[12, 31] = voice_date1231;

        int oldMonth = 0;
        int oldDay = 0;
        univoice = GetComponent<AudioSource>();

        // call to last game launch time
        oldMonth = PlayerPrefs.GetInt("Month");
        oldDay = PlayerPrefs.GetInt("Day");

        Debug.Log("이전 실행일 : " + oldMonth + "월" + oldDay + "일");

        // get Now
        now = System.DateTime.Now;

        nowMonth = now.Month;
        nowDay = now.Day;

        // save Now
        PlayerPrefs.SetInt("Month",now.Month);
        PlayerPrefs.SetInt("Day", now.Day);

        if (oldMonth != nowMonth || oldDay != nowDay)
        {
            if (voice_date[nowMonth, nowDay] != null)
            {
                Debug.Log(nowMonth + "월 " + nowDay + "일 대사");
                univoice.PlayOneShot(voice_date[nowMonth, nowDay]);
            }
            else
            {
                Debug.Log("특별한 날이 아니야");
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
