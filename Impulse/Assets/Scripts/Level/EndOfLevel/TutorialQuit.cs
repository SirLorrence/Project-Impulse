﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialQuit : MonoBehaviour
{
    public float timeToQuit = 3f;
    private float currentTime;

    private void OnTriggerEnter(Collider other)
    {
        currentTime = Time.realtimeSinceStartup + timeToQuit;
    }

    private void OnTriggerStay(Collider other)
    {
        if (currentTime < Time.realtimeSinceStartup)
        {
            Application.Quit();
        }
    }


}
