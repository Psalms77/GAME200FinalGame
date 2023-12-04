using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private GameObject ehint;
    public Dialogue dialogue;

    private void Awake()
    {
        ehint = this.transform.GetChild(0).gameObject;
        ehint.SetActive(false);
    }
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
        DialogSystem.instance.StartDialogue(dialogue);
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



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ehint.SetActive(true);
        }
        else
        {
            ehint.SetActive(false);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            ehint.SetActive(false);
        }
    }
}
