using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void CreditsClicked() 
    {
        SceneManager.LoadScene("Credits");
    }

    public void SettingsClicked() 
    {
        SceneManager.LoadScene("SettingsScene");
    }
}
