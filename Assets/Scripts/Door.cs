using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Door : MonoBehaviour
{
    public Collider2D collider;
    public Vector3 entrance;
    public bool isTouching;
    //public Vector3 exit;

    public void Open(Collider2D collision, string goingTo, string comingFrom) 
    {
        
        if (collision.Equals(Player.Instance.collider))
        {

            if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName(comingFrom)))
            {
                // Player.Instance.prevLocation = entrance;
                SceneManager.LoadScene(goingTo);
                Player.Instance.transform.position = entrance;
                //Player.Instance.nextLocation = Player.Instance.prevLocation;
            }
            else
            {
                //Player.Instance.prevLocation = entrance;
                SceneManager.LoadScene(comingFrom);
                Player.Instance.transform.position = entrance;
            }


        }
    }
}
