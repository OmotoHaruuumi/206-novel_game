using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public SceneController sc;
    private string senario;
    private bool debug=false; //デバッグの時だけtrueにする

    // Start is called before the first frame update
    void Start()
    {
        sc = new SceneController(this);
        //チューとリアルをするかどうか判定する
        if(!tutorial.hadtutorial)
        {
            tutorial.hadtutorial = true;
            senario = "senariot";
        }
        else
        {
            senario = TitleManager.senario;
        }
        SetFirstScene(senario);
       
    }

    // Update is called once per frame
    void Update()
    {
        sc.WaitClick();
        sc.SetComponents();
    }

    void SetFirstScene(string senario)
    {
        if (senario == null || debug)
        {
            senario = "senario4";
        }
        sc.LoadSenario(senario);
        sc.SetScene("001");
    }

    

}
