using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SceneHolder 
{
    [SerializeField]
    private string textFile = "Texts/Senario";


    public List<Scene> Scenes = new List<Scene>();
    private SceneController sc;

    public SceneHolder(SceneController sc)
    {
        this.sc = sc;
        Load();
    }

    public void Load()
    {
        TextAsset textasset = Resources.Load<TextAsset>(textFile);
        string[] ts = textasset.text.Split('\n');
        Scenes = Parse(ts);
    }


    public List<Scene> Parse(string[] list)
    {
        var scenes = new List<Scene>();
        var scene = new Scene();
        foreach (string line in list)
        {
            if (line.Contains("#scene"))
            {
                var ID = line.Replace("#scene=", "");
                scene = new Scene(ID);
                scenes.Add(scene);
            }
            else
            {
                scene.Lines.Add(line);
            }
        }
        return scenes;
    }


    public Scene findScene(string id)
    {
        foreach(Scene s in Scenes)
        {
            if (s.ID.Trim() == id.Trim())
            {
                return s;
            }
        }
        return null;
    }

}
