using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public bool isInGame { get; private set; }
    private GameManagerFSM stateMachine;
    protected override void Awake()
    {
        base.Awake();
      
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        DontDestroyOnLoad(GameObject.Find("UICamera"));
        Application.targetFrameRate = 60;
        SaveManager.instance.Init();
        AudioManager.instance.Init();
    }

    void Start()
    {
        stateMachine = new GameManagerFSM(this);
        // LevelManager.instance.BackToMainMenu();
        // UIManager.instance.CreateUI<GeneralFadePage>();
    }

    // private float _pressXTime = 0f;
    void Update()
    {
        UIManager.instance.Update();
        stateMachine.currentState.HandleUpdate();
        
        // GM only in editor
#if UNITY_EDITOR
        //if (Input.GetKeyUp(KeyCode.G))
        //{
        //    if (UIManager.instance.GetFirstUIWithType<GMPage>() != null)
        //    {
        //        UIManager.instance.DestroyAllUIWithType<GMPage>();
        //    }
        //    else
        //    {
        //        UIManager.instance.CreateUI<GMPage>();
        //    }
        //}
#endif
    }
    

    // returns player game object
    public GameObject GetPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }

    public void SetIsInGame(bool status)
    {
        isInGame = status;
    }
}