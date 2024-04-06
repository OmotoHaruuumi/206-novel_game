using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sceneクラス: ゲームのシーンや対話シーンの情報を管理するクラス
public class Scene
{
    // シーンの一意の識別子
    public string ID { get; private set; }

    // シーン内の対話ラインのリスト
    public List<string> Lines { get; private set; } = new List<string>();

    // 現在の対話ラインのインデックス
    public int Index { get; private set; } = 0;

    // コンストラクタ: シーンを作成する際に必要な情報を設定
    public Scene(string ID = "")
    {
        this.ID = ID;
    }

    // シーンの複製を作成するメソッド
    public Scene Clone()
    {
        return new Scene(ID)
        {
            Index = 0,
            Lines = new List<string>(Lines)
        };
    }

    // シーンの対話が終了したかどうかを判定するメソッド
    public bool IsFinished()
    {
        return Index >= Lines.Count;
    }

    // 現在の対話ラインを取得するメソッド
    public string GetCurrentLine()
    {
        return Lines[Index];
    }

    // 次の対話ラインに移動するメソッド
    public void GoNextLine()
    {
        Index++;
    }
}
