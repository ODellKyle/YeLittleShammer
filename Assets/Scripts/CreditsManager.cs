using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    public void MainMenuPressed() 
    {
        Destroy(GameObject.Find("player"));
        SceneManager.LoadScene("MainMenu");
    }
}
