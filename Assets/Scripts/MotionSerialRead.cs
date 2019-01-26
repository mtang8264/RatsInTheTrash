using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
using System;

public class MotionSerialRead : MonoBehaviour
{
    public float[] axis = new float[3];
    public float gy;
    public int mag;

    Transform cube;

    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.Find("Cube").transform;
        UduinoManager.Instance.OnDataReceived += Instance_OnDataReceived;;
    }

    // Update is called once per frame
    void Update()
    {
        UduinoManager.Instance.alwaysRead = true;

        if (Input.GetKey(KeyCode.Space))
            UduinoManager.Instance.sendCommand("r");
    }

    void Instance_OnDataReceived(string data, UduinoDevice device)
    {
        //Debug.Log(data);
        string[] strings = data.Split('|');
        for (int i = 0; i < 3; i ++)
        {
            axis[i] = float.Parse(strings[i]);
        }

        gy = float.Parse(strings[3]);
        mag = int.Parse(strings[4]);

        cube.eulerAngles = (new Vector3(-axis[0], axis[1],0));
    }
}
