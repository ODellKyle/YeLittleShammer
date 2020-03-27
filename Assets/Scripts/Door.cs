using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int goingToIndex;
    bool collided = false;
    Collider2D collider;
    public List<string> scenes = new List<string>() { "TutorialScene", "FirstLevel", "House", "FirstLevel", "PreFinalLevel", "FinalLevel", "FirstLevel" };
    public class Coordinates 
    {
        public static Vector3 tutorial1 = new Vector3(3.315f, -2.86f, 0f);
        public static Vector3 firstLevel1 = new Vector3(-4f, -3.65f, 0f);
        public static Vector3 house1 = new Vector3(0f, -1.52f, 0f);
        public static Vector3 firstLevel2 = new Vector3(23.03f, 5.2f, 0f);
        public static Vector3 preFinalLevel1 = new Vector3(-6.8f, -2.2f, 0f);
        public static Vector3 finalLevel1 = new Vector3(5.46f, -1.78f, 0f);
        public static Vector3 firstLevel3 = new Vector3(0f, 0f, 0f);

        public static List<Vector3> cooridnates = new List<Vector3>(){ tutorial1, firstLevel1, house1, firstLevel2, preFinalLevel1, finalLevel1, firstLevel3 };
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
        if (collision.Equals(Player.Instance.collider))
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
