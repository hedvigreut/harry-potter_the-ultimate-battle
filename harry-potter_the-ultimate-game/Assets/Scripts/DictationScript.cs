using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class DictationScript : MonoBehaviour
{
    // [SerializeField]
    //private Rigidbody cubee;

    // [SerializeField]
    //private Transform transformCube;

    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;

    void Start()
    {
        //keywordActions.Add("Open", Up);
        //keywordActions.Add("Avaada Kedavra", Down);
        //keywordActions.Add("Kill", Left);
        keywordActions.Add("Right", Right);
        //keywordActions.Add("Down", Heleo);

        keywordActions.Add("Soul sucker", Up);
        keywordActions.Add("Avaada Kedavra", Down);
        keywordActions.Add("Kill", Left);
        //keywordActions.Add("Monster", Right);
        keywordActions.Add("Door", Heleo);


        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();

    }

    private void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke();
    }

    private void Left()
    {
        this.transform.Translate(1, 0, 0);
    }

    private void Right()
    {
        this.transform.Translate(-1, 0, 0);
    }
    private void Down()
    {
        this.transform.Translate(0, -1, 0);
    }

    private void Up()
    {
        this.transform.Translate(0, 1, 0);
    }
    private void Heleo()
    {
        this.transform.Rotate(0, 10, 0);
    }
}