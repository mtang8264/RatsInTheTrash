using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpot : MonoBehaviour
{
    public int floater = -1;

    // Start is called before the first frame update
    void Start()
    {
        while(floater == -1)
        {
            floater = Random.Range(0, 10);

            if(gameController.collectedItems[floater].got)
            {
                floater = -1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = DecorationHandler.trash2[floater].GetComponent<SpriteRenderer>().sprite;
    }
}
