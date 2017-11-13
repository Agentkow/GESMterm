using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {

	public void PlayerRespawn()
    {
        if (Checkpoint.currentCheck !=null)
        {
            gameObject.transform.position = Checkpoint.currentCheck.transform.position;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
