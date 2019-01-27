using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Circle : MonoBehaviour
{
    bool over;

    public int lastQuad = -1;
    public int currentQuad = -1;
    public List<int> quadrants = new List<int>();

    public int rotation = 4;

    public Transform reel;

    // Start is called before the first frame update
    void Start()
    {
        quadrants.RemoveRange(0,quadrants.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (over)
            quadrants = new List<int>();

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

        if (quadrants.Count > rotation * 4)
        {
            quadrants.RemoveAt(0);
        }

        if (lastQuad != currentQuad)
        {
            quadrants.Add(currentQuad);
            lastQuad = currentQuad;

        }

        bool captured = true;
        bool left = false;
        int lookingFor = quadrants[0];
        int greater = lookingFor + 1;
        greater = greater > 4 ? 1 : greater;
        int lesser = lookingFor - 1;
        lesser = lesser < 1 ? 4 : lesser;
        if(quadrants[1] == greater)
        {
            left = true;
        }
        else if(quadrants[1] == lesser)
        {
            left = false;
        }

        if(left)
        {
            for (int i = 0; i < quadrants.Count; i ++)
            {
                if(quadrants[i] != lookingFor)
                {
                    captured = false;
                }
                lookingFor++;
                lookingFor = lookingFor > 4 ? 1 : lookingFor;
            }
        }
        else
        {
            for (int i = 0; i < quadrants.Count; i ++)
            {
                if(quadrants[i] != lookingFor)
                {
                    captured = false;
                }
                lookingFor--;
                lookingFor = lookingFor < 1 ? 4 : lookingFor;
            }
        }

        if(captured && quadrants.Count > rotation * 4 -2)
        {
            DecorationHandler.toPlace = GetComponent<FishingSpot>().floater;
            SceneManager.LoadScene(0);
        }
    }

    private void OnMouseOver()
    {
        over = true;
    }
    private void OnMouseExit()
    {
        over = false;
    }
}
