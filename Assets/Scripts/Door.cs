using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int goingToIndex;
    bool collided = false;
    Collider2D collider;
    public List<string> scenes = new List<string>() 
    { 
        "TutorialScene", "shipscene", "FirstLevel", "House", "FirstLevel",  
        "FinalLevel", "Credits", "CheckPoint", "FinalLevel", "ExtraLevel", 
        "FinalLevel" 
    };
    public class Coordinates 
    {
        public static Vector3 tutorial1 = new Vector3(3.315f, -2.86f, 0f);
        public static Vector3 shipDeck = new Vector3(-7f, -1.2f, 0f);
        public static Vector3 firstLevel1 = new Vector3(-7.69f, -2.81f, 0f);
        public static Vector3 house1 = new Vector3(0f, -1.52f, 0f);
        public static Vector3 firstLevel2 = new Vector3(21.2f, .64f, 0f);
        public static Vector3 finalLevel1 = new Vector3(-18.29f, 35.81f, 0f);
        public static Vector3 credits = new Vector3(0f, 0f, 0f);
        public static Vector3 checkpoint = new Vector3(6.41f, -2.9f, 0f);
        public static Vector3 checkpointreturn1 = new Vector3(104.9f, 5.6f, 0f);
        public static Vector3 intermLevel = new Vector3(0f, 0f, 0f);
        public static Vector3 checkpointreturn2 = new Vector3(-3.08f, 47.69f, 0f);

        public static List<Vector3> cooridnates = new List<Vector3>()
        { 
            tutorial1, shipDeck, firstLevel1, house1, firstLevel2, 
            finalLevel1, credits, checkpoint, checkpointreturn1, intermLevel, 
            checkpointreturn2
        };
    }

    private void OnRenderObject()
    {
        if (collided) 
        {
            Open(collider, scenes[goingToIndex], Coordinates.cooridnates[goingToIndex]);
            collided = false;
        }
    }

    public void Open(Collider2D collision, string goingTo, Vector3 goingToVec) 
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            SceneManager.LoadScene(goingTo);
            Player.Instance.transform.position = goingToVec;
            Player.Instance.currentLevel = goingToIndex;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collided = true;
        collider = collision;
    }
}
