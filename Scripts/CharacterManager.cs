using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public Image charaImage;

    [SerializeField]
    Sprite sugiru,free,teacher,classmateA,classmateB,classmateC,classmates,bokutou,dobokutou,mbokutou,dombokutou,raidou,doraidou,mraidou,rraidou,kawai,mkawai,dokawai,MC,mascot,siranaiA,worker,popcorn,sinja,staff,syukatu,mensetukanA,mensetukanB,mensetukanC,foreigner,izou,madam1,madam2,gafa,gafa2,rayquaza,shen,relative,button,shibuta;
    void Start()
    {
       
    }

    // スケールを設定する関数
    public void SetScale(Vector2 scale)
    {
        // ImageのRectTransformコンポーネントを取得
        RectTransform rectTransform = charaImage.GetComponent<RectTransform>();

        // スケールを設定
        rectTransform.localScale = scale;
    }

    public void SetPosition(Vector2 position)
    {
        // ImageのRectTransformコンポーネントを取得
        RectTransform rectTransform = charaImage.GetComponent<RectTransform>();

        // 位置を設定
        rectTransform.anchoredPosition = position;
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

       
        
         SetPosition(new Vector2(650,0));
      


        if (image_name == "sugiru1")
        {
                charaImage.sprite = sugiru;
            SetPosition(new Vector2(0, 0));
            SetScale(new Vector2(10f, 8f));
        }
        else if (image_name == "free")
        {
            charaImage.sprite = free;
            SetPosition(new Vector2(-50, -300));
            SetScale(new Vector2(20f, 20f));
        }
        else if (image_name == "teacher1")
        {
            charaImage.sprite = teacher;
            SetScale(new Vector2(10f, 8f));
        }
        else if (image_name == "classmateA")
        {
            charaImage.sprite = classmateA;
            SetScale(new Vector2(10f, 8f));
        }
        else if (image_name == "classmates1")
        {
            charaImage.sprite = classmates;
            SetScale(new Vector2(15f, 8f));
        }
        else if (image_name == "classmateB")
        {
            charaImage.sprite = classmateB;
            SetScale(new Vector2(10f, 8f));
        }
        else if (image_name == "classmateC")
        {
            charaImage.sprite = classmateC;
            SetScale(new Vector2(10f, 8f));
        }
        else if (image_name == "bokutou")
        {
                if (Result.doretry)
                {
                    charaImage.sprite = dobokutou;
                    SetScale(new Vector2(12f, 9.6f));
                    SetPosition(new Vector2(550, -250));
                }
                else
                {
                    charaImage.sprite = bokutou;
                    SetScale(new Vector2(12f, 9.6f));
                }
        }
        else if (image_name == "mbokutou")
        {
            if(TitleManager.senario=="senario3")
            {
                SetPosition(new Vector2(-650, -400));
            }
            else if(TitleManager.senario=="senario4")
            {
                SetPosition(new Vector2(650, -400));
            }
            if (Result.doretry)
            {
                charaImage.sprite = dombokutou;
                SetScale(new Vector2(12f, 9.6f));
                SetPosition(new Vector2(550, -250));
            }
            else
            {
                charaImage.sprite = mbokutou;
                SetScale(new Vector2(12f, 9.6f));
            }
        }
        else if (image_name == "raidou")
        {
            if (Result.doretry)
            {
                charaImage.sprite = doraidou;
                SetScale(new Vector2(12f, 9.6f));
                SetPosition(new Vector2(550, -250));
            }
            else
            {
               charaImage.sprite = raidou;
               SetScale(new Vector2(20f, 16f));
               SetPosition(new Vector2(650, -400));
            }
        }
        else if (image_name == "kawai")
        {
            if (Result.doretry)
            {
                charaImage.sprite = dokawai;
                SetScale(new Vector2(12f, 9.6f));
                SetPosition(new Vector2(550, -250));
            }
            else
            {
                charaImage.sprite = kawai;
                SetScale(new Vector2(15f, 12f));
                SetPosition(new Vector2(650, -400));
            }
        }
        else if (image_name == "mkawai")
        {
            charaImage.sprite = mkawai;
            SetScale(new Vector2(15f, 12f));
            SetPosition(new Vector2(650, -400));
        }
        else if (image_name == "mraidou")
        {
            charaImage.sprite = mraidou;
            SetScale(new Vector2(15f, 10f));
        }
        else if (image_name == "rraidou")
        {
            charaImage.sprite = rraidou;
            SetScale(new Vector2(9.9f, 6.6f));
            SetPosition(new Vector2(650, -30));
        }
        else if (image_name == "siranaiA")
        {
            charaImage.sprite = siranaiA;
            SetScale(new Vector2(10f, 8f));
        }
        else if (image_name == "mascot")
        {
            charaImage.sprite = mascot;
            SetScale(new Vector2(10f, 8f));
        }
        else if (image_name == "MC")
        {
            charaImage.sprite = MC;
            SetScale(new Vector2(7f, 7f));
        }
        else if (image_name == "worker")
        {
            charaImage.sprite = worker;
            SetScale(new Vector2(9f, 7f));
        }
        else if (image_name == "sinja")
        {
            charaImage.sprite = sinja;
            SetScale(new Vector2(10f, 8f));
        }
        else if (image_name == "staff")
        {
            charaImage.sprite = staff;
            SetScale(new Vector2(10f, 8f));
        }
        else if (image_name == "syukatu")
        {
            charaImage.sprite = syukatu;
            SetPosition(new Vector2(0, 0));
            SetScale(new Vector2(15f, 6f));
        }
        else if (image_name == "mensetukanA")
        {
            charaImage.sprite = mensetukanA;
            SetScale(new Vector2(10f, 8f));
        }
        else if (image_name == "mensetukanB")
        {
            charaImage.sprite = mensetukanB;
            SetScale(new Vector2(10f, 8f));
        }
        else if (image_name == "mensetukanC")
        {
            charaImage.sprite = mensetukanC;
            SetScale(new Vector2(13f, 8f));
        }
        else if (image_name == "foreigner")
        {
            charaImage.sprite = foreigner;
            SetPosition(new Vector2(650, -150));
            SetScale(new Vector2(15f, 15f));
        }
        else if (image_name == "madam1")
        {
            charaImage.sprite = madam1;
            SetScale(new Vector2(13f, 8f));
        }
        else if (image_name == "madam2")
        {
            charaImage.sprite = madam2;
            SetScale(new Vector2(13f, 8f));
        }
        else if (image_name == "izou")
        {
            charaImage.sprite = izou;
            SetScale(new Vector2(13f, 8f));
        }
        else if (image_name == "gafa")
        {
            charaImage.sprite = gafa;
            SetScale(new Vector2(13f, 8f));
            SetPosition(new Vector2(200, 0));
        }
        else if (image_name == "gafa2")
        {
            charaImage.sprite = gafa2;
            SetPosition(new Vector2(200,80));
            SetScale(new Vector2(13f, 8f));
        }
        else if (image_name == "rayquaza")
        {
            charaImage.sprite = rayquaza;
            SetScale(new Vector2(13f, 8f));
        }
        else if (image_name == "shen")
        {
            charaImage.sprite = shen;
            SetScale(new Vector2(13f, 8f));
        }
        else if (image_name == "relative")
        {
            charaImage.sprite = relative;
            SetScale(new Vector2(13f, 8f));
        }
        else if (image_name == "shibuta")
        {
            charaImage.sprite = shibuta;
            SetScale(new Vector2(10f, 7f));
            SetPosition(new Vector2(350, 0));
        }
        else if (image_name == "button")
        {
            charaImage.sprite = button;
            SetScale(new Vector2(8f, 4.5f));
            SetPosition(new Vector2(0, -130));
        }
        else
        {
            charaImage.enabled = false;
        }
    }


}
