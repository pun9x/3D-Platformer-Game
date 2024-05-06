using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level01DeadZone : MonoBehaviour
{
    private AudioSource deadZoneAudio;
    public GameObject player;

    void Start()
    {
        deadZoneAudio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter(Collider other)
    {
        LifeManager.livesAmount -= 1;
        //Stop Level Music
        StartCoroutine(WaitTime(20));
        player.transform.position = new Vector3(9.4f, 0.26f, 4.77f);
    }

    IEnumerator WaitTime(float second)
    {
        yield return new WaitForSeconds(second);
    }
}
