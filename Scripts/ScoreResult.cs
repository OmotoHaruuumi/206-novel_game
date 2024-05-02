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
    private float animationduration = 3.0f;   //アニメーションの実行時間

    // Start is called before the first frame update
    public void Start()
    {
        this. ResultText = this.GetComponent<Text>();
        this.ResultText.text = "0";                       //最初は０に設定
    }

    //スコアをカウントアップしていきながら表示、DOCounter(開始値、終了値、遷移時間、カンマの有無).SetEase(Ease.遷移の様子)
    public void CountUp(int score)
    {
        float resultscore = (float)score / 10f;

        if (resultscore > 999999)  //何かしらの理由で値がカンスト値を超えていた場合999999を表示
        {
            DOVirtual.Float(0f, 999999f, animationduration, updatingscore => { ResultText.text = updatingscore.ToString("F1"); }).SetEase(Ease.OutCubic); //outcubicは(t - 1)^3 + 1(0<=t<=1)
        }
        else
        {
            DOVirtual.Float(0f, resultscore, animationduration / 2, updatingscore => {ResultText.text = updatingscore.ToString("F1");}).SetEase(Ease.OutCubic);
        }

        ResultText.DOColor(new Color(1f, 1f, 0), animationduration).SetEase(Ease.Linear).OnComplete(() => {
            // 次の1.5秒で黒色に変化
            ResultText.DOColor(new Color(1f, 0, 0), animationduration / 2).SetEase(Ease.Linear);
        });

        ResultText.rectTransform.DOScale(new Vector3(1.2f, 1.2f, 1f), animationduration).SetEase(Ease.OutCubic).OnComplete(() =>
        {
            // 次の1.5秒で元の大きさに戻す
            ResultText.rectTransform.DOScale(new Vector3(1f, 1f, 1f), animationduration).SetEase(Ease.Linear);
        });
    }
}

