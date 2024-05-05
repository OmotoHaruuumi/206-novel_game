using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndrollBGM : MonoBehaviour
{
    private string bgm;
    AudioSource audiosource; //スピーカー
    public AudioClip normal,shen;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        bgm = SceneController.endbgm;
        if(bgm=="normal")
        {
            audiosource.clip = normal;
        }
        else if(bgm=="shen")
        {
            audiosource.clip = shen;
        }
        else
        {
            audiosource.clip = normal;
        }
        audiosource.Play();
    }
}
