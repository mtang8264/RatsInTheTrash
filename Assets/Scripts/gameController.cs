using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gameController : MonoBehaviour 
{
    public bool gotWashed;
    public bool startTut;
    public int toPlace = -1;
    public bool lostItem;
    public textController tc;
    public DecorationHandler decoration;
    public bool trashedItem; //did u trash a thing

    public bool didCount; //happens once after an item is put down

    public bool grabScripts; //so that the textmanager and decorations handler can be accessed w/o errors

    public ControlScheme controlScheme = ControlScheme.MOUSE;

    public enum ControlScheme { MOUSE, PS4L, PS4R };

    public static TrashGet[] collectedItems = {
        new TrashGet("box"),
        new TrashGet("computer"),
        new TrashGet("duck"),
        new TrashGet("eet"),
        new TrashGet("fpoon"),
        new TrashGet("glowstick"),
        new TrashGet("lid"),
        new TrashGet("log"),
        new TrashGet("message"),
        new TrashGet("phone"),
        new TrashGet("pumice"),
        new TrashGet("ringpop"),
        new TrashGet("sardines")
    };

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (SceneManager.GetActiveScene().name == "Home")
        {
            if (!grabScripts)
            {

                tc = FindObjectOfType<textController>();
                decoration = FindObjectOfType<DecorationHandler>();

                grabScripts = true;
            }

            if (toPlace != -1)
            {
                decoration.placing = true;
                decoration.placingIdx = toPlace;
                toPlace = -1;
            }


            if (tc.screenOverlay.GetComponent<Image>().color == Color.black) // go to the fishing scene
            {
                if (decoration.decorations.Count == 0)
                {
                    SceneManager.LoadScene("Tutorial");
                }
                else
                {
                    SceneManager.LoadScene("Fishing");
                }
            }

            if (tc.screenOverlay.GetComponent<Image>().color == Color.white) //restart
            {
                gotWashed = false;
                File.Delete(Application.persistentDataPath + "/rats.rts");
                SceneManager.LoadScene("WashedUp");
            }


            if (lostItem) // if you didnt capture anything
            {
                tc.EnableTextBox(15, 16);
                lostItem = false;
            }
            else
            {
                if (trashedItem) //...and throw it away
                {
                    tc.EnableTextBox(16, 18);
                    trashedItem = false;
                }

                else if (Input.GetMouseButtonDown(0) && !trashedItem && decoration.placing)
                {
                    int startLine = decoration.trash[decoration.placingIdx].GetComponent<Trash>().startLine;
                    int endLine = decoration.trash[decoration.placingIdx].GetComponent<Trash>().endLine;

                    tc.EnableTextBox(startLine, endLine);
                }

                else if (!tc.isActive && !decoration.placing && !didCount) // timer acknowledgement
                {
                    if (decoration.decorations.Count == 1)
                    {
                        tc.EnableTextBox(18, 19);
                    }
                    else if (decoration.decorations.Count == 2)
                    {
                        tc.EnableTextBox(19, 20);
                    }
                    else if (decoration.decorations.Count == 3)
                    {
                        tc.EnableTextBox(20, 21);
                    }
                    else if (decoration.decorations.Count == 4)
                    {
                        tc.EnableTextBox(21, 22);
                    }
                    else if (decoration.decorations.Count == 5)
                    {
                        tc.EnableTextBox(22, 23);
                    }
                    didCount = true;
                }
                else if (decoration.decorations.Count == 5 && didCount) // restarting the gamee
                {
                    tc.panelAnim.SetBool("fadeWhite", true);
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            if (!startTut)
            {
                didCount = false;
                grabScripts = false;
                tc = FindObjectOfType<textController>();
                tc.EnableTextBox(11, 15);
                startTut = true;
            }
        }
        else if (SceneManager.GetActiveScene().name == "WashedUp")
        {
            if (!gotWashed)
            {
                startTut = false;
                didCount = false;
                grabScripts = false;
                tc = FindObjectOfType<textController>();
                tc.EnableTextBox(0, 11);
                gotWashed = true; // to make sure the text box doesnt keep starting up
            }
            if (gotWashed && !tc.isActive)
            {
                tc.panelAnim.SetBool("fadeBlack", true);
            }
            if (tc.screenOverlay.GetComponent<Image>().color == Color.black) // go to the fishing scene
            {
                SceneManager.LoadScene("Home");
            }
        }

        else
        {
            didCount = false;
            grabScripts = false; 
        }
	}
}

public class TrashGet
{
    public string name;
    public bool got;

    public TrashGet(string s)
    {
        name = s;
        got = false;
    }
}