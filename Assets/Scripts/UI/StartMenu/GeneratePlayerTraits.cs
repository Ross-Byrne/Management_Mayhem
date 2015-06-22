using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// Script for generating toggles for all selectable player traits

public class GeneratePlayerTraits : MonoBehaviour {

	public Toggle traitTogglePrefab;
	public float posY;
	public float posX = 0;
	public int arrayLength;

	public int spacing = 25;
	public int startingPoint = -180;

	void Awake(){

		// get the length of playerTraitSelect array
		arrayLength = GameManager.gameManager.PlayerTraitsSelection.Length;

		posY = startingPoint;		

		// set up the traits
		SetUpTraits ();
	}

	public void SetUpTraits(){


		for (int i = 0; i < arrayLength; i++) {

			// instantiate toggle to set position
			Toggle toggle = (Toggle)Instantiate (traitTogglePrefab);

			// make toggle a child of "SelectCharacterTraitsMenu" GameObject
			toggle.transform.SetParent (gameObject.transform, false);

			// set position of toggle
			toggle.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, posY);

			// set is to not be toggled
			toggle.isOn = false;

			// set the text on the toggle to the name of selectable trait
			toggle.GetComponentInChildren<Text>().text = GameManager.gameManager.PlayerTraitsSelection[i];

			// Decrement position of toggle by 25
			posY -= spacing;
		} // for

	} // SetUpTraits()
} // class
