﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    Camera cam;
    int width;
    int height;

    List<IRaycastSubscriber> subscribers;

    void Start()
    {
        cam = Camera.main;

        subscribers = new List<IRaycastSubscriber>();
    }

    // Gets pointer position in 
    public void GetRaycastHit(Vector2 indicatorPos)
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(indicatorPos.x, indicatorPos.y, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //print("I'm looking at " + hit.transform.name);
            //hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
            SendPushNotification(hit, true);
        }
        else
        {
            SendPushNotification(new RaycastHit(), false);
            //print("I'm looking at nothing!");
        }
    }

    void Update()
    {
        
    }

    public void Subscribe(IRaycastSubscriber subscriber)
    {
        subscribers.Add(subscriber);
        Debug.Log(subscriber.ToString() + " has subscribed to RaycastManager");
    }

    private void SendPushNotification(RaycastHit hit, bool isHit)
    {
        foreach (IRaycastSubscriber subscriber in subscribers)
        {
            subscriber.ReceivePushNotification(hit, isHit);
        }
    }
}
