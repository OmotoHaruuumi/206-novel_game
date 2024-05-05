using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class ScoreResult : MonoBehaviour
{
    public Text ResultText;
    public Text CommentText;
    public Text Star;

    private string star;

    private AudioSource audiosource;

    private float animationduration = 3.0f;   //�A�j���[�V�����̎��s����
    public bool finished;
    public string senario;

    public int perfect = 1000;
    public int good = 500;

    // Start is called before the first frame update
    public void Start()
    {
        audiosource = GetComponent<AudioSource>();
        ResultText.text = "0";                       //�ŏ��͂O�ɐݒ�
        finished = false;
        senario = TitleManager.senario;
    }

    //�X�R�A���J�E���g�A�b�v���Ă����Ȃ���\���ADOCounter(�J�n�l�A�I���l�A�J�ڎ��ԁA�J���}�̗L��).SetEase(Ease.�J�ڂ̗l�q)
    public void CountUp(int score)
    {
        float resultscore = (float)score / 10f;

        MakeComment(score);

        if (resultscore > 999999)  //��������̗��R�Œl���J���X�g�l�𒴂��Ă����ꍇ999999��\��
        {
            DOVirtual.Float(0f, 999999f, animationduration, updatingscore => { ResultText.text = updatingscore.ToString("F1"); }).SetEase(Ease.OutCubic); //outcubic��(t - 1)^3 + 1(0<=t<=1)
        }
        else
        {
            DOVirtual.Float(0f, resultscore, animationduration / 2, updatingscore => {ResultText.text = updatingscore.ToString("F1");}).SetEase(Ease.OutCubic);
        }

        if(score >= perfect)
        {
            star = "������";
        }
        else if(score >= good)
        {
            star = "����";
        }
        else
        {
            star = "��";
        }
        string beforetext = Star.text;
        Star.DOText(star, animationduration).SetEase(Ease.Linear).OnUpdate(() => {
            string currenttext = Star.text;
            if (beforetext == currenttext)
            {
                return;
            }
            audiosource.Play();
            beforetext = currenttext;
            });
        Debug.Log(Star);

        ResultText.DOColor(new Color(1f, 1f, 0), animationduration).SetEase(Ease.Linear).OnComplete(() => {
            // ����1.5�b�ō��F�ɕω�
            ResultText.DOColor(new Color(1f, 0, 0), animationduration / 2).SetEase(Ease.Linear);
        });

        ResultText.rectTransform.DOScale(new Vector3(1.2f, 1.2f, 1f), animationduration/2).SetEase(Ease.OutCubic).OnComplete(() =>
        {
            // ����1.5�b�Ō��̑傫���ɖ߂�
            ResultText.rectTransform.DOScale(new Vector3(1f, 1f, 1f), animationduration/2).SetEase(Ease.Linear);
        });

        StartCoroutine(TimeCount());

    }

    private IEnumerator TimeCount()
    {
        Debug.Log("count start");
        yield return new WaitForSeconds(animationduration+4.0f);
        finished = true;
    }

    private void MakeComment(int score)
    {
        string comment;
        Debug.Log(senario);
        if(senario=="senario1")
        {
            if (score >= perfect)
            {
               TitleManager.cleard1 = true;
               comment = "�N���X�̐l�C�ҊԈႢ�Ȃ���";
            }
            else if (score >= good)
            {
                TitleManager.cleard1 = true;
                comment = "���̃N���X�ɂ��Ȃ��߂�����";
            }
            else
            {
                comment = "�����߂�ꂻ����";
            }
        }
        else if (senario == "senario2")
        {
            if (score >= perfect)
            {
                TitleManager.cleard2 = true;
                comment = "�X�M���N���Ėʔ����̂�";
            }
            else if (score >= good)
            {
                TitleManager.cleard2 = true;
                comment = "���x��엘���h��";
            }
            else
            {
                comment = "�ʂ�悤������";
            }
        }
        else if (senario == "senario3")
        {
            if (score >= perfect)
            {
                TitleManager.cleard3 = true;
                comment = "�D��������!!!";
            }
            else if (score >= good)
            {
                TitleManager.cleard3 = true;
                comment = "���i������!!!";
            }
            else
            {
                comment = "���ʂ̉�Ђɓ��낤...";
            }
        }
        else if (senario == "senario4")
        {
            if (score >= perfect)
            {
                TitleManager.cleard4 = true;
                comment = "�܂��܂��������ʔ���������������������������Ă݂邩��";
            }
            else if (score >= good)
            {
                TitleManager.cleard4 = true;
                comment = "�������Ő����ł���������킢";
            }
            else
            {
                comment = "�����Ȃ������Ȃ������Ȃ������Ȃ������Ȃ������Ȃ������Ȃ������Ȃ�";
            }
        }
        else
        {
            comment = "�G���[�����ł�";
        }

        CommentText.text = comment;

    }




}

