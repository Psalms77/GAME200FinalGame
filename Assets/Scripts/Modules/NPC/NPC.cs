using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private GameObject ehint;
    public GameObject dialogBox;
    private Collider2D[] colliders;
    private bool inrange = false;
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
        colliders = Physics2D.OverlapCircleAll(transform.position, 3.6f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].transform.CompareTag("Player"))
            {
                inrange = true;
            }
        }
        if (inrange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TriggerDialogue();
            }
        }

    }

    public void TriggerDialogue()
    {
        dialogBox.SetActive(true);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ehint.SetActive(true);
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
