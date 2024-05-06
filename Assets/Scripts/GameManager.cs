using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioClip buttonSound;
    private AudioSource gameManagerSound;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        QuitGame();
    }


    public void RestartToMainMenu()
    {
        gameManagerSound.PlayOneShot(buttonSound, 0.5f);

        //Scene 0 is Main Menu Scene
        SceneManager.LoadScene(0);
    }

    private void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
