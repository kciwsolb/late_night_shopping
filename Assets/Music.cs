using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music instance;
    public static Music Instance { get { return instance; } }

    private void EnforceSingleton()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }


    private void Awake()
    {
        EnforceSingleton();
        DontDestroyOnLoad(gameObject);
    }
}
