using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletMove : MonoBehaviour
{
    public Slider slider;
    public Transform target;
    Rigidbody2D rigid;
    Vector2 moveDirection;
    float randDamage;
    void Start()
    {
        slider = GameObject.FindWithTag("HealthPlayer").GetComponent<Slider>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        moveDirection = (target.transform.position - transform.position).normalized * 10f;
        rigid.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        if (slider.value <= 0)
        {
            WinCondition.winGame = "AI";
            WinCondition.win = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") || collision.gameObject.tag.Equals("Ground"))
            Destroy(gameObject);

        if (collision.gameObject.tag.Equals("Player"))
        {
            randDamage = Random.Range(0, 10);
            slider.value -= randDamage;
        }
    }
}
