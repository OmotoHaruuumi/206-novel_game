using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndRoll : MonoBehaviour
{
    //�X�N���[���X�s�[�h
    private float textScrollSpeed = 100;
    //�e�L�X�g�̐����ʒu
    private float limitPosition = 4100f;
    //�G���h���[�����I���������ǂ���
    private bool isStopEndRoll;

    // Update is called once per frame
    void Update()
    {
        if(isStopEndRoll)
        {
            return;
        }
        else
        {
            if(transform.position.y <= limitPosition)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + textScrollSpeed * Time.deltaTime);
            }
            else
            {
                isStopEndRoll = true;
                StartCoroutine(BackTitle());
            }
        }
    }
    private IEnumerator BackTitle()
    {
        Debug.Log("endroll is finished");
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Title");
    }
}
