using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public Image charaImage;

    [SerializeField]
    Sprite sugiru,teacher,classmateA,classmateB,classmateC,classmates,bokutou,raidou,kawai,MC,kawarai,siranaiA;

    void Start()
    {
       
    }

    public void CharacterImageChange(string image_name)
    {
        charaImage.enabled = true;
        Debug.Log(image_name);
        if(image_name == "null")
        {
            charaImage.color = new Color32(255,255,255,0);
        }
        else
        {
            charaImage.color = new Color32(255, 255, 255, 255); ;
        }
        if (image_name == "sugiru1")
        {
            charaImage.sprite = sugiru;
        }
        else if (image_name == "teacher1")
        {
            charaImage.sprite = teacher;
        }
        else if (image_name == "classmateA")
        {
            charaImage.sprite = classmateA;
        }
        else if (image_name == "classmates1")
        {
            charaImage.sprite = classmates;
        }
        else if (image_name == "classmateB")
        {
            charaImage.sprite = classmateB;
        }
        else if (image_name == "classmateC")
        {
            charaImage.sprite = classmateC;
        }
        else if (image_name == "bokutou")
        {
            charaImage.sprite = bokutou;
        }
        else if (image_name == "raidou")
        {
            charaImage.sprite = raidou;
        }
        else if (image_name == "kawai")
        {
            charaImage.sprite = kawai;
        }
        else if (image_name == "siranaiA")
        {
            charaImage.sprite = siranaiA;
        }
        else if (image_name == "kawarai")
        {
            charaImage.sprite = kawarai;
        }
        else if (image_name == "MC")
        {
            charaImage.sprite = MC;
        }
        else
        {
            charaImage.enabled = false;
        }
    }


}
