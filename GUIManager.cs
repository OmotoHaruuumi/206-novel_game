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
    public GameObject nextPageIcon; //�������\�����I���������\���A�C�R��
    [SerializeField]
    public Image BackgroundImage; //�w�i�摜
    [SerializeField]
    public Button OptionButton;
    [SerializeField]
    public GameObject BokeruButton;
    [SerializeField]
    public GameObject FakeButton;
    [SerializeField]
    public Font normalFont;  //�g�p����t�H���g


    public Transform ButtonPanel;

}
