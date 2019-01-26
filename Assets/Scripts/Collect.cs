using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Col);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Col()
    {
        DecorationHandler.toPlace = GameObject.Find("FishingSpot").GetComponent<FishingSpot>().floater;
        SceneManager.LoadScene(0);
    }
}
