using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Linq;
using UnityEngine.EventSystems;

public class SceneController
{
    // �Q�[���̃}�l�[�W���[�N���X
    private GameManager gm;
    // GUI�̃}�l�[�W���[�N���X
    private GUIManager gui;
    // �V�[���̉�͂��s���N���X
    private SceneParser sp;
    // �V�[���̃f�[�^��ێ�����N���X
    private SceneHolder sh;
    // ���ʉ��̃}�l�[�W���[�N���X
    private SEManager se;
    //BGM�̃}�l�[�W���[�N���X
    private BGMManager bgm;
    // �w�i�̃}�l�[�W���[�N���X
    private BGManager bg;
    //�����G��ύX����N���X
    private CharacterManager cm;

    private string tempText;

    // �e�L�X�g�\���p�̃V�[�P���X
    private Sequence textSeq;

    // ���ݑI�������\������Ă��邩�������t���O
    public static bool isOptionsShowed;

    // �e�L�X�g�\�����x
    private float captionSpeed = 0.05f;

    // ���݂̃V�[��
    private Scene currentScene;

    //���݂�BGM
    private string stage_bgm;

    // �X�R�A���L�^
    public static int score;

    GameObject clickedObject;

    //�R���[�`������
    public bool isCoroutine = false;

    //���܃{�P����Ԃ�
    public bool canBoke;

    //�����{�P��
    public bool isForce1 = false;
    public bool isForce2 = false;

    //panel
    public GameObject mainpanel;
    public GameObject speakerpanel;

    //�{�P��{�^�����������Ƃ��ɕ\�������I������ێ����郊�X�g
    List<(string,string)> nextoptions = new List<(string, string)>();

    // �R���X�g���N�^
    public SceneController(GameManager gm)
    {
        // �e�}�l�[�W���[�̃C���X�^���X�擾
        this.gm = gm;
        gui = GameObject.FindObjectOfType<GUIManager>();
        se = GameObject.FindObjectOfType<SEManager>();
        bg = GameObject.FindObjectOfType<BGManager>();
        bgm = GameObject.FindObjectOfType<BGMManager>();
        cm = GameObject.FindObjectOfType<CharacterManager>();
        // �V�[���̉�͂ƃf�[�^�̕ێ��̂��߂̃N���X
        sp = new SceneParser(this);
        sh = new SceneHolder(this);
        // �e�L�X�g�\���p�̃V�[�P���X�̏�����
        textSeq = DOTween.Sequence();
        textSeq.Complete();
        // �X�R�A�̏�����
        score = 0;
        //�p�l���̎擾
        mainpanel = gui.mainTextPanel;
        speakerpanel = gui.nameTextPanel;
    }


    //�V�i���I�̓ǂݍ���
    public void LoadSenario(string senario)
    {
        sh.Load(senario);
    }

    // �N���b�N�ҋ@
    public void WaitClick()
    {
        if (currentScene.ID != null)
        {
            if (Input.GetMouseButtonDown(0)) //�{�^�����N���b�N���ꂽ��
            { 
                clickedObject = null;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2d = Physics2D.Raycast((Vector2)Input.mousePosition, (Vector2)ray.direction);
                if(!hit2d)
                {
                    if (!isOptionsShowed)
                    {
                        Debug.Log("pressed");
                        se.PlaySE("click");
                        SetNextProcess();
                    }
                }
                else
                {
                    clickedObject = hit2d.collider.gameObject;//�Q�[���I�u�W�F�N�g���擾
                    if(clickedObject == gui.BokeruButton)
                    {
                        BokeruButtonClick();
                        se.PlaySE("bokeru");
                    }
                }

           
            }
        }
    }

    public void BokeruButtonClick()
    {
        if(isCoroutine)
        {
            return;
        }
        else
        {
            ShowOptions(nextoptions);
        }
    }


    // �R���|�[�l���g�̐ݒ�
    public void SetComponents()
    {
        // �I�����p�l���̕\��/��\��
        gui.ButtonPanel.gameObject.SetActive(isOptionsShowed);

        // ���̃y�[�W�A�C�R���̕\��/��\��
        gui.nextPageIcon.SetActive((!textSeq.IsActive() || !textSeq.IsPlaying()) && !isOptionsShowed);
        //�{�P��{�^���̊Ǘ�
        gui.BokeruButton.SetActive(((!textSeq.IsActive() || !textSeq.IsPlaying()) && !isOptionsShowed && canBoke) || isCoroutine);
        gui.FakeButton.SetActive((!(!textSeq.IsActive() || !textSeq.IsPlaying()) && !isOptionsShowed && canBoke));
    }

    // ���̃V�[���̐ݒ�
    public void SetScene(string id)
    {
        // �w�肳�ꂽID�̃V�[�����擾
        currentScene = sh.findScene(id);
        currentScene = currentScene.Clone();
        Debug.Log(currentScene.ID);
        if (currentScene.ID == null) Debug.LogError("scenario not found");
        // ���̏�����
        SetNextProcess();
    }

