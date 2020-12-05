using UnityEngine;
using UnityEngine.UI;
public class ItemPlayer : MonoBehaviour
{
    public Text textCoin, textHealth, textHealthRegen, textSpecialBullet;
    void Update()
    {
        textCoin.text = "Coin : "+DataItem.coin.ToString();
        textHealth.text = "H : " + DataItem.health.ToString()+" (M)";
        textHealthRegen.text = "HR : " + DataItem.healthRegen.ToString() + " (N)";
        textSpecialBullet.text = "SB : " + DataItem.specialBullet.ToString()+" (B)";
    }
}
