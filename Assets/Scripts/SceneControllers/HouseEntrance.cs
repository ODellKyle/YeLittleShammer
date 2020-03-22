using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseEntrance : MonoBehaviour
{
    private Vector3 entance = new Vector3(0f, -2f, 0f);
    //private BoxCollider2D houseEntrance;
    // Start is called before the first frame update
    void Start()
    {
        //houseEntrance = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Fix glitch
        /*if (Player.Instance.plyrBoxCollider.IsTouching(houseEntrance))
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
            
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.Equals(Player.Instance.collider))
        {
            if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("House")))
            {
                Player.Instance.transform.position = Player.Instance.prevLocation;
                SceneManager.LoadScene("FirstLevel");
                Player.Instance.jump = true;
            }
            else
            {
                Player.Instance.prevLocation = new Vector3(43.48f, 5.06f, 0);
                SceneManager.LoadScene("House");
                Player.Instance.transform.position = entance;
            }


        }
    }
}
