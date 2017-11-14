using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour {

    public void BackButtonClicked()
    {
        //load next scene
        SceneManager.LoadScene("Title_scene");
    }
}
