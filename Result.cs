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

    private AudioSource audioSource = null;

    [SerializeField]
    public AudioClip resultSE,Click;


    // Start is called before the first frame update
    void Start()
    {
        scoreresult = GameObject.FindObjectOfType<ScoreResult>();
        if (scoreresult == null)
            Debug.Log("None");
        score =  SceneController.getscore();
        scoreresult.CountUp(score);
        audioSource = GetComponent<AudioSource>();
        PlaySE(resultSE);
    }


    //���X�^�[�g���N���b�N���ꂽ���̓���
    public void ReStart()
    {
        StartCoroutine(ReStartWithDelay("SampleScene"));
    }

    //�^�C�g���ɖ߂邪�N���b�N���ꂽ���̓���
    public void BackTitle()
    {
        StartCoroutine(ReStartWithDelay("Title"));
    }

    private IEnumerator ReStartWithDelay(string changescene)
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
