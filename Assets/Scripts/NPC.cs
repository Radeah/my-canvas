using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    //public GameObject dialoguePanel;
    public bool PlayerIsClose;
    public GameObject prompt;
    public Dialogue dialogue;
    DialogueManager dm;
    bool hasPlayed = false;
    bool EndPrompt =true;


    public void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {

        if (PlayerIsClose && hasPlayed == false)
        {
            prompt.SetActive(true);
            
        }
        else
        {
            prompt.SetActive(false);

        }

        

        if (Input.GetKeyDown(KeyCode.E) && PlayerIsClose && hasPlayed == false)
        {
            hasPlayed = true;
       
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

    public void TriggerDialogue()
    {
        dm.StartDialogue(dialogue);
    }

}



