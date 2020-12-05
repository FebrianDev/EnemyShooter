using UnityEngine;
using UnityEngine.UI;
public class AIShoot : MonoBehaviour
{
    //Deklarasi Variable
    public GameObject bulletMove;
    public Transform trans;
    private float time, jeda = 0.005f;
    Slider slider;
    //Fungsi start yang dijalankan pertama kali
    void Start()
    {
        slider = GameObject.FindWithTag("HealthAI").GetComponent<Slider>();
        //Cari GameObject yang mempunyai tag Player kemudian ambil component transformnya
        trans = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        //Dapatkan waktu pada setiap detik
        time += Time.deltaTime;    
        //fungsi untuk pergerakan AI pada sumbu X, AI akan bergerak kemanapun player pergi pada sumbu X
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(trans.transform.position.x, transform.position.y), 0.04f);
        //Jika time lebih besar dari jeda, maka
        if(time > jeda)
        {
            slider.value += 0.2f;
            //Membuat GameObject baru dengan object yang berasal dari bulletMove, dengan posisi dan rotasi seperti parentnya 
            Instantiate(bulletMove, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            //Set time menjadi 0
            time = 0;
            //Tambahkan waktu jeda untuk memperlambat pergerakan bullet
            jeda += 0.01f;
            //Jika jeda sudah lebih besar sama dengan 0.5 maka set jeda menjadi 0.005f
            if (jeda >= 0.5f)
                jeda = 0.005f;
        }
    }
}
