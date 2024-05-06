using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadMainMenuScene(3));
    }


    IEnumerator LoadMainMenuScene(int second)
    {
        yield return new WaitForSeconds(second);
        LifeManager.livesAmount += 3;
        CoinsManager.coin = 0;
        FlowersManager.flowerAmount = 0;

        //Scene 0 is a main menu scene
        SceneManager.LoadScene(0);
    }
}
