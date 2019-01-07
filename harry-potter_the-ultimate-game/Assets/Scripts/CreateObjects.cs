using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Windows.Speech;

public class CreateObjects : MonoBehaviour
{

    public GameObject Soulsucker;
    public GameObject Monster;
    public GameObject Door;
    public GameObject WinCanvas;
    public GameObject prefab;

    public Text countText;
    public float levelPoints;
    public int points;

    public float waitTime = 2f;
    public float speed;
    public Transform target;


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

        points = 0;
        float levelPoints = 0.0f;
        updatePoints();

        keywordActions.Add("Go away", DestroyByVoiceS);
        keywordActions.Add("Destroy", DestroyByVoiceM);
        //keywordActions.Add("Kill", DestroyByVoiceD);
        //keywordActions.Add("Monster", DestroyByVoiceS);
        keywordActions.Add("Open", DestroyByVoiceD);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();
    }

    void DestroyByVoiceS()
    {
        DestroyByVoice("Soul");
    }
    void DestroyByVoiceD()
    {
        DestroyByVoice("Door");
    }
    void DestroyByVoiceM()
    {
        DestroyByVoice("Monster");
    }

    void DestroyByVoice(String tag)
    {
        if (playingObject.tag == "Soul" && tag == "Soul")
        {
            DestroyObject();
            points += 1;
            levelPoints += 1;
            updatePoints();
            Invoke("createObject", waitTime);
        }
        else if (playingObject.tag == "Monster" && tag == "Monster")
        {
            DestroyObject();
            points += 1;
            levelPoints += 1;
            updatePoints();
            Invoke("createObject", waitTime);
        }
        else if (playingObject.tag == "Door" && tag == "Door")
        {
            DestroyObject();
            points += 1;
            levelPoints += 1;
            updatePoints();
            Invoke("createObject", waitTime);
        }
    }

    void MoveEnemies()
    {
        
        Debug.Log("Moving!");
        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;
        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }


    // Update is called once per frame
    void Update()
    {
        if (levelPoints == 4f)
        {
            waitTime -= 1.5f;
            levelPoints = 0.0f;
        }
        if (points == 6f)
        {
            Debug.Log("Vi vann!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            // Debug.Log("Vi hittar: " + GameObject.Find("WinCanvas"));
            //GameObject currentWin = GameObject.FindGameObjectWithTag("Win");
            WinCanvas.SetActive(true);
            //currentWin.SetActive(true);
            //Debug.Log("CANVAS!");
            //Application.Quit();
        }
    }

    void updatePoints()
    {
        //countText.text = "Count: " + points.ToString();
        countText.text = "Points: " + points.ToString();
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
            //playingObject.transform.localScale = new Vector3(2f, 2f, 2f);
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
        if (playingObject.tag == "Monster")
        {
            Debug.Log("Monsterrrrr");
            Destroy(GameObject.Find("voldemorta(Clone)"));
        }
        else if (playingObject.tag == "Soul")
        {
            Debug.Log("soullllll");
            Destroy(GameObject.Find("Dementor(Clone)"));
        }
        else if (playingObject.tag == "Door")
        {
            Debug.Log("dooooooor");
            Destroy(GameObject.Find("Door(Clone)"));
        }
        else
        {
            Debug.Log("Ingen tag");
        }
    }
}