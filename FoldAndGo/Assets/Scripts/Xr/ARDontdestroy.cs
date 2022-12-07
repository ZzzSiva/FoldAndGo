using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARDontdestroy : MonoBehaviour
{

    public static ARDontdestroy instance;

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
