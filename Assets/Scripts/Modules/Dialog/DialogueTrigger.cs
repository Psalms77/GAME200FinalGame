using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogSystem>().StartDialogue(dialogue);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TriggerDialogue();
            }
        }
    }
}
