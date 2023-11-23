using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum MagnetDirection
{
    Up,
    Down,
    Left,
    Right,
}


public class MagnetArea : MonoBehaviour
{
    private Vector2 forceDirection;
    private MagnetDirection direction;
    private float force;

    private void OnTriggerEnter2D(Collider2D col)
    {
        //EventManager.SendNotification(EventName.EnterMagnetArea, col.gameObject, gameObject, forceDirection);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //EventManager.SendNotification(EventName.ExitMagnetArea, col.gameObject, gameObject);
    }

    public void SetStatus(float value, MagnetDirection dir)
    {
        force = value;
        direction = dir;
        if (direction == MagnetDirection.Down)
        {
            forceDirection = Vector2.down;
        }
        if (direction == MagnetDirection.Up)
        {
            forceDirection = Vector2.up;
        }
        if (direction == MagnetDirection.Left)
        {
            forceDirection = Vector2.left;
        }
        if (direction == MagnetDirection.Right)
        {
            forceDirection = Vector2.right;
        }
        forceDirection *= force;
    }
    
}
