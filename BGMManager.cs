using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    AudioSource audiosource; //スピーカー

    public AudioClip bgm1,bgm2,bgm3,bgm4,bad,heart;
    
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void BGMChange(string BGMName)
    {
        audiosource = GetComponent<AudioSource>();
        if (BGMName == "stop")
        {
            audiosource.clip = null;
        }
        else if(BGMName == "bgm1")
        {
            if(audiosource==null)
            {
                Debug.Log("null");
            }
            audiosource.clip = bgm1;
            audiosource.Play();
        }
        else if (BGMName == "bgm2")
        {
            audiosource.clip = bgm2;
            audiosource.Play();
        }
        else if (BGMName == "bgm3")
        {
            audiosource.clip = bgm3;
            audiosource.Play();
        }
        else if (BGMName == "bgm4")
        {
            audiosource.clip = bgm4;
            audiosource.Play();
        }
        else if (BGMName == "bad")
        {
            audiosource.clip = bad;
            audiosource.Play();
        }
        else if (BGMName == "heart")
        {
            audiosource.clip = heart;
            audiosource.Play();
        }

    }
}
