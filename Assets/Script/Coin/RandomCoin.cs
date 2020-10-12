using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCoin : MonoBehaviour
{
    public GameObject[] coin;
    float time, jeda = 0.5f;
    int random;
    float randXPos;
    float randYPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        random = Random.Range(0, 2);
        randXPos = Random.Range(-8f, 8f);
        randYPos = Random.Range(-4, 5f);
        time += Time.deltaTime;
        if(time > jeda)
        {
            Instantiate(coin[random], new Vector2(randXPos, randYPos), Quaternion.identity);
            time = 0;
        }

    }
 
}
