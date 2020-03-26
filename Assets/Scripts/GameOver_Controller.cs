using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver_Controller : MonoBehaviour
{
    public Button continueButton;
    public Button mainMenuButton;
    public Button quitButton;
    public Text noPlayer;
    // Start is called before the first frame update


    public void PlayPressed() 
    {
        SceneManager.LoadScene("TutorialScene");
        if(Player.Instance != null) 
        {
            Door door = new Door();
            Player.Instance.transform.position = new Vector3(-4f, -2.83f, 0f);
        }
    }

    public void ContinuePressed() 
    {
        if (Player.Instance != null)
        {
            Door door = new Door();
            SceneManager.LoadScene(door.scenes[Player.Instance.currentLevel]);
            Player.Instance.enabled = true;
            Player.Instance.transform.position = Door.Coordinates.cooridnates[Player.Instance.currentLevel];
        }
        else
            noPlayer.text = "You haven't started a game yet.";
    }

    public void MainMenuPressed() 
    {
        SceneManager.LoadScene("MainMenu");
        Player.Instance.enabled = false;
        Player.Instance.transform.position = new Vector3(6f, -3.86f, 0f);
    }

    public void QuitPressed()
    {
        Debug.Log("Quit called");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif

    }

}
