using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// Script for generating toggles for all selectable player traits

public class GeneratePlayerTraits : MonoBehaviour {

	public Toggle traitToggle;
	public int top = 80;
	//public string[] traits;

	void Awake(){
		int len = GameManager.gameManager.playerTraitsSelection.Length;
		SetUpTraits ();
	}

	public void SetUpTraits(){


		for (int i = 0; i < 10; i++) {

			Toggle toggle = (Toggle)Instantiate (traitToggle);
			toggle.transform.SetParent (gameObject.transform, false);
			//toggle.transform.position.Set(0,top-10, 0);
			toggle.isOn = false;
			toggle.GetComponentInChildren<Text>().text = GameManager.gameManager.pName;

		} // for

	} // SetUpTraits()
} // class
