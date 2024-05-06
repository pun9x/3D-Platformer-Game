using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlowersManager : MonoBehaviour
{
    public TextMeshProUGUI flowersText;
    public static int flowerAmount;

    // Update is called once per frame
    void Update()
    {
        flowersText.text = "Flowers: " + flowerAmount + "/5";
    }
}
