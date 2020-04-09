using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShipScene : MonoBehaviour
{
    public float timeUntilLanding = 30f;
    public float timer;
    //public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //timerText.text = (30 - Time.time).ToString();
        if ((Time.time - timer > timeUntilLanding) && Player.Instance.enabled) 
        {
            SceneManager.LoadScene("FirstLevel");
            Player.Instance.transform.position = Door.Coordinates.cooridnates[2];
            Player.Instance.currentLevel = 2;
        }
    }
}
