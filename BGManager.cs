using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;


public class BGManager : MonoBehaviour
{

    [SerializeField]
    private Sprite[] bgimages; //画像のリスト

    private string[] bgnames = new string[] {"学校背景"}; //音源の変数名が入ったリスト

    Dictionary<string,Sprite> BGDictionary;  //SEのキーと音源を対応させた辞書型配列




    // Start is called before the first frame update
    public void Start()
    {
        BGDictionary = new Dictionary<string,Sprite>(); //初期化

        //２つのリストから辞書を作成
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

    //指定された音を鳴らす,写真の名前を受け取りそれに対応する写真を探し返す
    public Sprite Set(string bgname)
    {
        Sprite BGImage = BGDictionary[bgname]; //指定されたキーに対応する画像

        return BGImage;
    }
}
