using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        movement = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime,0, Input.GetAxis("Vertical") * Time.deltaTime);
        movement *= speed;
        transform.Translate(transform.InverseTransformVector(movement));
    }
}
