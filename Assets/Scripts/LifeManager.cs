using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public static int livesAmount = 3;
    private int intervalLive;
    public TextMeshProUGUI liveText;

    void Update()
    {
        intervalLive = livesAmount;
        liveText.text = "Lives: " + intervalLive;

        if(intervalLive == 0)
        {
            //Scene 3 is game over scene
            SceneManager.LoadScene(3);
        }
    }

}