    // ���̏����̐ݒ�
    public void SetNextProcess()
    {
        // �e�L�X�g�\�����Ȃ�Ō�܂Ńe�L�X�g��\��
        if (textSeq.IsActive() && textSeq.IsPlaying())
        {
            SetmainText(tempText);
        }
        // �e�L�X�g�\�����łȂ���Ύ��̍s���p�[�X����
        else
        {
            sp.ReadLines(currentScene);
        }
    }

    // ���C���e�L�X�g�̐ݒ�
    public void SetmainText(string maintext)
    {
        tempText = maintext;
        Text text = mainpanel.GetComponentInChildren<Text>();

        if(maintext=="null")
        {
            mainpanel.SetActive(false);
        }
        else
        {
            mainpanel.SetActive(true);
        }

        if (textSeq.IsActive() && textSeq.IsPlaying())
        {
            textSeq.Complete();
        }
        else
        {
            text.text = "";
            textSeq = DOTween.Sequence();
            textSeq.Append
                (text.DOText
                (
                    maintext,
                    maintext.Length * captionSpeed
                ).SetEase(Ease.Linear));
        }
    }

    // �X�s�[�J�[�̐ݒ�
    public void SetSpeaker(string name)
    {
        Text text = speakerpanel.GetComponentInChildren<Text>(); ;
        if (name == "null")
        {
            speakerpanel.SetActive(false);
        }
        else
        {
            text.text = name;
            speakerpanel.SetActive(true);
        }
        
    }

    // �I�����̐ݒ�
    public void SetOptions(List<(string text, string nextScene)> options)
    {
        nextoptions = options;
    }

    //�{�P��{�^���������ꂽ���̑I�����̕\��
    public void ShowOptions(List<(string text, string nextScene)> options)
    {
        if(isForce2)
        {
            isOptionsShowed = true;
            cm.CharacterImageChange("null");
            SetmainText("null");
            SetSpeaker("null");
            bgm.BGMChange("heart");
            createoption(options);
            isForce2 = false;
        }
        else if (options[0].Item1 == "stay")
        {
            isOptionsShowed = false;
            SetBokeflag("false");
            SetSpeaker("�X�M��");
            SetChara("null");
            SetmainText("���΂ɍ��̓{�P�悤��������");
        }
        else
        {
            if(!isForce1)
            {
                cm.CharacterImageChange("null");
                isCoroutine = true;
            }
            isOptionsShowed = true;
            SetmainText("null");
            SetSpeaker("null");
            CoroutineManager.Instance.StartCoroutine(StartBoke(options));
            isForce1 = false;
        }
    }

    private IEnumerator StartBoke(List<(string text, string nextScene)> options)
    {
        Debug.Log("wait");
        bgm.BGMChange("heart");
        yield return new WaitForSeconds(2.0f); // delay�b�҂�
        gui.PushedButton.SetActive(false);
        cm.CharacterImageChange("null");
        createoption(options);
    }

    public void createoption(List<(string text, string nextScene)> options)
    {
        isCoroutine = false;
        canBoke = false;
        foreach (var o in options)
        {
            // �I�����{�^���̐����Ɛݒ�
            Button b = Object.Instantiate(gui.OptionButton);
            Text text = b.GetComponentInChildren<Text>();
            text.font = gui.normalFont;
            text.text = o.text;
            b.onClick.AddListener(() => onClickedOption(o.nextScene));
            b.transform.SetParent(gui.ButtonPanel, false);
        }
    }



    // �I�������N���b�N���ꂽ���̏���
    public void onClickedOption(string nextID = "")
    {
        se.PlaySE("click");
        bgm.BGMChange(stage_bgm);
        // ���̃V�[����
        SetScene(nextID);
        isOptionsShowed = false;
        // �I�����p�l�����̃{�^���̍폜
        foreach (Transform t in gui.ButtonPanel)
        {
            UnityEngine.Object.Destroy(t.gameObject);
        }
    }

    //�{�P�t���O�̐ݒ�
    public void SetBokeflag(string bokeflag)
    {
        canBoke = System.Convert.ToBoolean(bokeflag);
    }

    // ���ʉ��̐ݒ�
    public void SetSE(string seName)
    {
        se.PlaySE(seName);
    }

    // BGM�̐ݒ�
    public void SetBGM(string BGMName)
    {
        // �w�i�摜�̐ݒ�
        stage_bgm = BGMName;
        bgm.BGMChange(BGMName);
    }


    // �w�i�̐ݒ�
    public void SetBG(string BackGroundName)
    {
        // �w�i�摜�̐ݒ�
        bg.BackGroundChange(BackGroundName);
    }

    //�����G�̐ݒ�
    public void SetChara(string ImageName)
    {
        cm.CharacterImageChange(ImageName);
    }

    // �X�R�A�̐ݒ�
    public void SetScore(int point)
    {
        score += point;
    }

    // ���U���g��ʂւ̑J��
    public void Result()
    {
        SceneManager.LoadScene("RESULT");
    }

    public void Force1()
    {
        isForce1 = true;
        se.PlaySE("bokeru");
        BokeruButtonClick();
    }

    public void Force2()
    {
        isForce2 = true;
        BokeruButtonClick();
    }

    // �X�R�A�̎擾
    public static int getscore()
    {
        return score;
    }
}