using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogSystem : MonoBehaviour
{
    //UI display
    public TMP_Text textLabel;
    public TMP_Text nameLabel;
    public Image icon;

    //txt file
    public TextAsset textFile;
    public int index;

    //string list
    List<string> textList = new List<string>();

    //wait time
    public float textSpeed;
    public float textOriginal;
    public float textJumpSpeed = 0;

    //bool
    bool textFinished;//is text finished showing


    //icons
    public Sprite[] face;
    Dictionary<string, Sprite> Dic = new Dictionary<string, Sprite>();


    private void Awake()
    {
        Dic.Add("Penny", face[0]);
        Dic.Add("Mom", face[1]);
        icon.sprite = face[0];
        textSpeed = textOriginal;
        GetTextFromFile(textFile);
        index = 0;
        textFinished = true;

    }
    private void OnEnable()
    {

        setTextUI();

    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && index == textList.Count)//text finished
        {
            // free player here
            gameObject.SetActive(false);
            index = 0;
            return;
        }

        if (Input.GetKeyDown(KeyCode.F) && textFinished)
        {
            textSpeed = textOriginal;
            StartCoroutine(setTextUI());
        }
        else if (Input.GetKeyDown(KeyCode.F) && !textFinished)
        {
            textSpeed = textJumpSpeed;
        }
    }


    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;
        var lineData = file.text.Split('\n');
        foreach (var line in lineData) 
        {
            textList.Add(line);
        }
    }

    IEnumerator setTextUI()
    {
        textFinished = false;
        textLabel.text = "";
        switch (textList[index].Trim())//Trim()        trim the extra space 
        {
            case "Penny":
                icon.sprite = Dic["Penny"];
                nameLabel.text = textList[index].ToString();
                index++;
                break;
            case "Mom":
                icon.sprite = Dic["Mom"];
                nameLabel.text = textList[index].ToString();
                index++;
                break;
        }
        for (int i = 0; i < textList[index].Length; i++) 
        {
            textLabel.text += textList[index][i];
            yield return new WaitForSeconds(textSpeed); 
        }
        index++;
        textFinished = true;
    }
}