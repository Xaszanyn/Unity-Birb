using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipelines : MonoBehaviour
{
    public static bool change;
    public float speed;
    public int interval;
    public float destination;

    public float minLoc = -3F;
    public float maxLoc = 3F;

    Rigidbody2D RB;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // if(change) {
        //     
        //     speed = CalculateSpeed(destination, interval);
        //     change = !change;
        //     RB.AddForce(new Vector2(0f, speed));
        // }
        // if(RB.position.y == destination) {
        //     moving = false;
        // }
        if(change) {
            destination = Random.Range(minLoc, maxLoc);
            speed = CalculateSpeed(destination, interval);
            RB.AddForce(new Vector2(0F, speed * 10000));
            change = !change;
        }
        if((destination > RB.position.y && speed < 0) || (destination < RB.position.y && speed > 0)) {
            RB.velocity = Vector2.zero;
        }
    }

    float CalculateSpeed(float destination, int interval) {
        return (destination - RB.position.y) / interval;
    }


}
