using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// Script for generating toggles for all selectable player traits

public class GeneratePlayerTraits : MonoBehaviour {

	public Toggle traitToggle;
	public int top = 80;
	public int arrayLength;

	void Awake(){

		// get the length of playerTraitSelect array
		arrayLength = GameManager.gameManager.PlayerTraitsSelection.Length;

		// set up the traits
		SetUpTraits ();
	}

	public void SetUpTraits(){


		for (int i = 0; i < arrayLength; i++) {

			Toggle toggle = (Toggle)Instantiate (traitToggle);
			toggle.transform.SetParent (gameObject.transform, false);
			//toggle.transform.position.Set(0,top-10, 0);
			toggle.isOn = false;
			toggle.GetComponentInChildren<Text>().text = GameManager.gameManager.PlayerTraitsSelection[i];

		} // for

	} // SetUpTraits()
} // class
