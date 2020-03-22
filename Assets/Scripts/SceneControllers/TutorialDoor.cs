using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialDoor : Door
{
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        entrance = collider.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        isTouching = Player.Instance.mvmt.onGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Open(collision, "TutorialScene", "FirstLevel");
    }

    IEnumerator Enter ()
    {
        for (float i = 1f; i <= 0f; i -= .1f)
        {

            yield return new WaitForSeconds(.1f);
        }
    }
}
