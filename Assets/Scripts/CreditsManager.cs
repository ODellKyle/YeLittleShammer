﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    public void MainMenuPressed() 
    {
        Player.Instance.inventory[0] = false;
        Player.Instance.inventory[1] = false;
        Destroy(GameObject.Find("player"));
        SceneManager.LoadScene("MainMenu");
    }
}
