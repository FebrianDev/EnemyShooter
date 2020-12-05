using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    bool isGround = true;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float dirX = CrossPlatformInputManager.GetAxis("Horizontal") * 10f * Time.deltaTime;
        transform.Translate(Vector3.right * dirX);

        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * 10f);
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetKey(KeyCode.Space) && isGround)
        {
            rigid.AddForce(Vector3.up * 500);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
}
