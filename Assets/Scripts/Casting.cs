using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Casting : MonoBehaviour
{
    MotionSerialRead motion;

    public bool ready = false;
    public bool wasReady = false;
    public int cast = 1;
    public int gy;
    public float tolerance = 100;
    public float gap = 200;
    public float ahhhh;
    public float direction;

    // Start is called before the first frame update
    void Start()
    {
        motion = Camera.main.gameObject.GetComponent<MotionSerialRead>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = motion.axis[1];
        ahhhh = motion.axis[0];

        gy = -motion.mag;

        //is the rod up
        if(motion.axis[0] > 60 && !wasReady)
        {
            ready = true;
            wasReady = true;
        }
        else if(motion.axis[0] < 30 && motion.axis[0] > -30)
        {
            ready = false;

            if(cast > tolerance && wasReady && transform.position.y < 1)
            {
                Vector3 pos = new Vector3();
                if(cast > tolerance + gap)
                {
                    pos = new Vector3(0, 9, 5);
                } 
                else if (cast > tolerance && tolerance < tolerance + gap)
                {
                    pos = new Vector3(0, 4.5f, 5);
                }

                if(motion.axis[1] < -60)
                {
                    pos = new Vector3(-5, pos.y, 5);
                }
                else if(motion.axis[1] < 60)
                {
                    pos = new Vector3(0, pos.y, 5);
                }
                else
                {
                    pos = new Vector3(5, pos.y, 5);
                }
                transform.position = pos;
            }
        }

        if(gy > tolerance && gy > cast && wasReady)
        {
            cast = gy;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(0,0,5);
            cast = -1;
            wasReady = false;
        }
    }
}
