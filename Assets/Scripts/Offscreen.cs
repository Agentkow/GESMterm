using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offscreen : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Respawn playerRespawn = collision.gameObject.GetComponent<Respawn>();
           
            playerRespawn.PlayerRespawn();
        }



    }
}
