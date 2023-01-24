using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public bool PlayerIsClose;
    public GameObject prompt;
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void Update()
    {

        if (PlayerIsClose)
        {
            prompt.SetActive(true);
        }
        else
        {
            prompt.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.E) && PlayerIsClose)
        {
            dialoguePanel.SetActive(true);
            TriggerDialogue();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerIsClose = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerIsClose = false;
        }

    }

 }



