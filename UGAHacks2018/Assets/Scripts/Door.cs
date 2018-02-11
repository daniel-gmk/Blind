using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private AudioSource source;

    public AudioClip Clip;
    [Range(0, 1)]
    public float Volume = 2f;
    [Range(.25f, 3)]
    public float Pitch = 2f;
    public bool Loop = false;
    [Range(0f, 2f)]
    public float SpacialBlend = 2f;
    public bool completable = false;
    Vector3[] RoomCoords = {
        new Vector3(0, 0, -10),
        new Vector3(13.32f, 0, -10),
        new Vector3(26.6f, 0, -10)
        };
    public int CurrentRoom = 1;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (CurrentRoom == 2)
            {
                CurrentRoom = 3;
                transform.position = RoomCoords[CurrentRoom - 1];
                Play();
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (CurrentRoom == 3)
            {
                CurrentRoom = 2;
                transform.position = RoomCoords[CurrentRoom - 1];
                Play();
            }
            else if (CurrentRoom == 2)
            {
                CurrentRoom = 1;
                transform.position = RoomCoords[CurrentRoom - 1];
                Play();
            }

        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (CurrentRoom == 1)
            {
                if (completable == true)
                {
                    Vector3 FinalCredits = new Vector3(-13.568f, 0, -10);
                    transform.position = FinalCredits;
                }
            }
        }

        //Check if youre able to win the game
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (CurrentRoom == 1)
            {
                GameObject[] Circuits;
                bool tempCheck = true;
                Circuits = GameObject.FindGameObjectsWithTag("Circuit");
                foreach (GameObject CircuitObj in Circuits)
                {
                    Circuit tempCircuit = CircuitObj.GetComponent<Circuit>();
                    if (tempCircuit.isComplete == false)
                    {
                        tempCheck = false;
                    }
                }
                if (tempCheck == true)
                {
                    CurrentRoom = 2;
                    transform.position = RoomCoords[CurrentRoom - 1];
                }
                Play();
            }
        }
    }
}
