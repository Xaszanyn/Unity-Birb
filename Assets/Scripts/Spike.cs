using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    Rigidbody2D RB;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        if(RB.position.x > 0) {
            RB.AddForce(new Vector2(-150, 0));
        } else {
            RB.AddForce(new Vector2(150, 0));
        }
        Destroy(gameObject, 5);
    }
    void Update()
    {
        if(Mathf.Abs(RB.position.x) < 7.6) {
            RB.velocity = Vector2.zero;
        }
    }
}
