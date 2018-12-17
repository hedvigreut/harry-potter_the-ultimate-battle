using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Windows.Speech;

public class CreateObgfjects : MonoBehaviour
{

    public GameObject Soulsucker;
    public GameObject Monster;
    public GameObject Door;

    public Text countText;
    public float points;

    public float waitTime = 2f;

    List<GameObject> objectNameList = new List<GameObject>();
    private GameObject playingObject;

    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;


    // Use this for initialization
    void Start()
    {
        objectNameList.Add(Soulsucker);
        objectNameList.Add(Monster);
        objectNameList.Add(Door);
        createObject();

        float points = 0.0f;
        updatePoints();

        keywordActions.Add("Soul sucker", DestroyObject);
        keywordActions.Add("Avaada Kedavra", DestroyObject);
        keywordActions.Add("Kill", DestroyObject);
        keywordActions.Add("Monster", DestroyObject);
        keywordActions.Add("Door", DestroyObject);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();
    }


    // Update is called once per frame
    void Update()
    {

        if (playingObject.tag == "Soul" && Input.GetKeyDown("n"))
        {
            DestroyObject();
            points += 1;
            updatePoints();
            Invoke("createObject", waitTime);
        }
        else if (playingObject.tag == "Monster" && Input.GetKeyDown("m"))
        {
            DestroyObject();
            points += 1;
            updatePoints();
            Invoke("createObject", waitTime);
        }
        else if (playingObject.tag == "Door" && Input.GetKeyDown("b"))
        {
            DestroyObject();
            points += 1;
            updatePoints();
            Invoke("createObject", waitTime);
        }

        Debug.Log("Points: " + points);
        if (points == 4f)
        {
            waitTime -= 1.5f;
            points = 0.0f;
        }
    }

    void updatePoints()
    {
        countText.text = "Count: " + points.ToString();
    }

    private void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke();
    }

    void createObject()
    {
        UnityEngine.Random rnd = new UnityEngine.Random();
        int arrayNumber = UnityEngine.Random.Range(0, 3);

        playingObject = objectNameList[arrayNumber];

        if (playingObject.tag == "Soul")
        {
            Debug.Log("SOUL");
            playingObject.transform.localScale = new Vector3(2f, 2f, 2f);
            playingObject.transform.position = new Vector3(0, 0, 0);

        }
        else if (playingObject.tag == "Monster")
        {
            Debug.Log("MONSTER");
            playingObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            playingObject.transform.position = new Vector3(0, 0, 0);

        }
        else if (playingObject.tag == "Door")
        {
            Debug.Log("DOOR");
            playingObject.transform.localScale = new Vector3(1f, 1f, 1f);
            playingObject.transform.position = new Vector3(0, 2, 0);
        }

        Instantiate(playingObject);
    }

    void DestroyObject()
    {

        if (gameObject.tag == "Monster")
        {
            Destroy(GameObject.Find("Voldemort(Clone)"));
        }
        else if (gameObject.tag == "Soul")
        {
            Destroy(GameObject.Find("Dementor(Clone)"));
        }
        else
        {
            Destroy(GameObject.Find("Door(Clone)"));
        }
    }
}