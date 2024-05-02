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

    //ドリトライモードかどうか
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

    //Nextがクリックされた時の動作
    public void Next()
    {
        PlaySE(Click);
        nextpanel.SetActive(true);
    }

    //リスタートがクリックされた時の動作
    public void ReStart()
    {
        doretry = false;
        StartCoroutine(ReStartWithDelay("SampleScene",scenechangedelay));
    }

    //ドリトライがクリックされた時の動作
    public void DoReStart()
    {
        doretry = true;
        dopanel.SetActive(true);
        StartCoroutine(ReStartWithDelay("SampleScene",2.0f));
    }

    //タイトルに戻るがクリックされた時の動作
    public void BackTitle()
    {
        doretry = false;
        StartCoroutine(ReStartWithDelay("Title",scenechangedelay));
    }

    private IEnumerator ReStartWithDelay(string changescene,float scenechangedelay)
    {
        PlaySE(Click);
        yield return new WaitForSeconds(scenechangedelay); // delay秒待つ
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
            Debug.Log("AudioSourceが設定されていません");
        }
    }

}
