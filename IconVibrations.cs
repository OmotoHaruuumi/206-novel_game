using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IconVibrations : MonoBehaviour
{
    private void Start()
    {
        // ‰ŠúˆÊ’u•Û‘¶
        Vector3 initialPosition = transform.position;

        // ã‰º‚ÉU“®‚³‚¹‚éTween‚Ìİ’è
        Sequence vibrationSequence = DOTween.Sequence()
            .Append(transform.DOMoveY(initialPosition.y + 10f, 0.05f).SetEase(Ease.OutQuad)) // ã‚ÉU“®
            .Append(transform.DOMoveY(initialPosition.y - 10f, 0.2f).SetEase(Ease.InOutQuad)) // ‰º‚ÉU“®
            .Append(transform.DOMoveY(initialPosition.y, 0.1f).SetEase(Ease.InQuad)); // Œ³‚ÌˆÊ’u‚É–ß‚é

        // ŒJ‚è•Ô‚µ
        vibrationSequence.SetLoops(-1, LoopType.Restart);
    }
}