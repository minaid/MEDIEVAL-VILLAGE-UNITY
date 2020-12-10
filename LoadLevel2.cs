using UnityEngine;
using System.Collections;

public class LoadLevel2 : MonoBehaviour {
	public GameObject otherObject;
    public GameObject guiObject;
    public string levelToLoad;
 // Use this for initialization
 void Start () {
        guiObject.SetActive(false);
 }
 
 // Update is called once per frame
 void OnTriggerStay (Collider other)
    {
	otherObject.GetComponent<chase_troll>();
  if(other.gameObject.tag == "Player" && otherObject.GetComponent<chase_troll>().enabled==false)
        {
            guiObject.SetActive(true);
            if(guiObject.activeInHierarchy == true && Input.GetKeyDown(KeyCode.E))
            {
                Application.LoadLevel(levelToLoad);
            }
        }
 }

    void OnTriggerExit()
    {
        guiObject.SetActive(false);
    }
}﻿