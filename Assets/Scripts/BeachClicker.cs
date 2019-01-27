using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeachClicker : MonoBehaviour
{
    public DecorationHandler decoration;
    public Texture2D trash;
    public gameController gc;

    public static bool over = false;

    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<gameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        over = true;
    }
    private void OnMouseExit()
    {
        over = false;
    }

    private void OnMouseDown()
    {
        if(decoration.placing)
        {
            decoration.placing = false;
            decoration.placingIdx = -1;
            gc.trashedItem = true;
        }
        else
        {
            over = false;
            GameObject.Find("Sound").GetComponent<Sounds>().GoToBeach();
            SceneManager.LoadScene(1);
        }
    }
}
