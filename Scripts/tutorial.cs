using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour
{
    public static bool hadtutorial;

    //ÉRÉãÅ[É`ÉìíÜÇ©Ç«Ç§Ç©
    public bool isCoroutine;

    public AudioSource audioSource=null;

    public AudioClip Click;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isCoroutine = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(hadtutorial);
            if (hadtutorial)
            {
                StartCoroutine(StartWithDelay("StageChoice"));
            }
            else
            {
                if (isCoroutine)
                {
                    return;
                }
                else
                {
                    isCoroutine = true;
                    StartCoroutine(StartWithDelay("SampleScene"));
                }
            }
        }
    }

    private IEnumerator StartWithDelay(string scene)
    {
        Debug.Log("start tutorial");
        PlaySE(Click);
        yield return new WaitForSeconds(1f); // delayïbë“Ç¬
        SceneManager.LoadScene(scene);
    }

    public void PlaySE(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("AudioSourceÇ™ê›íËÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒ");
        }
    }
}
