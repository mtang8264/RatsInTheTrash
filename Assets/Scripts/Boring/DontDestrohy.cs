﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestrohy : MonoBehaviour
{
    public static bool d = false;
    // Start is called before the first frame update
    void Start()
    {
        if (d)
            Destroy(gameObject);
        d = true;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
