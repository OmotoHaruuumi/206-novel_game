using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    [SerializeField]
    public Text mainText;
    [SerializeField]
    public Text nameText;
    [SerializeField]
    public GameObject nextPageIcon; //文字が表示し終わった事を表すアイコン
    [SerializeField]
    public Image BackgroundImage; //背景画像
    [SerializeField]
    public Button OptionButton;
    [SerializeField]
    public GameObject BokeruButton;
    [SerializeField]
    public GameObject FakeButton;
    [SerializeField]
    public Font normalFont;  //使用するフォント


    public Transform ButtonPanel;

}
