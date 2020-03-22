using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Controller : MonoBehaviour
{
    public Text hpDisplay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpDisplay.text = Player.Instance.hp.ToString();
    }
}
