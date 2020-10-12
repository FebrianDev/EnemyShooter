using UnityEngine;

public class ItemShop : MonoBehaviour
{
    public GameObject menuShop;

    private void Start()
    {
        menuShop.SetActive(false);
        DataItem.coin = 0;
        DataItem.health = 0;
        DataItem.specialBullet = 0;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            Time.timeScale = 0f;
            menuShop.SetActive(true);
        }
    }

    public void HealthShop()
    {
        if(DataItem.coin >= 25)
            DataItem.health += 1;
            DataItem.coin -= 25;
    }

    public void SBShop()
    {
        if(DataItem.coin >= 30)
        {
            DataItem.specialBullet += 1;
            DataItem.coin -= 30;
        }
    }

    public void CloseShop()
    {
        Time.timeScale = 1f;
        menuShop.SetActive(false);
    }
}
