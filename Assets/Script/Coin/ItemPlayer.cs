using UnityEngine;
using UnityEngine.UI;
public class ItemPlayer : MonoBehaviour
{
    public Text textCoin, textHealth, textSpecialBullet;
    void Update()
    {
        textCoin.text = "Coin : "+DataItem.coin.ToString();
        textHealth.text = "Health : " + DataItem.health.ToString()+" (M)";
        textSpecialBullet.text = "Special Bullet : " + DataItem.specialBullet.ToString()+" (B)";
    }
}
