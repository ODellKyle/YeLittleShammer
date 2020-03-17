using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public BoxCollider2D houseEntrance;
    // Start is called before the first frame update
    void Start()
    {
        houseEntrance = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Fix glitch
        if (Player.Instance.plyrBoxCollider.IsTouching(houseEntrance))
        {
            if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("House")))
            {
                Player.Instance.transform.position = new Vector3(43.48f, 5.06f, 0);
                SceneManager.LoadScene("FirstLevel");
                
                Player.Instance.jump = true;
            }
            else
            {
                SceneManager.LoadScene("House");
                Player.Instance.transform.position = new Vector3(-0.46f, 3.3f, 0);
            }
            //SceneManager.LoadScene("House");
            
        }
    }
}
