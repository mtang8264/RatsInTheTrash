using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
    gameController game;
    Transform fisher;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("gameController").GetComponent<gameController>();
        fisher = GameObject.Find("FishingSpot").transform;
    }

    // Update is called once per frame
    void Update()
    {
        switch(game.controlScheme)
        {
            case gameController.ControlScheme.MOUSE:
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                break;
            case gameController.ControlScheme.PS4L:
                transform.position = fisher.position + new Vector3(Input.GetAxis("LH"), Input.GetAxis("LV")) * 5;
                break;
            case gameController.ControlScheme.PS4R:
                transform.position = fisher.position + new Vector3(Input.GetAxis("RH"), Input.GetAxis("RV")) * 5;
                break;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 5);
    }
}
