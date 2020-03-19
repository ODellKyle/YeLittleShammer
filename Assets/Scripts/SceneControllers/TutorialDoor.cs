using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialDoor : MonoBehaviour
{
    private Vector3 entance = new Vector3(3.5f, -1.89f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.Equals(Player.Instance.plyrBoxCollider))
        {
            if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("TutorialScene")))
            {
                SceneManager.LoadScene("FirstLevel");
                Player.Instance.transform.position = new Vector3(-3.5f, -3.14f, 0);
            }
            else
            {
                //Player.Instance.prevLocation = new Vector3(43.48f, 5.06f, 0);
                SceneManager.LoadScene("TutorialScene");
                Player.Instance.transform.position = entance;
            }


        }
    }
}
