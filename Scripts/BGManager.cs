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
    Sprite school1, school2, amusement, popcorn, mery, dangerous, meetingroom, office, hunter, airport, garage, funeral, kaiji, M1, suka, raou,room,road;

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
            bgImage.color = new Color32(255, 255, 255, 255);
        }
        else if (image_name == "dark_school")
        {
            bgImage.sprite = school2;
            bgImage.color = new Color32(206, 0, 0, 255);
        }
        else if (image_name == "amusement")
        {
            bgImage.sprite = amusement;
            bgImage.color = new Color32(255, 255, 255, 255);
        }
        else if (image_name == "dark_amusement")
        {
            bgImage.sprite = amusement;
            bgImage.color = new Color32(206, 0, 0, 255);
        }
        else if (image_name == "popcorn")
        {
            bgImage.sprite = popcorn;
            bgImage.color = new Color32(255, 255, 255, 255);
        }
        else if (image_name == "mery")
        {
            bgImage.sprite = mery;
        }
        else if (image_name == "dangerous")
        {
            bgImage.sprite = dangerous;
            bgImage.color = new Color32(255, 255, 255, 255);
        }
        else if (image_name == "office")
        {
            bgImage.sprite = office;
            bgImage.color = new Color32(255, 255, 255, 255);
        }
        else if (image_name == "meetingroom")
        {
            bgImage.sprite = meetingroom;
            bgImage.color = new Color32(255, 255, 255, 255);
        }
        else if (image_name == "hunter")
        {
            bgImage.sprite = hunter;
            bgImage.color = new Color32(255, 255, 255, 255);
        }
        else if (image_name == "ãÛç`")
        {
            bgImage.sprite = airport;
            bgImage.color = new Color32(255, 255, 255, 255);
        }
        else if (image_name == "garage")
        {
            bgImage.sprite = garage;
            bgImage.color = new Color32(255, 255, 255, 255);
        }
        else if (image_name == "ëíéÆèÍ")
        {
            bgImage.sprite = funeral;
            bgImage.color = new Color32(255, 255, 255, 255);
        }
        else if (image_name == "kaiji")
        {
            bgImage.sprite = kaiji;
            bgImage.color = new Color32(255, 255, 255, 255);
        }
        else if (image_name == "suka")
        {
            bgImage.sprite = suka;
            bgImage.color = new Color32(255, 255, 255, 255);
        }
        else if (image_name == "M1")
        {
            bgImage.sprite = M1;
            bgImage.color = new Color32(255, 255, 255, 255);
        }
        else if (image_name == "dead")
        {
            bgImage.sprite = raou;
            bgImage.color = new Color32(255, 255, 255, 255);
        }
        else if (image_name == "room")
        {
            bgImage.sprite = room;
            bgImage.color = new Color32(255, 255, 255, 255);
        }
        else if (image_name == "road")
        {
            bgImage.sprite = road;
            bgImage.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            bgImage.enabled = false;
        }
    }
}
