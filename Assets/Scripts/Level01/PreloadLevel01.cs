using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloadLevel01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLevel(1));
    }

    IEnumerator LoadLevel(float second)
    {
        yield return new WaitForSeconds(second);
        //Scene 2 is Level 01 scene
        SceneManager.LoadScene(2);
    }

}
