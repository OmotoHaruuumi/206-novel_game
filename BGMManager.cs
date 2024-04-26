using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    AudioSource audiosource; //スピーカー

    public AudioClip transfer,mensetu,amusement,parade,gas,funeral,bad,heart,last;
    
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
        else if(BGMName == "転校")
        {
            if(audiosource==null)
            {
                Debug.Log("null");
            }
            audiosource.clip = transfer;
            audiosource.Play();
        }
        else if (BGMName == "遊園地")
        {
            audiosource.clip = amusement;
            audiosource.Play();
        }
        else if (BGMName == "パレード")
        {
            audiosource.clip = parade;
            audiosource.Play();
        }
        else if (BGMName == "面接")
        {
            audiosource.clip = mensetu;
            audiosource.Play();
        }
        else if (BGMName == "毒ガス")
        {
            audiosource.clip = gas;
            audiosource.Play();
        }
        else if (BGMName == "葬式")
        {
            audiosource.clip = funeral;
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
        else if (BGMName == "last")
        {
            audiosource.clip = last;
            audiosource.Play();
        }

    }
}
