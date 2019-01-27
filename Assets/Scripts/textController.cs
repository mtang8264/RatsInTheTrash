using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class textController : MonoBehaviour
{
    public bool already;
    public bool isTyping;
    public bool cancelTyping;
    public float textSpeed;

    public int currentLine;
    public int endLine;

    public TextAsset dialogueDoc; // insert a .txt. for the text
    public string[] textLines;

    public Text theText;
    public GameObject textBox;

    public bool isActive;
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = textBox.GetComponent<Animator>();
        textLines = dialogueDoc.text.Split('\n');
       
    }

    void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.Space)) //press space to move the text forward C:
        {
            if (!isTyping)
            {
                currentLine += 1;
                if (currentLine == endLine)
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(Textscroll(textLines[currentLine]));
                }
            }

            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
                already = false;
            }
        }

        if (isActive && Input.GetKeyDown(KeyCode.Space) && already == false) // cancels text
        {
            already = true;
        }

        if (Input.GetKeyDown(KeyCode.Backspace)) // makes the currentline go back one
        {
            GoBack();
        }

    }


    public void EnableTextBox(int firstLine, int lastLine)
    {
        textBox.SetActive(true);
        currentLine = firstLine;
        endLine = lastLine;
        anim.SetBool("isActive", true);
        isActive = true;
        StartCoroutine(Textscroll(textLines[currentLine]));
    }

    public void DisableTextBox()
    {
        isActive = false;
        theText.text = "";
        anim.SetBool("isActive", false);
        //textBox.SetActive(false);

    }
    public void GoBack()
    {
        if (textLines[currentLine] != "" && currentLine - 1 != -1)
        {
            currentLine -= 1;
            theText.text = textLines[currentLine];
        }
    }

    private IEnumerator Textscroll(string lineoftext)
    {
        int letter = 0;
        theText.text = "";

        isTyping = true;
        cancelTyping = false;

        while (isTyping && !cancelTyping && (letter < lineoftext.Length - 1))
        {

            theText.text += lineoftext[letter];
            letter += 1;
            yield return new WaitForSeconds(textSpeed);
        }

        theText.text = lineoftext;
        isTyping = false;
        cancelTyping = false;
    }
}