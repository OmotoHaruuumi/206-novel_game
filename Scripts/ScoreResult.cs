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

    private float animationduration = 3.0f;   //アニメーションの実行時間
    public bool finished;
    public string senario;

    public int perfect = 1000;
    public int good = 500;

    // Start is called before the first frame update
    public void Start()
    {
        audiosource = GetComponent<AudioSource>();
        ResultText.text = "0";                       //最初は０に設定
        finished = false;
        senario = TitleManager.senario;
    }

    //スコアをカウントアップしていきながら表示、DOCounter(開始値、終了値、遷移時間、カンマの有無).SetEase(Ease.遷移の様子)
    public void CountUp(int score)
    {
        float resultscore = (float)score / 10f;

        MakeComment(score);

        if (resultscore > 999999)  //何かしらの理由で値がカンスト値を超えていた場合999999を表示
        {
            DOVirtual.Float(0f, 999999f, animationduration, updatingscore => { ResultText.text = updatingscore.ToString("F1"); }).SetEase(Ease.OutCubic); //outcubicは(t - 1)^3 + 1(0<=t<=1)
        }
        else
        {
            DOVirtual.Float(0f, resultscore, animationduration / 2, updatingscore => {ResultText.text = updatingscore.ToString("F1");}).SetEase(Ease.OutCubic);
        }

        if(score >= perfect)
        {
            star = "★★★";
        }
        else if(score >= good)
        {
            star = "★★";
        }
        else
        {
            star = "★";
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
            // 次の1.5秒で黒色に変化
            ResultText.DOColor(new Color(1f, 0, 0), animationduration / 2).SetEase(Ease.Linear);
        });

        ResultText.rectTransform.DOScale(new Vector3(1.2f, 1.2f, 1f), animationduration/2).SetEase(Ease.OutCubic).OnComplete(() =>
        {
            // 次の1.5秒で元の大きさに戻す
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
               comment = "クラスの人気者間違いなしだ";
            }
            else if (score >= good)
            {
                TitleManager.cleard1 = true;
                comment = "このクラスにもなじめそうだ";
            }
            else
            {
                comment = "いじめられそうだ";
            }
        }
        else if (senario == "senario2")
        {
            if (score >= perfect)
            {
                TitleManager.cleard2 = true;
                comment = "スギル君って面白いのね";
            }
            else if (score >= good)
            {
                TitleManager.cleard2 = true;
                comment = "今度大喜利合宿ね";
            }
            else
            {
                comment = "別れようかしら";
            }
        }
        else if (senario == "senario3")
        {
            if (score >= perfect)
            {
                TitleManager.cleard3 = true;
                comment = "優勝したぞ!!!";
            }
            else if (score >= good)
            {
                TitleManager.cleard3 = true;
                comment = "合格したぞ!!!";
            }
            else
            {
                comment = "普通の会社に入ろう...";
            }
        }
        else if (senario == "senario4")
        {
            if (score >= perfect)
            {
                TitleManager.cleard4 = true;
                comment = "まだまだ現世も面白そうだからもう少し長生きしてみるかの";
            }
            else if (score >= good)
            {
                TitleManager.cleard4 = true;
                comment = "おかげで成仏できそうじゃわい";
            }
            else
            {
                comment = "許さない許さない許さない許さない許さない許さない許さない許さない";
            }
        }
        else
        {
            comment = "エラー発生です";
        }

        CommentText.text = comment;

    }




}

