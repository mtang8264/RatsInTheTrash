using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drift : MonoBehaviour
{
    Vector3 last, next;
    AnimationCurve bam;

    float start, goal;

    float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(goal < Time.time)
        {
            ChangeDirection();
        }

        Vector3 motion = Vector3.Lerp(last, next, (goal - start) / 0.5f);

        transform.Translate(motion * Time.deltaTime * speed);
    }

    void ChangeDirection()
    {
        start = Time.time;
        goal = start + 0.5f;

        last = next;
        next = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5));
    }

    private void OnTriggerStay(Collider other)
    {
        ChangeDirection();
    }
}
