using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckClicks : MonoBehaviour {

    // Normal raycasts do not work on UI elements, they require a special kind
    GraphicRaycaster raycaster;
    [SerializeField]
    DrawLine drawLine;

    void Awake()
    {
        // Get both of the components we need to do this
        this.raycaster = GetComponent<GraphicRaycaster>();
    }

    void Update()
    {
        selectWorldBox();
    }

    void selectWorldBox()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
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
                    //Check if it is wordBox
                    if (result.gameObject.tag == "wordBox")
                    {
                        Box box = result.gameObject.GetComponent<Box>();
                        //If it not contain in SelectedBox in GameManager
                        if (!GameManager.Instance.SelectedWordBoxes.Contains(result.gameObject))
                        {
                            GameManager.Instance.SelectedWordBoxes.Add(result.gameObject);
                            //Connect with previous box
                            drawLine.setPositonLine(result.gameObject.transform.position);
                        }
                    }

                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                GameManager.Instance.checkAnswer();
                /* Remove Line - Reset SelectedBoxes*/
                GameManager.Instance.SelectedWordBoxes.Clear();
                drawLine.resetLine();
            }
        }
    }
}
