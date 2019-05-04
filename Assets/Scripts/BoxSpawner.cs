using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject emptyBoxPreference;
    [SerializeField]
    private GameObject wordBoxPreference;
    public Transform panel;

    // Use this for initialization
    void Start () {
        //CreateEmptyBox();
        string[] words = { "A","B","C"};
        MapPosition mapPosition = MapPosition.getMapPosition(words.Length);
        if(mapPosition != null)
        {
            for (int i = 0; i < words.Length; i++)
            {
                CreateWordBox(words[i], mapPosition.positions[i]);
            }
        }
        
        
    }

    // Update is called once per frame
    void Update () {
    }

    void CreateEmptyBox()
    {
        GameObject a = Instantiate(emptyBoxPreference, new Vector3(-4, 133, 0), Quaternion.identity) as GameObject;
        a.transform.SetParent(panel.transform, false);
    }

    void CreateWordBox(string word, Vector2 position)
    {
        GameObject a = Instantiate(wordBoxPreference, position, Quaternion.identity) as GameObject;
        Box box = a.GetComponent<Box>();
        box.ApplyStyle(word);
        a.transform.SetParent(panel.transform, false);
    }
}
