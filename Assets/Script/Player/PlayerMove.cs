using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rigid;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * 10f, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime * 10f, Space.World);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector2.up * Time.deltaTime * 10f, Space.World);
        }
    }
}
