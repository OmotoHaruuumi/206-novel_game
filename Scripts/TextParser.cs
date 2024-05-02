using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextParser : MonoBehaviour
{
    //�e�L�X�g�̋�؂�g�[�N�����w��
    private const char SEPARATE_MAIN_START = '�u';
    private const char SEPARATE_MAIN_END = '�v';
    private const char SEPARATE_PAGE = '&';
    private const char SEPARATE_COMMAND = '!';
    private const char COMMAND_SEPARATE_PARAM = '=';
    private const string COMMAND_BACKGROUND = "background";

    public string mainText = "";
    public string nameText = "";
    public Queue<char> _charQueue;   



    // ��������w�肵����؂蕶�����Ƃɋ�؂�A�L���[�Ɋi�[�������̂�Ԃ�
    public Queue<string> SeparatePage(string str)
    {
        string[] strs = str.Split(SEPARATE_PAGE);
        Queue<string> queue = new Queue<string>();
        foreach (string l in strs) queue.Enqueue(l);
        return queue;
    }

    //�������K�v�ȏ��ɕ������đ������
    public void ReadLine(string text,float captionSpeed)
    {
        string[] ts = text.Split(SEPARATE_MAIN_START);       //��������u�ŋ�؂��ă��X�g�ɓ����
        string name = ts[0];                                //�������ŏ��͖��O
        string main = ts[1].Remove(ts[1].LastIndexOf(SEPARATE_MAIN_END)); //���͖{���A�Ō�́v�����͍폜

        nameText = name;
        mainText = "";
        _charQueue = SeparateString(main);
        //�R���[�`�����Ăяo��
        StartCoroutine(ShowChars(captionSpeed));

    }

    //�{�����ꕶ����������֐�
    public Queue<char> SeparateString(string str)
    {
        // �������char�^�̔z��ɂ��� = 1�������Ƃɋ�؂�
        char[] chars = str.ToCharArray();
        Queue<char> charQueue = new Queue<char>();
        // foreach���Ŕz��chars�Ɋi�[���ꂽ������S�Ď��o��
        // �L���[�ɉ�����
        foreach (char c in chars) charQueue.Enqueue(c);
        return charQueue;
    }

    //���x�𒲐�����֐�
    private IEnumerator ShowChars(float wait)
    {
        // OutputChar���\�b�h��false��Ԃ�(=�L���[����ɂȂ�)�܂Ń��[�v����
        while (OutputChar())
            // wait�b�����ҋ@
            yield return new WaitForSeconds(wait);
        // �R���[�`���𔲂��o��
        yield break;
    }

    //�ꕶ���ǉ�����֐����\�����镶�����c���Ă��邩�����t���O
    private bool OutputChar()
    {
        // �L���[�ɉ����i�[����Ă��Ȃ����false��Ԃ�
        if (_charQueue.Count <= 0)
        {
            return false;
        }
        mainText += _charQueue.Dequeue();
        return true;
    }

    //�N���b�N���ꂽ���ɑS������C�ɕ\������
    public void OutputAllChar(float captionspeed)
    {
        // �R���[�`�����X�g�b�v
        StopCoroutine(ShowChars(captionspeed));
        // �L���[����ɂȂ�܂ŕ\��
        while (OutputChar()) ;
    }


}
