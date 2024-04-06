using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// SceneHolderクラス: シーンのテキストデータを読み込み、シーンの管理を行うクラス
public class SceneHolder
{
    Dictionary<string, string> Senarios = new Dictionary<string, string>();

    //テキストファイルのパス
    private string pass1 = "Texts/Senario1";
    private string pass2 = "Texts/Senario2";
    private string pass3 = "Texts/Senario3";
    private string pass4 = "Texts/Senario4";
    private string pass5 = "Texts/Senario5";


    // シーンのリスト
    public List<Scene> Scenes = new List<Scene>();

    // シーンコントローラーへの参照
    private SceneController sc;

    // コンストラクタ: シーンコントローラーを受け取り、初期化とテキストの読み込みを行う
    public SceneHolder(SceneController sc)
    {
        this.sc = sc;
        Senarios["senario1"] = pass1;
        Senarios["senario2"] = pass2;
        Senarios["senario3"] = pass3;
        Senarios["senario4"] = pass4;
        Senarios["senario5"] = pass5;
    }

    // テキストの読み込みを行うメソッド
    public void Load(string senario)
    {
        string s = findSenario(senario);
        Debug.Log(s);
        if (s != null)
        {
            TextAsset textasset = Resources.Load<TextAsset>(s);
            string[] ts = textasset.text.Split('\n');
            Scenes = Parse(ts);
        }
        else
        {
            Debug.Log("not find the senario");
        }
    }

    // テキストデータを解析してシーンのリストを作成するメソッド
    public List<Scene> Parse(string[] list)
    {
        var scenes = new List<Scene>();
        var scene = new Scene();
        foreach (string line in list)
        {
            if (line.Contains("#scene"))
            {
                var ID = line.Replace("#scene=", "");
                scene = new Scene(ID);
                scenes.Add(scene);
            }
            else
            {
                scene.Lines.Add(line);
            }
        }
        return scenes;
    }

    // 指定されたIDのシーンを検索するメソッド
    public Scene findScene(string id)
    {  
        foreach (Scene s in Scenes)
        {
            if (s.ID.Trim() == id.Trim())
            {
                Debug.Log(s);
                return s;
            }
        }
        return null;
    }

    public string findSenario(string senario)
    {
        if (Senarios.ContainsKey(senario))
        {
            return Senarios[senario];
        }
        else
        {
            Debug.Log("このシナリオは存在しません");
            return null;
        }
    }
}

