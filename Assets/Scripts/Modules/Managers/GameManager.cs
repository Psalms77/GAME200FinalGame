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
    public Camera cam;
    public Vector3 mousePos3;
    public Vector2 mousePos2;
    public bool isPulling = false;
    protected override void Awake()
    {
        base.Awake();
      
        DontDestroyOnLoad(gameObject);
        AddEventListener(EventName.BlackHolePull, args =>
        {
            //isPulling = !isPulling;

        });
        Application.targetFrameRate = 60;

    }

    void Start()
    {
        stateMachine = new GameManagerFSM(this);
        cam = Camera.main;
        // LevelManager.instance.BackToMainMenu();
        // UIManager.instance.CreateUI<GeneralFadePage>();
    }

    // private float _pressXTime = 0f;
    void Update()
    {
        UIManager.instance.Update();
        stateMachine.currentState.HandleUpdate();
        mousePos3 = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos2 = new Vector2(mousePos3.x, mousePos3.y);
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