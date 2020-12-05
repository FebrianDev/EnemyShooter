using UnityEngine;
using UnityEngine.UI;
public class BulletMove : MonoBehaviour
{
    //Deklarasi variable
    public Slider slider;
    public Transform target;
    private Rigidbody2D rigid;
    private Vector2 moveDirection;
    private float randDamage;
    //Fungsi start yang dijalankan pertama kali
    void Start()
    {
        //Cari gameobject yang mempunyai tag HealthPlayer kemudian ambil component slidernya
        slider = GameObject.FindWithTag("HealthPlayer").GetComponent<Slider>();
        //Cari GameObject yang mempunyai tag Player kemudian ambil component transformnya
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //Ambil component rigidbody2d pada gameobject
        rigid = GetComponent<Rigidbody2D>();
        //Dapatkan posisi target yang diincar
        moveDirection = (target.transform.position - transform.position).normalized * 10f;
        //Lakukan pergerakan bullet sesuai dengan target yang didapatkan
        rigid.velocity = new Vector2(moveDirection.x, moveDirection.y);
        //Destroy gameobject setelah 3detik
        Destroy(gameObject, 3);
    }

    //Fungsi update yang dijalankan terus menerus di setiap frame
    private void Update()
    {
        //Ambil value slider, kemudian buat kondisi jika value slider kurang dari sama dengan 0
        //maka, WinCondition set True dan Win Game AI
        if (slider.value <= 0)
        {
            WinCondition.winGame = "AI";
            WinCondition.win = true;
        }
    }

    //Fungsi jika terdapat benturan trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Jika gamobject berbenturan dengan GameObject yang ber tag Player atau ground, maka destroy gameobject
        if (collision.gameObject.tag.Equals("Player") || collision.gameObject.tag.Equals("Ground"))
            Destroy(gameObject);

        //Jika gameobject berbenturan dengan gameObject yang ber tag Player maka,
        if (collision.gameObject.tag.Equals("Player"))
        {
            //Panggil fungsi random untuk damage Player
            randDamage = Random.Range(0, 10);
            //kurangii slider value dg randDamage
            slider.value -= randDamage;
        }
    }
}
