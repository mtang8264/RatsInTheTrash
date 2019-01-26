using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class ArduinoSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.pinMode(AnalogPin.A0, PinMode.Output);
        UduinoManager.Instance.pinMode(AnalogPin.A3, PinMode.Input);
    }

    // Update is called once per frame
    void Update()
    {
        UduinoManager.Instance.analogWrite(0, 120);
        Debug.Log("" + UduinoManager.Instance.analogRead(0));
    }
}
