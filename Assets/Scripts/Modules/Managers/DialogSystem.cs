using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem : Singleton<DialogSystem>
{
    public Queue<string> sentences;

    public TMP_Text dialogText;
    public TMP_Text nameText;
    public Image icon;

    public bool isInDialog = false;
    private bool isTyping = false;


    protected override void Awake()
    {
        base.Awake();

    }




    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && isInDialog && !isTyping)
        {
            DisplayNextSentence();
        }
    }


    public void StartDialogue(Dialogue dialog)
    {
        Debug.Log("Starting conversation with " + dialog.name);
        sentences.Clear();
        isInDialog = true;
        nameText.SetText(dialog.name);
        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

    }


    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        Debug.Log("DisplayNextSentence");
        isTyping = true;
        StartCoroutine(TypeSentence());
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        dialogText.SetText(sentence);
    }

    IEnumerator TypeSentence()
    {
        isTyping = true;
        yield return new WaitForSeconds(1f);
        isTyping = false;
    }

    public void EndDialog()
    {
        Debug.Log("End of conversation");
        isInDialog = false;
    }
}
