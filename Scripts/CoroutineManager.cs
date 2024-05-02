using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager instance;
    public static CoroutineManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject managerObject = new GameObject("CoroutineManager");
                instance = managerObject.AddComponent<CoroutineManager>();
            }
            return instance;
        }
    }
}
