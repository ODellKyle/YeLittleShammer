using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver_Controller : MonoBehaviour
{
    public Button continueButton;

    // Start is called before the first frame update
    void Start()
    {
        if (Player.Instance == null)
            continueButton.interactable = false;
        else
            continueButton.interactable = true;
    }

    public void PlayPressed() 
    {
        //Debug.Log("Play called");
        SceneManager.LoadScene("TutorialScene");
        if(Player.Instance != null) 
        {
            Door door = gameObject.AddComponent<Door>() as Door;
            //Door door = new Door();
            Player.Instance.transform.position = new Vector3(-5.82f, -2.92f, 0f);
            Player.Instance.NewGame();
            Player.Instance.Inactive(true);
            CreditsManager.gameFinished = false;
        }
    }

    public void ContinuePressed() 
    {
        //Debug.Log("Continue called");
        //Door door = new Door();
        Door door = gameObject.AddComponent<Door>() as Door;
        SceneManager.LoadScene(door.scenes[Player.Instance.currentLevel]);
        Player.Instance.Inactive(true);
        Player.Instance.transform.position = Door.Coordinates.cooridnates[Player.Instance.currentLevel];
    }

    public void MainMenuPressed() 
    {
        //Debug.Log("MainMenu called");
        SceneManager.LoadScene("MainMenu");
        Player.Instance.Inactive(false);
        Player.Instance.transform.position = new Vector3(6f, -3.86f, 0f);
    }

    public void QuitPressed()
    {
        //Debug.Log("Quit called");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif

    }

}
