using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Linq;

public class SceneController 
{
    private GameManager gm;
    private GUIManager gui;
    private SceneParser sp;
    private SceneHolder sh;
    private SEManager se;
    private BGManager bg;

    private string tempText; //

    private Sequence textSeq;   //本文表示処理

    private bool isOptionsShowed; //現在選択肢が表示されているか

    private float captionSpeed = 0.05f;

    private Scene currentScene; //現在のシーンを保持

    public static int score;  //スコアを記録


    public SceneController(GameManager gm)
    {
        this.gm = gm;
        gui = GameObject.FindObjectOfType<GUIManager>();
        se = GameObject.FindObjectOfType<SEManager>();
        bg = GameObject.FindObjectOfType<BGManager>();
        sp = new SceneParser(this);
        sh = new SceneHolder(this);
        textSeq = DOTween.Sequence();
        textSeq.Complete();
        score = 0;
    }


    public void WaitClick()
    {
        if (currentScene.ID != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!isOptionsShowed)
                {
                    Debug.Log("pressed");
                    SetNextProcess();
                }
            }
        }

    }


    public void SetComponents()
    {
        gui.ButtonPanel.gameObject.SetActive(isOptionsShowed);
        gui.nextPageIcon.SetActive((!textSeq.IsActive() || !textSeq.IsPlaying()) && !isOptionsShowed);
    }

    public void SetScene(string id)
    {
        currentScene = sh.findScene(id);
        currentScene = currentScene.Clone();
        Debug.Log(currentScene.ID);
        if (currentScene.ID == null) Debug.LogError("scenario not found");
        SetNextProcess();
    }


    public void SetNextProcess()
    {
        //テキスト表示処理中なら最後までテキストを表示
        if (textSeq.IsActive() && textSeq.IsPlaying())
        {
            SetmainText(tempText);
        }
        //テキスト表示中じゃなければ次の行をParseする
        else
        {
            sp.ReadLines(currentScene);
        }
    }


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


    public void SetSpeaker(string name = "")
    {
        gui.nameText.text = name;
    }

    public void SetOptions(List<(string text, string nextScene)> options)
    {
        isOptionsShowed = true;
        foreach (var o in options)
        {
            Button b = Object.Instantiate(gui.OptionButton);
            Text text = b.GetComponentInChildren<Text>();
            text.text = o.text;
            b.onClick.AddListener(() => onClickedOption(o.nextScene));
            b.transform.SetParent(gui.ButtonPanel, false);
        }
    }
    public void onClickedOption(string nextID = "")
    {
        SetScene(nextID);
        isOptionsShowed = false;
        foreach (Transform t in gui.ButtonPanel)
        {
            UnityEngine.Object.Destroy(t.gameObject);
        }
    }

    public void SetSE(string seName)
    {
        se.PlaySE(seName);
    }

    public void SetBG(string BackGroundName)
    {
        Sprite bgimage = bg.Set(BackGroundName);
        gui.BackgroundImage.sprite = bgimage;
    }


    public void SetScore(int point)
    {
        score += point;
    }

    public void Result()
    {
        SceneManager.LoadScene("RESULT");
    }

    public static int getscore()
    {
        return score;
    }


}

