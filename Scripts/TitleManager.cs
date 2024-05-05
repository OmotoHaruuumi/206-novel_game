using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TitleManager : MonoBehaviour
{
   
    public static string senario;
    private float scenechangedelay = 1f;
    private AudioSource audioSource = null;

    //各ステージをクリアしているか
    public static bool cleard1;
    public static bool cleard2;
    public static bool cleard3;
    public static bool cleard4;

    [SerializeField]
    public AudioClip Click;

    [SerializeField]
    GameObject button_stage2, button_stage3, button_stage4, button_stage5;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        button_stage2.SetActive(cleard1);
        button_stage3.SetActive(cleard2);
        button_stage4.SetActive(cleard3);
        button_stage5.SetActive(cleard4);
    }

    public void Button1()
    {
        senario = "senario1";
        StartScene();
    }

    public void Button2()
    {
        senario = "senario2";
        StartScene();
    }

    public void Button3()
    {
        senario = "senario3";
        StartScene();
    }

    public void Button4()
    {
        senario = "senario4";
        StartScene();
    }

    public void Button5()
    {
        senario = "senario5";
        StartScene();
    }

    //ボタンがクリックされた時の動作
    public void StartScene()
    {
        PlaySE(Click);
        StartCoroutine(StartWithDelay());
    }
    private IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(scenechangedelay); // delay秒待つ
        SceneManager.LoadScene("SampleScene");
    }

    public void PlaySE(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("AudioSourceが設定されていません");
        }
    }



}
