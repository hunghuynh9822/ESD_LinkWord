using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject boxPreference;
    public Transform panel;

    public static int WordBoxCount = 0;

    // Use this for initialization
    void Start () {
        //CreateEmptyBox();
        string[] words = { "","B","C"};
        WordBoxCount = words.Length;
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

    void CreateWordBox(string word, Vector2 position)
    {
        GameObject a = Instantiate(boxPreference, position, Quaternion.identity) as GameObject;
        Box box = a.GetComponent<Box>();
        box.ApplyStyle(word);
        a.transform.SetParent(panel.transform, false);
    }
}
