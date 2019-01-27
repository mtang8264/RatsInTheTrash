using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour 
{
    public int toPlace = -1;
    public bool lostItem;
    public textController tc;
    public DecorationHandler decoration;
    public bool trashedItem;

    public int numPlaced; //number of objects placed
    public bool grabScripts;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (SceneManager.GetActiveScene().name == "Home")
        {
            if(!grabScripts)
            {
                tc = FindObjectOfType<textController>();
                decoration = FindObjectOfType<DecorationHandler>();
                grabScripts = true;
            }
            if(toPlace != -1)
            {
                decoration.placing = true;
                decoration.placingIdx = toPlace;
                toPlace = -1;
            }
            if (lostItem) // if you didnt capture anything
            {
                tc.EnableTextBox(15, 16);
                lostItem = false;
            }
            else
            {
                if (decoration.placing) // if you capture...
                {
                    if (trashedItem) //...and throw it away
                    {
                        tc.EnableTextBox(16, 18);
                    }
                    else///hhh
                    {

                    }
                }

                else if (!tc.isActive && !decoration.placing) // timer acknowledgement
                {
                    if (numPlaced == 1)
                    {
                        tc.EnableTextBox(18,19);
                    }
                    else if (numPlaced == 2)
                    {
                        tc.EnableTextBox(19,20);
                    }
                    else if (numPlaced == 3)
                    {
                        tc.EnableTextBox(20,21);
                    }
                    else if (numPlaced == 4)
                    {
                        tc.EnableTextBox(21,22);
                    }
                    else if (numPlaced == 5)
                    {
                        tc.EnableTextBox(22,23);
                    }
                }
            }
        }
        else
        {
            grabScripts = false;
        }
	}
}
