using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class starttext : MonoBehaviour
{
    [SerializeField]
    private Text text;
    // Start is called before the first frame update
    void Start()
    { 
        text.transform.DOScale(1.2f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        TextColorChange();
    }

    private void TextColorChange()
    {
        text.DOColor(ChangeColor(), 1f).OnComplete(TextColorChange);
    }

    private Color ChangeColor()
    {
        Color nowColor = text.color;
        if (nowColor == Color.white)
            return Color.red;
        else if (nowColor == Color.red)
            return Color.blue;
        else if (nowColor == Color.blue)
            return Color.green;
        else if (nowColor == Color.green)
            return Color.yellow;
        else
            return Color.white;
    }
}
