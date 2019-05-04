﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckClicks : MonoBehaviour {

    // Normal raycasts do not work on UI elements, they require a special kind
    GraphicRaycaster raycaster;

    void Awake()
    {
        // Get both of the components we need to do this
        this.raycaster = GetComponent<GraphicRaycaster>();
    }

    void Update()
    {
        //Check if the left Mouse button is clicked
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Set up the new Pointer Event
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            pointerData.position = Input.mousePosition;
            this.raycaster.Raycast(pointerData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                if(result.gameObject.tag == "cell")
                {
                    Debug.Log("Hit " + result.gameObject.name);
                    if (!GameManager.SelectedWordBoxes.Contains(result.gameObject))
                    {
                        GameManager.SelectedWordBoxes.Add(result.gameObject);
                    }
                    Box box = result.gameObject.GetComponent<Box>();
                    Debug.Log(box.getWord());
                }
                
            }
        }
    }
}
