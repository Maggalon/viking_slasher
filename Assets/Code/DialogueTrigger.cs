using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Collider2D personToSpeak;
    public Collider2D initiator;

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    bool isInitiated = false;
    void Update()
    {
        if (isInitiated == false && initiator.IsTouching(personToSpeak))
        {
            TriggerDialogue();
            isInitiated = true;
        }
    }
}
