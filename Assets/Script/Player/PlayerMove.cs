using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    bool isGround = false;
    public Joystick joystick;
    private void Start()
    {
        joystick = GameObject.FindWithTag("Joystick").GetComponent<Joystick>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Mobile Version
        float dirX = joystick.Horizontal;
        transform.Translate(new Vector2(dirX * 10f * Time.fixedDeltaTime, 0));

        float dirY = joystick.Vertical;
        if (dirY > 0.5)
        {
            if (isGround)
            {
                rigid.velocity = Vector2.zero;
                rigid.AddForce(Vector2.up * 400);
            }
        }
        else if (dirY < 0)
        {
            if (!isGround)
            {
                rigid.velocity = new Vector2(0, -10);
            }
        }

        //Desktop Version
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * 10f, 0));
        }

        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            rigid.AddForce(Vector3.up * 300);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGround = false;
    }
}
