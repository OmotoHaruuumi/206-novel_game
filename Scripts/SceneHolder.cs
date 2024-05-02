using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// SceneHolder�N���X: �V�[���̃e�L�X�g�f�[�^��ǂݍ��݁A�V�[���̊Ǘ����s���N���X
public class SceneHolder
{
    Dictionary<string, string> Senarios = new Dictionary<string, string>();

    //�e�L�X�g�t�@�C���̃p�X
    private string pass1 = "Texts/Senario1";
    private string pass2 = "Texts/Senario2";
    private string pass3 = "Texts/Senario3";
    private string pass4 = "Texts/Senario4";
    private string pass5 = "Texts/Senario5";


    // �V�[���̃��X�g
    public List<Scene> Scenes = new List<Scene>();

    // �V�[���R���g���[���[�ւ̎Q��
    private SceneController sc;

    // �R���X�g���N�^: �V�[���R���g���[���[���󂯎��A�������ƃe�L�X�g�̓ǂݍ��݂��s��
    public SceneHolder(SceneController sc)
    {
        this.sc = sc;
        Senarios["senario1"] = pass1;
        Senarios["senario2"] = pass2;
        Senarios["senario3"] = pass3;
        Senarios["senario4"] = pass4;
        Senarios["senario5"] = pass5;
    }

    // �e�L�X�g�̓ǂݍ��݂��s�����\�b�h
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

    // �e�L�X�g�f�[�^����͂��ăV�[���̃��X�g���쐬���郁�\�b�h
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

    // �w�肳�ꂽID�̃V�[�����������郁�\�b�h
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
            Debug.Log("���̃V�i���I�͑��݂��܂���");
            return null;
        }
    }
}

