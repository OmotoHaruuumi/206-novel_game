using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextParser : MonoBehaviour
{
    //テキストの区切りトークンを指定
    private const char SEPARATE_MAIN_START = '「';
    private const char SEPARATE_MAIN_END = '」';
    private const char SEPARATE_PAGE = '&';
    private const char SEPARATE_COMMAND = '!';
    private const char COMMAND_SEPARATE_PARAM = '=';
    private const string COMMAND_BACKGROUND = "background";

    public string mainText = "";
    public string nameText = "";
    public Queue<char> _charQueue;   



    // 文字列を指定した区切り文字ごとに区切り、キューに格納したものを返す
    public Queue<string> SeparatePage(string str)
    {
        string[] strs = str.Split(SEPARATE_PAGE);
        Queue<string> queue = new Queue<string>();
        foreach (string l in strs) queue.Enqueue(l);
        return queue;
    }

    //文字列を必要な情報に分解して代入する
    public void ReadLine(string text,float captionSpeed)
    {
        string[] ts = text.Split(SEPARATE_MAIN_START);       //文字列を「で区切ってリストに入れる
        string name = ts[0];                                //分けた最初は名前
        string main = ts[1].Remove(ts[1].LastIndexOf(SEPARATE_MAIN_END)); //次は本文、最後の」から後は削除

        nameText = name;
        mainText = "";
        _charQueue = SeparateString(main);
        //コルーチンを呼び出す
        StartCoroutine(ShowChars(captionSpeed));

    }

    //本文を一文字ずつ分ける関数
    public Queue<char> SeparateString(string str)
    {
        // 文字列をchar型の配列にする = 1文字ごとに区切る
        char[] chars = str.ToCharArray();
        Queue<char> charQueue = new Queue<char>();
        // foreach文で配列charsに格納された文字を全て取り出し
        // キューに加える
        foreach (char c in chars) charQueue.Enqueue(c);
        return charQueue;
    }

    //速度を調整する関数
    private IEnumerator ShowChars(float wait)
    {
        // OutputCharメソッドがfalseを返す(=キューが空になる)までループする
        while (OutputChar())
            // wait秒だけ待機
            yield return new WaitForSeconds(wait);
        // コルーチンを抜け出す
        yield break;
    }

    //一文字追加する関数兼表示する文字が残っているか示すフラグ
    private bool OutputChar()
    {
        // キューに何も格納されていなければfalseを返す
        if (_charQueue.Count <= 0)
        {
            return false;
        }
        mainText += _charQueue.Dequeue();
        return true;
    }

    //クリックされた時に全文を一気に表示する
    public void OutputAllChar(float captionspeed)
    {
        // コルーチンをストップ
        StopCoroutine(ShowChars(captionspeed));
        // キューが空になるまで表示
        while (OutputChar()) ;
    }


}
