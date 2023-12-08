using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotionCount : Observer
{


    public int potionCount = 0;
    public TMP_Text potionNumText;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        AddEventListener(EventName.PotionCollected, args =>
        {
            potionCount++;
        });
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        potionNumText.SetText(potionCount.ToString());
    }
}
