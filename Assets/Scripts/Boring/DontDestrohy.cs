using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestrohy : MonoBehaviour
{
    public static DontDestrohy instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
