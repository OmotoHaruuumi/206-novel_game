using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SEManager : MonoBehaviour
{
    private AudioSource audiosource; //�X�s�[�J�[

    [SerializeField]
    private AudioClip[] audioclips; //�����̃��X�g

    private string[] AudioClipname = new string[] {"laugh","shock","click","bokeru","bomb"}; //�����̕ϐ��������������X�g

    Dictionary<string, AudioClip> audioClipDictionary;  //SE�̃L�[�Ɖ�����Ή������������^�z��




    // Start is called before the first frame update
    public void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audioClipDictionary = new Dictionary<string, AudioClip>(); //������

        //�Q�̃��X�g���玫�����쐬
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

    //�w�肳�ꂽ����炷,clip�̖��O���󂯎�肻��ɑΉ�����N���b�v��T������炷
    public void PlaySE(string clipname)
    {
        AudioClip AudioToPlay = audioClipDictionary[clipname]; //�w�肳�ꂽ�L�[�ɑΉ����鉹�����擾


        if (AudioToPlay != null)
        {
            audiosource.PlayOneShot(AudioToPlay);
        }
        else
        {
            Debug.Log("�I�[�f�B�I�\�[�X���ݒ肳��Ă��܂���");
        }
    }

}
