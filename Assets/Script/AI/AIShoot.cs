using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
   
    public GameObject bulletMove;
    Transform trans;
    float time, jeda = 0.005f;
    void Start()
    {
        trans = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(trans.transform.position.x, transform.position.y), 0.04f);

        time += Time.deltaTime;
        if(time > jeda)
        {
            print(jeda);
            Instantiate(bulletMove, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            time = 0;
            jeda += 0.01f;

            if (jeda >= 0.5f)
                jeda = 0.005f;
        }

    }

}
