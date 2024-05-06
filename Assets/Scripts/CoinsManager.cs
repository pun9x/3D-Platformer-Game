using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public static int coin = 0;

    void Update()
    {
        coinsText.text = "Coins: " + coin;

    }

}
