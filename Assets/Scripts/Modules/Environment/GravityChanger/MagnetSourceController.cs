using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetSourceController : Observer
{
    [Header("button id")]
    [SerializeField]
    private int switchId;
    [Header("pull direction")]
    [SerializeField]
    private MagnetDirection direction;
    [Header("pull strength")]
    [SerializeField]
    private float forceIntensity;
    [Header("inital open")]
    [SerializeField]
    private bool initialOpen;
    [Header("change color list")]
    [SerializeField]
    List<Sprite> spriteList;
    [SerializeField]
    List<Sprite> spriteOffList;
    [SerializeField]
    List<Sprite> fieldColorList;


    private Transform magnetArea;
    private void Awake()
    {
        magnetArea = transform.Find("magnet_area");
        magnetArea.gameObject.SetActive(initialOpen);
        if (switchId >= 0)
        {
            if (initialOpen)
            {
                GetComponent<SpriteRenderer>().sprite = spriteList[switchId];
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = spriteOffList[switchId];
            }
            magnetArea.GetComponent<SpriteRenderer>().sprite = fieldColorList[switchId];
        }

        //AddEventListener(EventName.ButtonOn, args =>
        //{
        //    if (switchId == (int)args[0])
        //    {
        //        if (switchId >= 0)
        //        {
        //            GetComponent<SpriteRenderer>().sprite = spriteList[switchId];
        //        }
        //        magnetArea.gameObject.SetActive(!initialOpen);
        //    }
        //});
        //AddEventListener(EventName.ButtonOff, args =>
        //{
        //    if (switchId == (int)args[0])
        //    {
        //        if (switchId >= 0)
        //        {
        //            GetComponent<SpriteRenderer>().sprite = spriteOffList[switchId];
        //        }
        //        magnetArea.gameObject.SetActive(initialOpen);
        //    }
        //});
        magnetArea.GetComponent<MagnetArea>().SetStatus(forceIntensity, direction);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
