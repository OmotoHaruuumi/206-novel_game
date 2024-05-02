using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    private float scenechangedelay = 0.5f;

    private int score;

    private ScoreResult scoreresult;

    [SerializeField]
    private GameObject nextpanel;
    [SerializeField]
    private GameObject dopanel;

    private AudioSource audioSource = null;

    [SerializeField]
    public AudioClip goodresult,badresult,Click;

    //�h���g���C���[�h���ǂ���
    public static bool doretry;

    // Start is called before the first frame update
    void Start()
    {
        scoreresult = GameObject.FindObjectOfType<ScoreResult>();
        if (scoreresult == null)
            Debug.Log("None");
        score =  SceneController.getscore();
        scoreresult.CountUp(score);
        audioSource = GetComponent<AudioSource>();
        if (score > 500)
        {
            PlaySE(goodresult);
        }
        else
        {
            PlaySE(badresult);
        }
    }

    //Next���N���b�N���ꂽ���̓���
    public void Next()
    {
        PlaySE(Click);
        nextpanel.SetActive(true);
    }

    //���X�^�[�g���N���b�N���ꂽ���̓���
    public void ReStart()
    {
        doretry = false;
        StartCoroutine(ReStartWithDelay("SampleScene",scenechangedelay));
    }

    //�h���g���C���N���b�N���ꂽ���̓���
    public void DoReStart()
    {
        doretry = true;
        dopanel.SetActive(true);
        StartCoroutine(ReStartWithDelay("SampleScene",2.0f));
    }

    //�^�C�g���ɖ߂邪�N���b�N���ꂽ���̓���
    public void BackTitle()
    {
        doretry = false;
        StartCoroutine(ReStartWithDelay("Title",scenechangedelay));
    }

    private IEnumerator ReStartWithDelay(string changescene,float scenechangedelay)
    {
        PlaySE(Click);
        yield return new WaitForSeconds(scenechangedelay); // delay�b�҂�
        SceneManager.LoadScene(changescene);
    }



    public void PlaySE(AudioClip clip)
    {
        if(audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("AudioSource���ݒ肳��Ă��܂���");
        }
    }

}
