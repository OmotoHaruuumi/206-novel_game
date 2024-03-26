using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IconVibrations : MonoBehaviour
{
    private void Start()
    {
        // �����ʒu�ۑ�
        Vector3 initialPosition = transform.position;

        // �㉺�ɐU��������Tween�̐ݒ�
        Sequence vibrationSequence = DOTween.Sequence()
            .Append(transform.DOMoveY(initialPosition.y + 10f, 0.05f).SetEase(Ease.OutQuad)) // ��ɐU��
            .Append(transform.DOMoveY(initialPosition.y - 10f, 0.2f).SetEase(Ease.InOutQuad)) // ���ɐU��
            .Append(transform.DOMoveY(initialPosition.y, 0.1f).SetEase(Ease.InQuad)); // ���̈ʒu�ɖ߂�

        // �J��Ԃ�
        vibrationSequence.SetLoops(-1, LoopType.Restart);
    }
}