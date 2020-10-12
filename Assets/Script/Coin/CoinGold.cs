using UnityEngine.UI;
using UnityEngine;

public class CoinGold : MonoBehaviour
{
    Slider slider;
    void Start()
    {
        slider = GameObject.FindWithTag("HealthAI").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DataItem.coin += 2;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "AI")
        {
            slider.value += 2;
            Destroy(gameObject);
        }
    }
}
