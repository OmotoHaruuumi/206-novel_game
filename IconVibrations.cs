using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IconVibrations : MonoBehaviour
{
    private void Start()
    {
        // 初期位置保存
        Vector3 initialPosition = transform.position;

        // 上下に振動させるTweenの設定
        Sequence vibrationSequence = DOTween.Sequence()
            .Append(transform.DOMoveY(initialPosition.y + 10f, 0.05f).SetEase(Ease.OutQuad)) // 上に振動
            .Append(transform.DOMoveY(initialPosition.y - 10f, 0.2f).SetEase(Ease.InOutQuad)) // 下に振動
            .Append(transform.DOMoveY(initialPosition.y, 0.1f).SetEase(Ease.InQuad)); // 元の位置に戻る

        // 繰り返し
        vibrationSequence.SetLoops(-1, LoopType.Restart);
    }
}