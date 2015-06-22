using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// Script for generating toggles for all selectable player traits

public class GeneratePlayerTraits : MonoBehaviour {

	// scripts

	public CharacterInfo characterInfoScript;

	// UI Elements

	public Text headingText;
	public Toggle traitTogglePrefab;
	public Button exitButton;
	public Button nextButton;

	public float posY;
	public float posX = 0;
	public int arrayLength;

	public int spacing = 25;
	public int startingPoint = -180;

	// Methods

	void Awake(){

		// get references for scripts
		characterInfoScript = GetComponent<CharacterInfo> ();

	} // Awake()
	
	void Start(){

		// get the length of traitsSelection array
		arrayLength = characterInfoScript.TraitsSelection.Length;

		posY = startingPoint + (arrayLength / 2) * spacing;		

		// set up the traits
		SetUpTraits ();

	} // Start()

	public void SetUpTraits(){

		// move heading above first trait with a bit of extra space
		headingText.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0f, posY + 60f);

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
			toggle.GetComponentInChildren<Text>().text = characterInfoScript.TraitsSelection[i];

			// Decrement position of toggle by 25
			posY -= spacing;

		} // for

		// move the buttons down to the y poition under last trait with a bit of exit space
		exitButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-55f, posY - 30f);
		nextButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (55f, posY - 30f);

	} // SetUpTraits()
} // class
