using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepArSession : MonoBehaviour
{

    public static keepArSession instance;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
}
