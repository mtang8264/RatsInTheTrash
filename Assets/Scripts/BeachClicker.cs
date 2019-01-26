using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeachClicker : MonoBehaviour
{
    public DecorationHandler decoration;
    public Texture2D trash;

    public static bool over = false;

    // Start is called before the first frame update
    void Start()
    {

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
        }
        else
        {
            over = false;
            SceneManager.LoadScene(1);
        }
    }
}
