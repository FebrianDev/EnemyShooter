using UnityEngine;

public class RandomCoin : MonoBehaviour
{
    public GameObject[] coin;
    float time; 
    public static float jeda = 2f;
    int random;
    float randXPos;
    float randYPos;
   
    void Update()
    {
        random = Random.Range(0, 2);
        randXPos = Random.Range(-8f, 8f);
        randYPos = Random.Range(-4, 5f);
        time += Time.deltaTime;
        if(time > jeda)
        {
            Instantiate(coin[random], new Vector2(randXPos, randYPos), Quaternion.identity);
            time = 0;
        }

    }
 
}
