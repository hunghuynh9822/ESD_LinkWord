using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static List<GameObject> SelectedWordBoxes;
    public static List<LineEmptyBoxAnswer> lineEmptyBoxAnswers;
    public static Answer[] answers;
    public static string answerPlayer;
    int i = 0;

    public static GameManager Instance;

    private void Awake()
    {
        SelectedWordBoxes = new List<GameObject>();
        lineEmptyBoxAnswers = new List<LineEmptyBoxAnswer>();
        
        Instance = this;
        answerPlayer = "";
    }

    // Use this for initialization
    void Start () {
        answers = GetTxt.Instance.getAnswer();
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
        answerPlayer = "";
        if (SelectedWordBoxes != null)
        {
            foreach (GameObject gb in SelectedWordBoxes)
            {
                //Debug.Log(gb.transform.position.x);
                answerPlayer += gb.GetComponentInChildren<Text>().text;
                //Debug.Log(text.text);
            }
            //if (answerPlayer.Length == 3)
            //{
            //    Debug.Log("Chuoi da chon " + i + ": " + answerPlayer);
            //    i++;
            //}
        }
        
    }

    public bool checkAnswer()
    {
        for(int i = 0; i < answers.Length; i++)
        {
            if (answerPlayer.Equals(answers[i].getAnswer()))
            {
                if (!lineEmptyBoxAnswers[i].getChecked())
                {
                    List<GameObject> gameObjects = lineEmptyBoxAnswers[i].getGameObjects();
                    for (int j = 0; j< gameObjects.Count;j++ )
                    {
                        Box box = gameObjects[j].GetComponent<Box>();
                        box.ApplyStyle(answers[i].getChars()[j]);
                    }
                    lineEmptyBoxAnswers[i].setChecked(true);
                    answerPlayer = "";
                    Debug.Log("Correct");
                    return true;
                }
                Debug.Log("Checked");
                return false;
            }
            Debug.Log("Failed");
        }
        return false;
    }
}
