using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour {

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Respawn playerRespawn = collision.gameObject.GetComponent<Respawn>();
            audioSource.Play();
            playerRespawn.PlayerRespawn();
        }
        

        
    }
}
