using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;


public class BGManager : MonoBehaviour
{

    public Image bgImage;

    [SerializeField]
    Sprite school1, school2,amusement;

    void Start()
    {
        bgImage.color = new Color32(255, 255, 255, 255);
    }

    public void BackGroundChange(string image_name)
    {
        bgImage.enabled = true;
        if (image_name == "normal_school")
        {
            bgImage.sprite = school1;
        }
        else if (image_name == "dark_school")
        {
            bgImage.sprite = school2;
            bgImage.color = new Color32(206, 0, 0, 255);
        }
        else if (image_name == "amusement")
        {
            bgImage.sprite = amusement;
        }
        else if (image_name == "dark_amusement")
        {
            bgImage.sprite = amusement;
            bgImage.color = new Color32(206, 0, 0, 255);
        }
        else
        {
            bgImage.enabled = false;
        }
    }
}
