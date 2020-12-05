using UnityEngine;
using UnityEngine.UI;

public class BulletMovePlayer : MonoBehaviour
{
    public Slider slider;
    Rigidbody2D rigid;
    public Transform trans;
    Vector2 moveDirection;
    float randDamage;
    void Start()
    {
        slider = GameObject.FindWithTag("HealthAI").GetComponent<Slider>();
        trans = GameObject.FindWithTag("AI").GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        moveDirection = (trans.transform.position - transform.position).normalized * 10f;
        rigid.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3);
    }
    private void Update()
    {
        if(slider.value <= 0)
        {
            WinCondition.winGame = "Player";
            WinCondition.win = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("AI") || collision.gameObject.tag.Equals("Ground"))
            Destroy(gameObject);

        if (collision.gameObject.tag.Equals("AI"))
        {
            randDamage = Random.Range(0, 10);
            slider.value -= randDamage;
        }
    }
}
