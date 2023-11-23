using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetReceptor : Observer
{
    private List<KeyValuePair<GameObject, Vector2>> magnetList = new List<KeyValuePair<GameObject, Vector2>>();
    private Rigidbody2D rig;
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        //AddEventListener(EventName.EnterMagnetArea, (object[] args) =>
        //{
        //    if ((GameObject)args[0] == gameObject)
        //    {
        //        // todo 加入
        //        magnetList.Add(new KeyValuePair<GameObject, Vector2>((GameObject)args[1], (Vector2)args[2]));
                
        //    }
        //});
        //AddEventListener(EventName.ExitMagnetArea, (object[] args) =>
        //{
        //    if ((GameObject)args[0] == gameObject)
        //    {
        //        // todo 删除
        //        magnetList.RemoveAll(item => item.Key == (GameObject)args[1]);
        //    }
        //});
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void FixedUpdate()
    {
        foreach (var item in magnetList)
        {
            rig.AddForce(item.Value);
        }
    }
}
