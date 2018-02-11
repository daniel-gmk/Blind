using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circuit : MonoBehaviour
{
    public bool isEnabled = false;
    public bool isComplete = false;
    static int counter = -1;
    static int[] currentOrder = { -1, -1, -1, -1 };
    int[] key = { 3, 2, 4, 1 };
    public int value = 0;
    bool toggled = false;
    static Vector2[] untoggledLoc = new Vector2[4];
    static Vector2[] toggledLoc = new Vector2[4];
    GameObject[] circuitList;

    private AudioSource source;

    public AudioClip Clip;
    [Range(0, 1)]
    public float Volume = 2f;
    [Range(.25f, 3)]
    public float Pitch = 2f;
    public bool Loop = false;
    [Range(0f, 2f)]
    public float SpacialBlend = 2f;
    void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();
        if (source == null)
        {
            source = gameObject.AddComponent<AudioSource>();
        }
    }
    public void SetSourceProperties(AudioClip clip, float volume, float picth, bool loop, float spacialBlend)
    {
        source.clip = clip;
        source.volume = volume;
        source.pitch = picth;
        source.loop = loop;
        source.spatialBlend = spacialBlend;
    }

    public void Play()
    {
        SetSourceProperties(Clip, Volume, Pitch, Loop, SpacialBlend);
        source.Play();
    }

    // Use this for initialization
    void Start()
    {
        circuitList = GameObject.FindGameObjectsWithTag("Circuit");
        toggledLoc[0] = new Vector2(-1.25f, 3);
        toggledLoc[1] = new Vector2(-0.5f, 3);
        toggledLoc[2] = new Vector2(0.5f, 3);
        toggledLoc[3] = new Vector2(1.25f, 3);
        untoggledLoc[0] = new Vector2(-3.11f, -4.42f);
        untoggledLoc[1] = new Vector2(-1.31f, -4.42f);
        untoggledLoc[2] = new Vector2(1.25f, -4.38f);
        untoggledLoc[3] = new Vector2(3.28f, -4.34f);
        GameObject[] tempBG;
        tempBG = GameObject.FindGameObjectsWithTag("FirstRoomRedDoor");
        foreach (GameObject tempBGObj in tempBG)
        {
            SpriteRenderer tempBGObjRenderer = tempBGObj.GetComponent<SpriteRenderer>();
            tempBGObjRenderer.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (!isComplete && isEnabled)
        {
            if (!toggled)
            {
                counter++;
                transform.position = toggledLoc[counter];
                currentOrder[counter] = value;
                toggled = true;
                if (counter == 3)
                {
                    checkComplete();
                }
            }
            else
            {
                transform.position = untoggledLoc[value - 1];
                currentOrder[counter] = -1;
                toggled = false;
                counter--;
            }
            print(counter);
        }
    }
    void checkComplete()
    {
        bool correct = true;
        if (currentOrder[3] != -1)
        {
            for (int i = 0; i < currentOrder.Length; i++)
            {
                if (currentOrder[i] != key[i])
                {
                    correct = false;
                }
            }
            if (correct)
            {
                correctOrder();
            }
            else
            {
                incorrectOrder();
            }
        }
    }
    void incorrectOrder()
    {
        print("incorrect");
        for (int i = 0; i < currentOrder.Length; i++)
        {
            currentOrder[i] = -1;
        }
        foreach (GameObject tempCircuit in circuitList)
        {
            Circuit tempCircuit2 = tempCircuit.GetComponent<Circuit>();
            tempCircuit.transform.position = untoggledLoc[tempCircuit2.value - 1];
            tempCircuit2.toggled = false;
        }
        counter = -1;
    }
    void correctOrder()
    {
        foreach (GameObject tempCircuit in circuitList)
        {
            Circuit tempCircuit2 = tempCircuit.GetComponent<Circuit>();
            tempCircuit2.isComplete = true;
        }
        GameObject[] tempBG;
        tempBG = GameObject.FindGameObjectsWithTag("FirstRoomRedDoor");
        foreach (GameObject tempBGObj in tempBG)
        {
            SpriteRenderer tempBGObjRenderer = tempBGObj.GetComponent<SpriteRenderer>();
            tempBGObjRenderer.enabled = true;
        }
        Play();
        print("correct");
    }
}
