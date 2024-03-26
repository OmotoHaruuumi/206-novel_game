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


    // Start is called before the first frame update
    void Start()
    {
        scoreresult = GameObject.FindObjectOfType<ScoreResult>();
        if (scoreresult == null)
            Debug.Log("None");
        score =  SceneController.getscore();
        scoreresult.CountUp(score);
    }


    //クリックされた時の動作
    public void ReStart()
    {
        StartCoroutine(ReStartWithDelay());
    }
    private IEnumerator ReStartWithDelay()
    {
        yield return new WaitForSeconds(scenechangedelay); // delay秒待つ
        SceneManager.LoadScene("SampleScene");
    }
}
