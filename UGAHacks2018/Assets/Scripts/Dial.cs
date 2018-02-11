using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dial : MonoBehaviour
{
    static int[] combination = new int[6];
    int[] solution = { 1, 1, 1, 0, 2, 1 };
    public int identifier = 0;
    public bool isUp = true;
    public Sprite Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine;
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
        GameObject combo1;
        combo1 = GameObject.FindGameObjectWithTag("Combo1");
        SpriteRenderer combo1Renderer = combo1.GetComponent<SpriteRenderer>();
        combo1Renderer.sprite = Zero;

        GameObject[] bluePill;
        bluePill = GameObject.FindGameObjectsWithTag("BluePill");
        foreach (GameObject BluePills in bluePill)
        {
            SpriteRenderer BluePillRenderer = BluePills.GetComponent<SpriteRenderer>();
            BluePillRenderer.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetSprite(Sprite input)
    {
        GameObject[] combo1;
        combo1 = GameObject.FindGameObjectsWithTag("Combo1");
        foreach (GameObject combo1s in combo1)
        {
            Combo combo2 = combo1s.GetComponent<Combo>();
            if (combo2.identifier == this.identifier)
            {
                SpriteRenderer combo1Renderer = combo1s.GetComponent<SpriteRenderer>();
                combo1Renderer.sprite = input;
            }
        }
    }
    private void OnMouseDown()
    {
        if (isUp)
        {
            combination[identifier]++;
            if (combination[identifier] < 10)
            {
                if (combination[identifier] == 1)
                {
                    SetSprite(One);
                }
                if (combination[identifier] == 2)
                {
                    SetSprite(Two);
                }
                if (combination[identifier] == 3)
                {
                    SetSprite(Three);
                }
                if (combination[identifier] == 4)
                {
                    SetSprite(Four);
                }
                if (combination[identifier] == 5)
                {
                    SetSprite(Five);
                }
                if (combination[identifier] == 6)
                {
                    SetSprite(Six);
                }
                if (combination[identifier] == 7)
                {
                    SetSprite(Seven);
                }
                if (combination[identifier] == 8)
                {
                    SetSprite(Eight);
                }
                if (combination[identifier] == 9)
                {
                    SetSprite(Nine);
                }
            }
        }
        if (!isUp)
        {
            combination[identifier]--;
            if (combination[identifier] >= 0)
            {
                if (combination[identifier] == 0)
                {
                    SetSprite(Zero);
                }
                if (combination[identifier] == 1)
                {
                    SetSprite(One);
                }
                if (combination[identifier] == 2)
                {
                    SetSprite(Two);
                }
                if (combination[identifier] == 3)
                {
                    SetSprite(Three);
                }
                if (combination[identifier] == 4)
                {
                    SetSprite(Four);
                }
                if (combination[identifier] == 5)
                {
                    SetSprite(Five);
                }
                if (combination[identifier] == 6)
                {
                    SetSprite(Six);
                }
                if (combination[identifier] == 7)
                {
                    SetSprite(Seven);
                }
                if (combination[identifier] == 8)
                {
                    SetSprite(Eight);
                }
                if (combination[identifier] == 9)
                {
                    SetSprite(Nine);
                }
            }
        }
        if (combination[identifier] < 0)
        {
            combination[identifier] = 0;
        }


        if (combination[identifier] > 9)
        {
            combination[identifier] = 9;
        }

        bool correct = true;
        for (int i = 0; i < combination.Length; i++)
        {
            if (combination[i] != solution[i])
            {
                correct = false;
            }
        }
        if (correct == true)
        {
            Play();
            GameObject[] bluePill;
            bluePill = GameObject.FindGameObjectsWithTag("BluePill");
            foreach (GameObject BluePills in bluePill)
            {
                SpriteRenderer BluePillRenderer = BluePills.GetComponent<SpriteRenderer>();
                BluePillRenderer.enabled = true;
            }
        }
    }
}
