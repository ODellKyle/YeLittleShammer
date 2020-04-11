using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogText;
    public GameObject HUD;
    public GameObject DialogBox;

    private Queue<string> sentances;
    // Start is called before the first frame update
    void Start()
    {
        DialogBox.SetActive(false);
        sentances = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            DisplayNextSentance();
        }
        
    }

    public void StartDialog(Dialog dialog) 
    {
        HUD.SetActive(false);
        DialogBox.SetActive(true);

        Player.Instance.Inactive(false);
        nameText.text = dialog.name;

        this.sentances.Clear();

        foreach (string sentance in dialog.sentances) 
        {
            this.sentances.Enqueue(sentance);
        }

        DisplayNextSentance();
    }

    public void DisplayNextSentance() 
    {
        if(sentances.Count == 0) 
        {
            EndDialogue();
            return;
        }

        string sentance = sentances.Dequeue();
        dialogText.text = sentance;
        //Debug.Log(sentance);
    }

    //IEnumerator 

    public void EndDialogue() 
    {
        Player.Instance.Inactive(true);
        //Debug.Log("End conversation");
        HUD.SetActive(true);
        DialogBox.SetActive(false);
    }
}
