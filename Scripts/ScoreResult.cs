using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class ScoreResult : MonoBehaviour
{
    public Text ResultText;
    [SerializeField]
    public GameObject nextbutton;
    private float animationduration = 3.0f;   //�A�j���[�V�����̎��s����

    // Start is called before the first frame update
    public void Start()
    {
        this. ResultText = this.GetComponent<Text>();
        this.ResultText.text = "0";                       //�ŏ��͂O�ɐݒ�
    }

    //�X�R�A���J�E���g�A�b�v���Ă����Ȃ���\���ADOCounter(�J�n�l�A�I���l�A�J�ڎ��ԁA�J���}�̗L��).SetEase(Ease.�J�ڂ̗l�q)
    public void CountUp(int score)
    {
        float resultscore = (float)score / 10f;

        if (resultscore > 999999)  //��������̗��R�Œl���J���X�g�l�𒴂��Ă����ꍇ999999��\��
        {
            DOVirtual.Float(0f, 999999f, animationduration, updatingscore => { ResultText.text = updatingscore.ToString("F1"); }).SetEase(Ease.OutCubic); //outcubic��(t - 1)^3 + 1(0<=t<=1)
        }
        else
        {
            DOVirtual.Float(0f, resultscore, animationduration / 2, updatingscore => {ResultText.text = updatingscore.ToString("F1");}).SetEase(Ease.OutCubic);
        }

        ResultText.DOColor(new Color(1f, 1f, 0), animationduration).SetEase(Ease.Linear).OnComplete(() => {
            // ����1.5�b�ō��F�ɕω�
            ResultText.DOColor(new Color(1f, 0, 0), animationduration / 2).SetEase(Ease.Linear);
        });

        ResultText.rectTransform.DOScale(new Vector3(1.2f, 1.2f, 1f), animationduration).SetEase(Ease.OutCubic).OnComplete(() =>
        {
            // ����1.5�b�Ō��̑傫���ɖ߂�
            ResultText.rectTransform.DOScale(new Vector3(1f, 1f, 1f), animationduration).SetEase(Ease.Linear);
        });
    }
}
