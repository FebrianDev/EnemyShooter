using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject instiateAI;
    public GameObject AI; 
    // Update is called once per frame
    void Update()
    {
        instiateAI = GameObject.FindWithTag("AI");
        if (instiateAI == null)
        {
            Instantiate(AI, transform.position, Quaternion.identity);
        }
    }
}
