using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour {

    private Text TitleText;
    private Image ImageText;

    public string getWord()
    {
        return TitleText.text;
    }

    private void Awake()
    {
        TitleText = GetComponentInChildren<Text>();
        ImageText = transform.Find("BoxCell").GetComponent<Image>();
    }

    void ApplyStyleFromHolder(int index, string word)
    {
        TitleText.text = word;
        ImageText = WordStyleHolder.Instance.WordStyles[index].BoxImage;
    }



    public void ApplyStyle(string word)
    {
        if (word != "")
        {
            ApplyStyleFromHolder(1,word);
        }
        else
        {
            ApplyStyleFromHolder(0,word);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
