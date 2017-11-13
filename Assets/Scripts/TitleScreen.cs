using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	public void StartGameButtonClicked()
    {
        //load next scene
        SceneManager.LoadScene("Level_1");
    }
    public void CreditsButtonClicked()
    {
        //load credit scene
        SceneManager.LoadScene("Credits");
    }

    public void QuitButtonClicked()
    {
        //close game
        Application.Quit();
    }

}
