using UnityEngine.UI;
using UnityEngine;

public class CoinGold : MonoBehaviour
{
    //Deklarasi object Slider
    Slider slider;
    void Start()
    {
        //Cari gameobject yang mempunyai tag HealthAI kemudian ambil component slidernya
        slider = GameObject.FindWithTag("HealthAI").GetComponent<Slider>();
    }
    void Update()
    {
        //Destroy Coin Gold jika sudah melewati 5 detik
        Destroy(gameObject, 10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Jika gamobject berbenturan dengan player maka tambahkan coin menjadi 2 dan destroy gameobject
        if (collision.gameObject.tag == "Player")
        {
            DataItem.coin += 2;
            Destroy(gameObject);
        }

        //Jika gamobject berbenturan dengan AI maka tambahkan value AI dan destroy gameobject
        if (collision.gameObject.tag == "AI")
        {
            slider.value += 4;
            Destroy(gameObject);
        }
    }
}
