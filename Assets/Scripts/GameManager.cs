using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static List<GameObject> SelectedWordBoxes;

    private void Awake()
    {
        SelectedWordBoxes = new List<GameObject>();
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //Box[] AllBoxes = GameObject.FindObjectsOfType<Box>();
        //Debug.Log(AllBoxes.Length);
        //foreach(Box box in AllBoxes)
        //{
        //    box.ApplyStyle("AB");
        //}
        //Debug.Log("SelectedWordBoxs : "+ SelectedWordBoxes.Count);
        //foreach(GameObject gb in SelectedWordBoxes)
        //{
        //    Debug.Log(gb.transform.position.x);
        //    Text text = gb.GetComponentInChildren<Text>();
        //    Debug.Log(text.text);
        //}
	}
}
