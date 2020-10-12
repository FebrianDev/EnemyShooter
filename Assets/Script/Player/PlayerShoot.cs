using System;
using UnityEngine.UI;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletMove, sBullet;
    Slider slider;
    void Start()
    {
        slider = GameObject.FindWithTag("HealthPlayer").GetComponent<Slider>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(bulletMove, transform.position, Quaternion.identity);
        }

        if(Input.GetKey(KeyCode.M) && DataItem.health > 0)
        {
            slider.value += 40;
            DataItem.health--;
        }

        if (Input.GetKey(KeyCode.B) && DataItem.specialBullet > 0)
        {
            Instantiate(sBullet, transform.position, Quaternion.identity);
            DataItem.specialBullet--;
        }
    }

}
