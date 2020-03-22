using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string goingTo;
    public int goingToIndex;

    public class Coordinates 
    {
        public static Vector3 tutorial1 = new Vector3(3.315f, -2.86f, 0f);
        public static Vector3 firstLevel1 = new Vector3(-3.19f, -3.74f, 0f);
        public static Vector3 house1 = new Vector3(0f, -1.52f, 0f);
        public static Vector3 firstLevel2 = new Vector3(43.48f, 4.6f, 0f);
        public static Vector3 preFinalLevel1 = new Vector3(-6.8f, -2.2f, 0f);
        public static Vector3 firstLevel3 = new Vector3(0f, 0f, 0f);

        public static List<Vector3> cooridnates = new List<Vector3>(){ tutorial1, firstLevel1, house1, firstLevel2, preFinalLevel1, firstLevel3 };
    }

    public void Open(Collider2D collision, string goingTo, Vector3 goingToVec) 
    {
        
        if (collision.Equals(Player.Instance.collider))
        {
            SceneManager.LoadScene(goingTo);
            Player.Instance.transform.position = goingToVec;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Open(collision, goingTo, Coordinates.cooridnates[goingToIndex]);
    }
}
