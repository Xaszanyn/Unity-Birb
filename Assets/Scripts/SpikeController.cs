using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{

    public static bool control;
    public bool direction;
    public  List<float> slots;

    public  int hardness; // 1-6


    public  GameObject spike;


     void IterateNextSide(bool direction) {

        List<float> slotsC = new List<float>(slots);
        int count = 7;

        for(int i = 0; i < hardness; i++) {
            int random = Random.Range(0, count);
            CreateSpike(slotsC[random], direction);
            slotsC.Remove(slotsC[random]);
            count--;
        }
    }

     void DestroyThisSide() {
        GameObject[] spikes = GameObject.FindGameObjectsWithTag("Spike");
        if(spikes.Length == 0) {
            return;
        } else {
            for(int i = 0; i < spikes.Length; i++) {
                Rigidbody2D SRB = spikes[i].GetComponent<Rigidbody2D>();
                int force = SRB.position.x > 0 ? 100 : -100;
                SRB.AddForce(new Vector2(force, 0));
            }
        }
    }

     void CreateSpike(float location, bool direction) {
        // GameObject obj = Instantiate(spike) as GameObject;

        float x = direction ? 8.6F : -8.6F;
        int angle = direction ? 180 : 0;
        Instantiate(spike, new Vector2(x, location), Quaternion.Euler(Vector3.up * angle));
    }





    
    void Start()
    {
        slots = new List<float>();
        slots.Add(4.44F);
        slots.Add(-4.44F);
        slots.Add(2.95F);
        slots.Add(-2.95F);
        slots.Add(1.4F);
        slots.Add(-1.4F);
        slots.Add(0F);

        hardness = 4;

        direction = false;


    }

    void Update()
    {
        if(control) {
            DestroyThisSide();
            IterateNextSide(direction);
            direction = !direction;
            control = !control;
        }
    }
}
