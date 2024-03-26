using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;


public class BGManager : MonoBehaviour
{

    [SerializeField]
    private Sprite[] bgimages; //�摜�̃��X�g

    private string[] bgnames = new string[] {"�w�Z�w�i"}; //�����̕ϐ��������������X�g

    Dictionary<string,Sprite> BGDictionary;  //SE�̃L�[�Ɖ�����Ή������������^�z��




    // Start is called before the first frame update
    public void Start()
    {
        BGDictionary = new Dictionary<string,Sprite>(); //������

        //�Q�̃��X�g���玫�����쐬
        if (bgimages.Length != bgnames.Length)
        {
            Debug.LogError("Error: Number of audioclips and AudioClipname don't match.");
            return;
        }

        for (int i = 0; i < bgimages.Length; i++)
        {
           BGDictionary.Add(bgnames[i], bgimages[i]);
        }


    }

    //�w�肳�ꂽ����炷,�ʐ^�̖��O���󂯎�肻��ɑΉ�����ʐ^��T���Ԃ�
    public Sprite Set(string bgname)
    {
        Sprite BGImage = BGDictionary[bgname]; //�w�肳�ꂽ�L�[�ɑΉ�����摜

        return BGImage;
    }
}
