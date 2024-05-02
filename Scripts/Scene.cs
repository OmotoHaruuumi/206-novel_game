using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scene�N���X: �Q�[���̃V�[����Θb�V�[���̏����Ǘ�����N���X
public class Scene
{
    // �V�[���̈�ӂ̎��ʎq
    public string ID { get; private set; }

    // �V�[�����̑Θb���C���̃��X�g
    public List<string> Lines { get; private set; } = new List<string>();

    // ���݂̑Θb���C���̃C���f�b�N�X
    public int Index { get; private set; } = 0;

    // �R���X�g���N�^: �V�[�����쐬����ۂɕK�v�ȏ���ݒ�
    public Scene(string ID = "")
    {
        this.ID = ID;
    }

    // �V�[���̕������쐬���郁�\�b�h
    public Scene Clone()
    {
        return new Scene(ID)
        {
            Index = 0,
            Lines = new List<string>(Lines)
        };
    }

    // �V�[���̑Θb���I���������ǂ����𔻒肷�郁�\�b�h
    public bool IsFinished()
    {
        return Index >= Lines.Count;
    }

    // ���݂̑Θb���C�����擾���郁�\�b�h
    public string GetCurrentLine()
    {
        return Lines[Index];
    }

    // ���̑Θb���C���Ɉړ����郁�\�b�h
    public void GoNextLine()
    {
        Index++;
    }
}
