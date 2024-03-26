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

    public Transform ButtonPanel;

}
