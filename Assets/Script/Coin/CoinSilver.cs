using UnityEngine.UI;
using UnityEngine;

public class CoinSilver : MonoBehaviour
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
            DataItem.coin += 1;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "AI")
        {
            slider.value += 1;
            Destroy(gameObject);
        }
    }
}
