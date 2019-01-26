using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public int lastQuad = -1;
    public int currentQuad = -1;
    public List<int> quadrants = new List<int>();

    public Transform reel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(reel.position.x > transform.position.x)
        {
            if(reel.position.y > transform.position.y)
            {
                currentQuad = 1;
            }
            else
            {
                currentQuad = 4;
            }
        }
        else
        {
            if (reel.position.y > transform.position.y)
            {
                currentQuad = 2;
            }
            else
            {
                currentQuad = 3;
            }
        }


    }
}
