using UnityEngine;
using System.Collections;

public class OnTriggerLoadLevel : MonoBehaviour {
	public GameObject otherObject;
    public GameObject guiObject;
    public string levelToLoad;

	void Start () {
        guiObject.SetActive(false);
 }
 
 void OnTriggerStay (Collider other)
    {
	otherObject.GetComponent<flag>();

  if(other.gameObject.tag == "Player" && otherObject.GetComponent<flag>().enabled==false)
        {
            guiObject.SetActive(true);
            if(guiObject.activeInHierarchy == true && Input.GetKeyDown(KeyCode.E))
            {
                Application.LoadLevel(levelToLoad);
            }}}
    void OnTriggerExit()
    {
        guiObject.SetActive(false);
    }
}﻿