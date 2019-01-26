using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public int scene;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(load);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void load()
    {
        SceneManager.LoadScene(scene);
    }
}
