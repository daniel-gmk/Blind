using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    // Use this for initialization
    static int count = 0;
    GameObject[] redObjects;
    GameObject[] blueObjects;
    GameObject[] greenObjects;

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

    void Start()
    {
        Play();
        blueObjects = GameObject.FindGameObjectsWithTag("BlueObjects");
        redObjects = GameObject.FindGameObjectsWithTag("RedObjects");
        greenObjects = GameObject.FindGameObjectsWithTag("GreenObjects");
        foreach (GameObject GreenObjects in greenObjects)
        {
            SpriteRenderer greenObjectsRenderer = GreenObjects.GetComponent<SpriteRenderer>();
            greenObjectsRenderer.enabled = false;
        }
        foreach (GameObject RedObjects in redObjects)
        {
            SpriteRenderer redObjectsRenderer = RedObjects.GetComponent<SpriteRenderer>();
            redObjectsRenderer.enabled = false;
        }
        foreach (GameObject BlueObjects in blueObjects)
        {
            SpriteRenderer blueObjectsRenderer = BlueObjects.GetComponent<SpriteRenderer>();
            blueObjectsRenderer.enabled = false;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        TriggerPill();
    }

    public void TriggerPill()
    {
        GameObject Doors;
        Doors = GameObject.FindGameObjectWithTag("MainCamera");
        Door tempDoor = Doors.GetComponent<Door>();
        GameObject[] Pills;
        if (count == 0)
        {
            GameObject[] redObjects;
            redObjects = GameObject.FindGameObjectsWithTag("RedObjects");
            foreach (GameObject RedObjects in redObjects)
            {
                SpriteRenderer redObjectsRenderer = RedObjects.GetComponent<SpriteRenderer>();
                redObjectsRenderer.enabled = true;
            }
            count++;
        }
        else if (count == 1 && tempDoor.CurrentRoom == 3)
        {
            GameObject[] BluePills;
            BluePills = GameObject.FindGameObjectsWithTag("BluePill");
            foreach (GameObject BluePillObjs in BluePills)
            {
                SpriteRenderer BluePillRenderer = BluePillObjs.GetComponent<SpriteRenderer>();
                BluePillRenderer.enabled = false;
            }
            GameObject[] BluePills2;
            BluePills2 = GameObject.FindGameObjectsWithTag("BluePill2");
            foreach (GameObject BluePill2Objs in BluePills2)
            {
                SpriteRenderer BluePill2Renderer = BluePill2Objs.GetComponent<SpriteRenderer>();
                BluePill2Renderer.enabled = false;
            }
            GameObject[] blueObjects;
            blueObjects = GameObject.FindGameObjectsWithTag("BlueObjects");
            foreach (GameObject BlueObjects in blueObjects)
            {
                SpriteRenderer blueObjectsRenderer = BlueObjects.GetComponent<SpriteRenderer>();
                blueObjectsRenderer.enabled = true;
            }
            count++;
        }
        else if (count == 2 && tempDoor.CurrentRoom == 2)
        {
            GameObject[] GreenPills;
            GreenPills = GameObject.FindGameObjectsWithTag("GreenPill");
            foreach (GameObject GreenPillObjs in GreenPills)
            {
                SpriteRenderer GreenPillRenderer = GreenPillObjs.GetComponent<SpriteRenderer>();
                GreenPillRenderer.enabled = false;
            }
            GameObject[] greenObjects;
            greenObjects = GameObject.FindGameObjectsWithTag("GreenObjects");
            foreach (GameObject GreenObjects in greenObjects)
            {
                SpriteRenderer greenObjectsRenderer = GreenObjects.GetComponent<SpriteRenderer>();
                greenObjectsRenderer.enabled = true;
            }
            count++;
        }
        Pills = GameObject.FindGameObjectsWithTag("Pill");
        foreach (GameObject PillInstance in Pills)
        {
            SpriteRenderer PillRenderer = PillInstance.GetComponent<SpriteRenderer>();
            PillRenderer.enabled = false;
        }
        GameObject[] Circuits;
        Circuits = GameObject.FindGameObjectsWithTag("Circuit");
        foreach (GameObject CircuitObj in Circuits)
        {
            Circuit tempCircuit = CircuitObj.GetComponent<Circuit>();
            if (tempCircuit.isComplete == false)
            {
                tempCircuit.isEnabled = true;
            }
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

    public void Stop()
    {
        source.Stop();
    }
}
