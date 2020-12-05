using UnityEngine;
using UnityEngine.UI;
public class SpecialBulletMove : MonoBehaviour
{
    public Slider slider;
    public Transform trans;
   
    void Start()
    {
        slider = GameObject.FindWithTag("HealthAI").GetComponent<Slider>();
        trans = GameObject.FindWithTag("AI").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, trans.transform.position, 1f);

        if (slider.value <= 0)
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
            slider.value -= 30;
        }
    }
}
