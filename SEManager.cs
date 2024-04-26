using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SEManager : MonoBehaviour
{
    private AudioSource audiosource; //スピーカー

    [SerializeField]
    private AudioClip[] audioclips; //音源のリスト

    private string[] AudioClipname = new string[] {"laugh","shock","click","bokeru","bomb"}; //音源の変数名が入ったリスト

    Dictionary<string, AudioClip> audioClipDictionary;  //SEのキーと音源を対応させた辞書型配列




    // Start is called before the first frame update
    public void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audioClipDictionary = new Dictionary<string, AudioClip>(); //初期化

        //２つのリストから辞書を作成
        if (audioclips.Length != AudioClipname.Length)
        {
            Debug.LogError("Error: Number of audioclips and AudioClipname don't match.");
            return;
        }

        for (int i = 0; i < audioclips.Length; i++)
        {
            audioClipDictionary.Add(AudioClipname[i], audioclips[i]);
        }


    }

    //指定された音を鳴らす,clipの名前を受け取りそれに対応するクリップを探し音を鳴らす
    public void PlaySE(string clipname)
    {
        AudioClip AudioToPlay = audioClipDictionary[clipname]; //指定されたキーに対応する音源を取得


        if (AudioToPlay != null)
        {
            audiosource.PlayOneShot(AudioToPlay);
        }
        else
        {
            Debug.Log("オーディオソースが設定されていません");
        }
    }

}
