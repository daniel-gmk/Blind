using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chips : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject[] tempObj;
        tempObj = GameObject.FindGameObjectsWithTag("Skrrt");
        foreach (GameObject tempObjs in tempObj)
        {
            SpriteRenderer tempObjsRenderer = tempObjs.GetComponent<SpriteRenderer>();
            tempObjsRenderer.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        GameObject Doors;
        Doors = GameObject.FindGameObjectWithTag("MainCamera");
        Door tempDoor = Doors.GetComponent<Door>();
        tempDoor.completable = true;

        GameObject[] tempObj;
        tempObj = GameObject.FindGameObjectsWithTag("Skrrt");
        foreach (GameObject tempObjs in tempObj)
        {
            SpriteRenderer tempObjsRenderer = tempObjs.GetComponent<SpriteRenderer>();
            tempObjsRenderer.enabled = true;
        }

        SpriteRenderer tempRenderer = this.GetComponent<SpriteRenderer>();
        tempRenderer.enabled = false;
    }
}
