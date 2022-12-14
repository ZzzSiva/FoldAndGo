using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARKeep : MonoBehaviour
{
    public static ARKeep instance;


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
