using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public SceneController sc;
    private string senario;

    // Start is called before the first frame update
    void Start()
    {
        sc = new SceneController(this);
        senario = TitleManager.senario;
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
        if (senario == null)
        {
            senario = "senario4";
        }
        sc.LoadSenario(senario);
        sc.SetScene("001");
    }

    

}
