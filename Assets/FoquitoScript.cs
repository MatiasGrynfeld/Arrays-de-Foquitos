﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoquitoScript : MonoBehaviour
{
    [SerializeField] GameObject[] colors;
    public int currentLightIndex =-1;
    public int ciclosHechos = 0;
    public bool destruidos = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateNextLight()
    {
        if(!destruidos) {
            currentLightIndex++;
            if (currentLightIndex >= colors.Length)
            {
                currentLightIndex = 0;
                ciclosHechos++;
                if (ciclosHechos == 3)
                {
                    destruidos=true;
                    DeactivateAllLights();
                    return;
                }
            }
            DeactivateAllLights();
            colors[currentLightIndex].SetActive(true);
        }
    }

    public void ActivatePreviousLight()
    {
        currentLightIndex--;
        if (currentLightIndex < 0)
        {
            currentLightIndex = colors.Length - 1;
        }
        DeactivateAllLights();
        colors[currentLightIndex].SetActive(true);
    }

    void DeactivateAllLights()
    {
        foreach (GameObject g in colors)
        {
            g.SetActive(false);
        }
    }

    public void ActivateRepeating(float t)
    {
        CancelInvoke();
        InvokeRepeating(nameof(ActivateNextLight),0,t);
    }
}
