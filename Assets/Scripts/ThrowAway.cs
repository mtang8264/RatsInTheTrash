using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowAway : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Des);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Des()
    {
        if(Camera.main.GetComponent<DecorationHandler>().placing)
        {
            Camera.main.GetComponent<DecorationHandler>().placing = false;
            Camera.main.GetComponent<DecorationHandler>().placingIdx = -1;
        }
    }
}
