using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public static Coin instance;

    public int coins = 0;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI bulletText;

    private int totalShotsEarned = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        coinText.text = coins.ToString();
        bulletText.text = "0";
    }

    
    void Update()
    {
        
    }

    public void AddCoin()
    {
            coins += 1;
            coinText.text = coins.ToString();

        
        if (coins % 3 == 0) // Update shots every 3 coins
        {
            Shoot shootScript = FindObjectOfType<Shoot>(); // Find the Shoot script
            if (shootScript != null)
            {
                
                if (shootScript.availableShots == 0)
                {
                    shootScript.availableShots = coins / 3;
                }
                else 
                {
                    totalShotsEarned = coins / 3;
                    shootScript.availableShots = Mathf.Max(1, shootScript.availableShots + totalShotsEarned);
                }
                bulletText.text = shootScript.availableShots.ToString();
            }
            coins = 0;
            coinText.text = coins.ToString();
        }
    }

}
