using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    public Dialog dialog;
    public float triggerDialogDistance = 4f;
    private bool dialogTriggered;
    public AudioClip talkingSound;
    public override void Move()
    {
        throw new System.NotImplementedException();
    }
    public void Speak() 
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = talkingSound;
        FindObjectOfType<DialogManager>().StartDialog(this.dialog);
        audio.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (((Player.Instance.transform.position - this.transform.position).magnitude < triggerDialogDistance) && !dialogTriggered)
        {
            //Debug.Log(dialogTriggered);
            dialogTriggered = true;
            Speak();
        }
    }
}
