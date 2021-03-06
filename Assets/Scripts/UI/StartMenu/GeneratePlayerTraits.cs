﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// Script for generating toggles for all selectable player traits

public class GeneratePlayerTraits : MonoBehaviour {

	/*===================== Menus =====================================================================================*/
	
	public GameObject characterCreationMenu;
	public GameObject selectCharacterTraitsMenu;


	/*===================== Scripts =====================================================================================*/

	public CharacterInfo characterInfoScript;
	 

	/*===================== UI Elements =====================================================================================*/

	public Text headingText;
	public Toggle traitTogglePrefab;
	public Button exitButton;
	public Button nextButton;

	private Toggle[] toggles;
	public Toggle[] Toggles {
		
		get{ return toggles;}
		set{ toggles = value;}
	}


	/*===================== Variables =====================================================================================*/

	private float posY;
	private float posX = 0;
	private int arrayLength;

	private int spacing = 50;
	private int startingPoint = 0;

	// to save traits currently picked
	private int[] selectedTraits = new int[5];
	public int[] SelectedTraits {
		get{ return selectedTraits;}
		set{ selectedTraits = value;}
	}


	/*===================== Methods =====================================================================================*/

	/*===================== Awake() =====================================================================================*/

	void Awake(){

		// get references for scripts
		characterInfoScript = GetComponent<CharacterInfo> ();

	} // Awake()


	/*===================== Start() =====================================================================================*/
	
	void Start(){

		// get the length of traitsSelection array
		arrayLength = characterInfoScript.TraitsSelection.Length;

		// determin starting Y position. starting point value decides 
		// where the aprox center of the list of trait toggles will appear
		posY = startingPoint + (arrayLength / 2) * spacing;		

		// Set the size of toggle array depending on amount of selectable traits
		toggles = new Toggle[arrayLength];

		// set up the trait toggles on the page
		SetUpTraits ();

		// After traits are setup, deactivate gameobject

		// Deactivates Character Trait Menu
		gameObject.SetActive (false);

		// Deactivates CharacterCreationMenu
		characterCreationMenu.gameObject.SetActive(false);

		// Sets CharacterCreationMenu's alpha to 1 (makes it visable)
		characterCreationMenu.GetComponent<CanvasGroup> ().alpha = 1;

		// Makes CharacterCreationMenu clickable again
		characterCreationMenu.GetComponent<CanvasGroup> ().blocksRaycasts = true;

	} // Start()


	/*===================== SetUpTraits() =====================================================================================*/

	// Sets up the traits toggles
	public void SetUpTraits(){

		// move heading above first trait with a bit of extra space
		headingText.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0f, posY + 80f);

		for (int i = 0; i < arrayLength; i++) {

			// instantiate toggle to set position
			Toggle toggle = (Toggle)Instantiate (traitTogglePrefab);

			// make toggle a child of "SelectCharacterTraitsMenu" GameObject
			toggle.transform.SetParent (selectCharacterTraitsMenu.transform, false);

			// set position of toggle
			toggle.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, posY);

			// set the text on the toggle to the name of selectable trait
			toggle.GetComponentInChildren<Text>().text = characterInfoScript.TraitsSelection[i];
		
			// set onValueChanged event to fire CheckSelected method
			toggle.onValueChanged.AddListener(delegate {CheckSelected();});

			// Add toggle to array of toggles
			toggles[i] = toggle;

			// Decrement position of toggle by 25
			posY -= spacing;

		} // for

		// move the buttons down to the y poition under last trait with a bit of exit space
		exitButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-75f, posY - 55f);
		nextButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (75f, posY - 55f);

	} // SetUpTraits()


	/*===================== CheckSelected() =====================================================================================*/

	// Fires everytime a toggle is checked/unchecked
	public void CheckSelected(){

		int numberSelected = 0;
		int count = 0;

		// loops through the array of toggles that are generated
		for(int i = 0; i < Toggles.Length; i++){

			// checks to see which toggles are selected or not
			if(Toggles[i].isOn == true){ // if trait toggle selected

				if(numberSelected < 5){ // only add 5 trait indexes to array

					// add Trait to players selected trait list
					selectedTraits[numberSelected] = count;
				} // if

				// count the number of traits selected
				numberSelected++;
			} // if

			// To keep track of the current trait index
			count++;
		} // for

		// can only select 5 traits. if 5, can continue
		if(numberSelected == 5){

			nextButton.interactable = true;
		} else { // if > or < then 5, cant continue

			nextButton.interactable = false;
		} // if

	} // CheckSelected()


	/*===================== ResetTraits() =====================================================================================*/

	// resets all of the toggles to off
	public void ResetTraits(){

		for (int i = 0; i < Toggles.Length; i++) {

			// reset toggles by making them all turned off
			Toggles[i].isOn = false;
		} // for

	} // ResetTraits()

} // class
