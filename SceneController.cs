using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Linq;
using UnityEngine.EventSystems;

public class SceneController
{
    // ゲームのマネージャークラス
    private GameManager gm;
    // GUIのマネージャークラス
    private GUIManager gui;
    // シーンの解析を行うクラス
    private SceneParser sp;
    // シーンのデータを保持するクラス
    private SceneHolder sh;
    // 効果音のマネージャークラス
    private SEManager se;
    //BGMのマネージャークラス
    private BGMManager bgm;
    // 背景のマネージャークラス
    private BGManager bg;
    //立ち絵を変更するクラス
    private CharacterManager cm;

    private string tempText;

    // テキスト表示用のシーケンス
    private Sequence textSeq;

    // 現在選択肢が表示されているかを示すフラグ
    public static bool isOptionsShowed;

    // テキスト表示速度
    private float captionSpeed = 0.05f;

    // 現在のシーン
    private Scene currentScene;

    //現在のBGM
    private string stage_bgm;

    // スコアを記録
    public static int score;

    GameObject clickedObject;

    //いまボケれる状態か
    public bool canBoke;

    //ボケるボタンを押したときに表示される選択肢を保持するリスト
    List<(string,string)> nextoptions = new List<(string, string)>();

    // コンストラクタ
    public SceneController(GameManager gm)
    {
        // 各マネージャーのインスタンス取得
        this.gm = gm;
        gui = GameObject.FindObjectOfType<GUIManager>();
        se = GameObject.FindObjectOfType<SEManager>();
        bg = GameObject.FindObjectOfType<BGManager>();
        bgm = GameObject.FindObjectOfType<BGMManager>();
        cm = GameObject.FindObjectOfType<CharacterManager>();
        // シーンの解析とデータの保持のためのクラス
        sp = new SceneParser(this);
        sh = new SceneHolder(this);
        // テキスト表示用のシーケンスの初期化
        textSeq = DOTween.Sequence();
        textSeq.Complete();
        // スコアの初期化
        score = 0;
    }


    //シナリオの読み込み
    public void LoadSenario(string senario)
    {
        sh.Load(senario);
    }

    // クリック待機
    public void WaitClick()
    {
        if (currentScene.ID != null)
        {
            if (Input.GetMouseButtonDown(0)) //ボタンがクリックされた時
            { 
                clickedObject = null;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2d = Physics2D.Raycast((Vector2)Input.mousePosition, (Vector2)ray.direction);
                if(!hit2d)
                {
                    if (!isOptionsShowed)
                    {
                        Debug.Log("pressed");
                        se.PlaySE("click");
                        SetNextProcess();
                    }
                }
                else
                {
                    clickedObject = hit2d.collider.gameObject;//ゲームオブジェクトを取得
                    if(clickedObject == gui.BokeruButton)
                    {
                        BokeruButtonClick();
                        se.PlaySE("bokeru");
                    }
                }

           
            }
        }
    }

    public void BokeruButtonClick()
    {
        ShowOptions(nextoptions);
    }


    // コンポーネントの設定
    public void SetComponents()
    {
        // 選択肢パネルの表示/非表示
        gui.ButtonPanel.gameObject.SetActive(isOptionsShowed);
        // 次のページアイコンの表示/非表示
        gui.nextPageIcon.SetActive((!textSeq.IsActive() || !textSeq.IsPlaying()) && !isOptionsShowed);
        //ボケるボタンの管理
        gui.BokeruButton.SetActive((!textSeq.IsActive() || !textSeq.IsPlaying()) && !isOptionsShowed && canBoke);
        gui.FakeButton.SetActive((!(!textSeq.IsActive() || !textSeq.IsPlaying()) && !isOptionsShowed && canBoke));
    }

    // 次のシーンの設定
    public void SetScene(string id)
    {
        // 指定されたIDのシーンを取得
        currentScene = sh.findScene(id);
        currentScene = currentScene.Clone();
        Debug.Log(currentScene.ID);
        if (currentScene.ID == null) Debug.LogError("scenario not found");
        // 次の処理へ
        SetNextProcess();
    }

    // 次の処理の設定
    public void SetNextProcess()
    {
        // テキスト表示中なら最後までテキストを表示
        if (textSeq.IsActive() && textSeq.IsPlaying())
        {
            SetmainText(tempText);
        }
        // テキスト表示中でなければ次の行をパースする
        else
        {
            sp.ReadLines(currentScene);
        }
    }

    // メインテキストの設定
    public void SetmainText(string maintext)
    {
        tempText = maintext;
        if (textSeq.IsActive() && textSeq.IsPlaying())
        {
            textSeq.Complete();
        }
        else
        {
            gui.mainText.text = "";
            textSeq = DOTween.Sequence();
            textSeq.Append
                (gui.mainText.DOText
                (
                    maintext,
                    maintext.Length * captionSpeed
                ).SetEase(Ease.Linear));
        }
    }

    // スピーカーの設定
    public void SetSpeaker(string name = "")
    {
        if (name=="null")
        {
            gui.nameText.text = null;
        }
        gui.nameText.text = name;
    }

    // 選択肢の設定
    public void SetOptions(List<(string text, string nextScene)> options)
    {
        nextoptions = options;
    }

    //ボケるボタンが押された時の選択肢の表示
    public void ShowOptions(List<(string text, string nextScene)> options)
    {
        isOptionsShowed = true;
        canBoke = false;
        bgm.BGMChange("heart");
        foreach (var o in options)
        {
            // 選択肢ボタンの生成と設定
            Button b = Object.Instantiate(gui.OptionButton);
            Text text = b.GetComponentInChildren<Text>();
            text.font = gui.normalFont;
            text.text = o.text;
            b.onClick.AddListener(() => onClickedOption(o.nextScene));
            b.transform.SetParent(gui.ButtonPanel, false);
        }
    }
    


    // 選択肢がクリックされた時の処理
    public void onClickedOption(string nextID = "")
    {
        se.PlaySE("click");
        bgm.BGMChange(stage_bgm);
        // 次のシーンへ
        SetScene(nextID);
        isOptionsShowed = false;
        // 選択肢パネル内のボタンの削除
        foreach (Transform t in gui.ButtonPanel)
        {
            UnityEngine.Object.Destroy(t.gameObject);
        }
    }

    //ボケフラグの設定
    public void SetBokeflag(string bokeflag)
    {
        canBoke = System.Convert.ToBoolean(bokeflag);
    }

    // 効果音の設定
    public void SetSE(string seName)
    {
        se.PlaySE(seName);
    }

    // BGMの設定
    public void SetBGM(string BGMName)
    {
        // 背景画像の設定
        stage_bgm = BGMName;
        bgm.BGMChange(BGMName);
    }


    // 背景の設定
    public void SetBG(string BackGroundName)
    {
        // 背景画像の設定
        bg.BackGroundChange(BackGroundName);
    }

    //立ち絵の設定
    public void SetChara(string ImageName)
    {
        cm.CharacterImageChange(ImageName);
    }

    // スコアの設定
    public void SetScore(int point)
    {
        score += point;
    }

    // リザルト画面への遷移
    public void Result()
    {
        SceneManager.LoadScene("RESULT");
    }

    // スコアの取得
    public static int getscore()
    {
        return score;
    }
}