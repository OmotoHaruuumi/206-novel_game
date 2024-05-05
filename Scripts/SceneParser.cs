using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneParser 
{
    private SceneController sc;
    private const string SEPARATE_LINE ="#";
    private const string COMMAND_SPEAKER ="speaker=";
    private const string COMMAND_OPTION = "options=";
    private const string BOKEFLAG = "bokeflag=";
    private const string COMMAND_NEXT = "next=";
    private const string COMMAND_SE = "se=";
    private const string COMMAND_SCORE = "score=";
    private const string COMMAND_BACKGROUND = "background=";
    private const string COMMAND_BGM = "bgm=";
    private const string COMMAND_CHARA = "chara=";
    private const string SEPARATE_MAIN_START = "{";
    private const string SEPARATE_MAIN_END = "}";
    private const string SECTION_FORCE1 = "force1";
    private const string SECTION_FORCE2 = "force2";
    private const string SECTION_RESULT = "result";
    private const string SECTION_STAGE = "stage";
    private const string SECTION_END = "end=";


    public SceneParser(SceneController sc)
    {
        this.sc = sc;
    }

    public void ReadLines(Scene s)
    {
        if (s.Index >= s.Lines.Count) return;
        var line = s.GetCurrentLine();
        var text = "";

        if(line.Contains(SEPARATE_LINE))
        {
            while(true)
            {
                if (!line.Contains(SEPARATE_LINE)) break;
                line = line.Replace(SEPARATE_LINE,"");

                if (line.Contains(COMMAND_SPEAKER))
                {
                    line = line.Replace(COMMAND_SPEAKER,""); //speakerÇ∆Ç¢Ç§ï∂éöóÒÇçÌèú
                    line = line.Replace(COMMAND_SE, "");
                    line = line.Replace("\n", "").Replace("\r", "");
                    sc.SetSpeaker(line);
                }
                else if (line.Contains(COMMAND_OPTION))
                {
                    var options = new List<(string, string)>();
                    while (true)
                    {
                        s.GoNextLine();
                        line = line = s.Lines[s.Index];
                        if (line.Contains(SEPARATE_MAIN_START))
                        {
                            line = line.Replace(SEPARATE_MAIN_START, "").Replace(SEPARATE_MAIN_END, "");
                            var splitted = line.Split(',');
                            options.Add((splitted[0], splitted[1]));
                        }
                        else
                        {
                            sc.SetOptions(options);
                            break;
                        }
                    }
                }
                else if (line.Contains(BOKEFLAG))
                {
                    line = line.Replace(BOKEFLAG, "");
                    line = line.Replace("\n", "").Replace("\r", "");
                    sc.SetBokeflag(line);
                }
                else if (line.Contains(COMMAND_NEXT))
                {
                    line = line.Replace(COMMAND_NEXT, "");
                    sc.SetScene(line);
                }
                else if (line.Contains(COMMAND_SE))
                {
                    line = line.Replace(COMMAND_SE,"");
                    line = line.Replace("\n","").Replace("\r","");
                    sc.SetSE(line);
                }
                else if (line.Contains(COMMAND_BGM))
                {
                    line = line.Replace(COMMAND_BGM,"");
                    line = line.Replace("\n", "").Replace("\r", "");
                    sc.SetBGM(line);
                }
                else if (line.Contains(COMMAND_BACKGROUND))
                {
                    line = line.Replace(COMMAND_BACKGROUND,"");
                    line = line.Replace("\n","").Replace("\r","");
                    Debug.Log(line);
                    sc.SetBG(line);
                }
                else if (line.Contains(COMMAND_CHARA))
                {
                    line = line.Replace(COMMAND_CHARA, "");
                    line = line.Replace("\n", "").Replace("\r", "");
                    sc.SetChara(line);
                }
                else if (line.Contains(COMMAND_SCORE))
                {
                    line = line.Replace(COMMAND_SCORE, "");
                    line = line.Replace("\n", "").Replace("\r", "");
                    int point = int.Parse(line);
                    sc.SetScore(point);
                }
                else if (line.Contains(SECTION_RESULT))
                {
                    sc.Result();
                }
                else if (line.Contains(SECTION_STAGE))
                {
                    sc.Stage();
                }
                else if (line.Contains(SECTION_END))
                {
                    line = line.Replace(SECTION_END, "");
                    line = line.Replace("\n", "").Replace("\r", "");
                    Debug.Log(line);
                    sc.End(line);
                }
                else if (line.Contains(SECTION_FORCE1))
                {
                    sc.Force1();
                }
                else if (line.Contains(SECTION_FORCE2))
                {
                    sc.Force2();
                }

                s.GoNextLine();
                if (s.IsFinished()) break;
                line = s.GetCurrentLine();
            }
        }
        if(line.Contains(SEPARATE_MAIN_START))
        {
            line = line.Replace(SEPARATE_MAIN_START, "");

            while(true)
            {
                if(line.Contains(SEPARATE_MAIN_END))
                {
                    line = line.Replace(SEPARATE_MAIN_END, "");
                    text += line;
                    s.GoNextLine();
                    break;
                }
                else
                {
                    text += line;
                }

                s.GoNextLine();
                if (s.IsFinished()) break;
                line = s.GetCurrentLine();
            }
            Debug.Log(text);
            text = line.Replace("\n", "").Replace("\r", "");
            if (!string.IsNullOrEmpty(text)) sc.SetmainText(text);
        }

    }
}
