using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour {

    private Text TitleText;
    private Image ImageText;
    private Animator anim;

    public string getWord()
    {
        return TitleText.text;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        TitleText = GetComponentInChildren<Text>();
        ImageText = gameObject.AddComponent<Image>();
        //ImageText.color = WordStyleHolder.Instance.WordStyles[0].Color;
    }

    public void clickSelectedAnimation()
    {
        anim.SetTrigger("Selected");

    }

    public void correctedLineAnimation()
    {
        anim.SetTrigger("Corrected");
    }
    public void wrongShakingAnimation()
    {
        anim.SetTrigger("WrongSwipe");

    }

    void ApplyStyleFromHolder(int index, string word)
    {
        TitleText.text = word;
        ImageText.sprite = WordStyleHolder.Instance.WordStyles[index].BoxImage;
        ImageText.color = WordStyleHolder.Instance.WordStyles[index].Color;
    }



    public void ApplyStyle(string word)
    {
        if (word != "")
        {
            ApplyStyleFromHolder(1, word);
        }
        else
        {
            ApplyStyleFromHolder(0, word);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
}
