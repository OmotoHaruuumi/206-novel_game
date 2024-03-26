using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public SceneController sc;

    // Start is called before the first frame update
    void Start()
    {
        sc = new SceneController(this);
        SetFirstScene();
       
    }

    // Update is called once per frame
    void Update()
    {
        sc.WaitClick();
        sc.SetComponents();
    }

    void SetFirstScene()
    {
        sc.SetScene("001");
    }

    

}
