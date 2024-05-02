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

    //コルーチン中か
    public bool isCoroutine = false;

    //いまボケれる状態か
    public bool canBoke;

    //強制ボケか
    public bool isForce1 = false;
    public bool isForce2 = false;

    //panel
    public GameObject mainpanel;
    public GameObject speakerpanel;

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
        //パネルの取得
        mainpanel = gui.mainTextPanel;
        speakerpanel = gui.nameTextPanel;
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
        if(isCoroutine)
        {
            return;
        }
        else
        {
            ShowOptions(nextoptions);
        }
    }


    // コンポーネントの設定
    public void SetComponents()
    {
        // 選択肢パネルの表示/非表示
        gui.ButtonPanel.gameObject.SetActive(isOptionsShowed);

        // 次のページアイコンの表示/非表示
        gui.nextPageIcon.SetActive((!textSeq.IsActive() || !textSeq.IsPlaying()) && !isOptionsShowed);
        //ボケるボタンの管理
        gui.BokeruButton.SetActive(((!textSeq.IsActive() || !textSeq.IsPlaying()) && !isOptionsShowed && canBoke) || isCoroutine);
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
        Text text = mainpanel.GetComponentInChildren<Text>();

        if(maintext=="null")
        {
            mainpanel.SetActive(false);
        }
        else
        {
            mainpanel.SetActive(true);
        }

        if (textSeq.IsActive() && textSeq.IsPlaying())
        {
            textSeq.Complete();
        }
        else
        {
            text.text = "";
            textSeq = DOTween.Sequence();
            textSeq.Append
                (text.DOText
                (
                    maintext,
                    maintext.Length * captionSpeed
                ).SetEase(Ease.Linear));
        }
    }

    // スピーカーの設定
    public void SetSpeaker(string name)
    {
        Text text = speakerpanel.GetComponentInChildren<Text>(); ;
        if (name == "null")
        {
            speakerpanel.SetActive(false);
        }
        else
        {
            text.text = name;
            speakerpanel.SetActive(true);
        }
        
    }

    // 選択肢の設定
    public void SetOptions(List<(string text, string nextScene)> options)
    {
        nextoptions = options;
    }

    //ボケるボタンが押された時の選択肢の表示
    public void ShowOptions(List<(string text, string nextScene)> options)
    {
        if(isForce2)
        {
            isOptionsShowed = true;
            cm.CharacterImageChange("null");
            SetmainText("null");
            SetSpeaker("null");
            bgm.BGMChange("heart");
            createoption(options);
            isForce2 = false;
        }
        else if (options[0].Item1 == "stay")
        {
            isOptionsShowed = false;
            SetBokeflag("false");
            SetSpeaker("スギル");
            SetChara("null");
            SetmainText("流石に今はボケようが無いか");
        }
        else
        {
            if(!isForce1)
            {
                cm.CharacterImageChange("null");
                isCoroutine = true;
            }
            isOptionsShowed = true;
            SetmainText("null");
            SetSpeaker("null");
            CoroutineManager.Instance.StartCoroutine(StartBoke(options));
            isForce1 = false;
        }
    }

    private IEnumerator StartBoke(List<(string text, string nextScene)> options)
    {
        Debug.Log("wait");
        bgm.BGMChange("heart");
        yield return new WaitForSeconds(2.0f); // delay秒待つ
        gui.PushedButton.SetActive(false);
        cm.CharacterImageChange("null");
        createoption(options);
    }

    public void createoption(List<(string text, string nextScene)> options)
    {
        isCoroutine = false;
        canBoke = false;
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

    public void Force1()
    {
        isForce1 = true;
        se.PlaySE("bokeru");
        BokeruButtonClick();
    }

    public void Force2()
    {
        isForce2 = true;
        BokeruButtonClick();
    }

    // スコアの取得
    public static int getscore()
    {
        return score;
    }
}