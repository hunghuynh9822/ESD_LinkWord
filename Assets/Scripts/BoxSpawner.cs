using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineEmptyBoxAnswer
{
    private int index;
    private List<GameObject> gameObjects;
    private int count;
    private bool isChecked;

    public LineEmptyBoxAnswer(int index,List<GameObject> gameObjects)
    {
        this.index = index;
        this.gameObjects = gameObjects;
        this.count = gameObjects.Count;
        this.isChecked = false;
    }

    public bool compareNumberChar(int count)
    {
        return this.count == count;
    }

    public List<GameObject> getGameObjects()
    {
        return this.gameObjects;
    }

    public bool getChecked()
    {
        return isChecked;
    }

    public void setChecked(bool state)
    {
        this.isChecked = state;
    }
}

public class BoxSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject boxPreference;

    public Transform panel;

    public static int WordBoxCount = 0;

    // Use this for initialization
    void Start () {
        //CreateEmptyBox();
        string[] words = GetTxt.Instance.getWord();
        WordBoxCount = words.Length;
        MapPosition mapPosition = MapPosition.getMapWordBoxPosition(words.Length);
        if(mapPosition != null)
        {
            for (int i = 0; i < words.Length; i++)
            {
                CreateBox(words[i], mapPosition.positions[i]);
            }
        }

        Answer[] answers = GetTxt.Instance.getAnswer();
        for(int i = 0; i < answers.Length; i++)
        {
            string[] chars = answers[i].getChars();
            //Debug.Log(chars.Length);
            MapPosition mapPositionEmptyBox = MapPosition.getMapEmptyBoxPosition(chars.Length, i);
            if(mapPositionEmptyBox != null)
            {
                List<GameObject> emptyBoxes = new List<GameObject>();
                for(int j = 0; j < chars.Length; j++)
                {
                    //Debug.Log(mapPositionEmptyBox.positions[j]);
                    emptyBoxes.Add(CreateBox("", mapPositionEmptyBox.positions[j]));
                }
                GameManager.lineEmptyBoxAnswers.Add(new LineEmptyBoxAnswer(i, emptyBoxes));
            }
        }
        
    }

    // Update is called once per frame
    void Update () {
    }

    GameObject CreateBox(string word, Vector2 position)
    {
        GameObject gameObject = Instantiate(boxPreference, position, Quaternion.identity) as GameObject;
        Box box = gameObject.GetComponent<Box>();
        box.ApplyStyle(word);
        gameObject.transform.SetParent(panel.transform, false);
        return gameObject;
    }
}
