using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneJump : Observer
{
    public string sceneName;
    //public int index;



    private void Awake()
    {
        AddEventListener(EventName.DialogBoxClose, args =>
        {
            Jump();
        });
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Jump()
    {
        SceneManager.LoadScene(sceneName);
    }

}
