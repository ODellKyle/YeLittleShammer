using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject howToPlayPanel;

    // Update is called once per frame
    public void SettingsPressed() 
    {
        settingsPanel.SetActive(true);
    }

    public void ToMainMenuPressed() 
    {
        settingsPanel.SetActive(false);
    }

    public void HowToPlayPressed() 
    {
        howToPlayPanel.SetActive(true);
    }
}
