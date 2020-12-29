using UnityEngine.UI;
using UnityEngine;
using System.Collections;
public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletMove, sBullet;
    Slider slider;
    float time, jeda = 1f;
    bool healthRegenOn;
    void Start()
    {
        DataItem.coin = 0;
        healthRegenOn = false;
        slider = GameObject.FindWithTag("HealthPlayer").GetComponent<Slider>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (healthRegenOn) {
            StartCoroutine(HealthRegenOff());
            if (time > jeda)
            {
                slider.value += 2;
                time = 0f;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
          //  Shoot();
        }

        if(Input.GetKey(KeyCode.M) && DataItem.health > 0)
        {
            slider.value += 40;
            DataItem.health--;
        }

        if (Input.GetKey(KeyCode.N) && DataItem.healthRegen > 0)
        {
            StartCoroutine(HealthRegenOn());
            DataItem.healthRegen--;
        }

        if (Input.GetKey(KeyCode.B) && DataItem.specialBullet > 0)
        {
            Instantiate(sBullet, transform.position, Quaternion.identity);
            DataItem.specialBullet--;
        }
    }

    IEnumerator HealthRegenOn()
    {
        yield return new WaitForSeconds(10);
        healthRegenOn = true;
    }

    IEnumerator HealthRegenOff()
    {
        yield return new WaitForSeconds(60);
        healthRegenOn = false;
    }

    public void Shoot()
    {    
        Instantiate(bulletMove, transform.position, Quaternion.identity);   
    }

    public void HealthBoxUse()
    {
        if (DataItem.health > 0)
        {
            slider.value += 40;
            DataItem.health--;
        }
    }

    public void HealthRegenUse()
    {
        if(DataItem.healthRegen > 0)
        {
            StartCoroutine(HealthRegenOn());
            DataItem.healthRegen--;
        }
    }

    public void SpecialBulletUse()
    {
      if(DataItem.specialBullet > 0)
        {
            Instantiate(sBullet, transform.position, Quaternion.identity);
            DataItem.specialBullet--;
        }

    }
}
