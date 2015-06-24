using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// Script for generating toggles for all selectable player traits

public class GeneratePlayerTraits : MonoBehaviour {

	// menus

	public GameObject selectCharacterTraitsMenu;

	// scripts

	public CharacterInfo characterInfoScript;

	// UI Elements

	public Text headingText;
	public Toggle traitTogglePrefab;
	public Button exitButton;
	public Button nextButton;

	private Toggle[] toggles;
	public Toggle[] Toggles {
		
		get{ return toggles;}
		set{ toggles = value;}
	}

	public float posY;
	public float posX = 0;
	public int arrayLength;

	public int spacing = 25;
	public int startingPoint = -180;

	// to save traits currently picked
	private int[] selectedTraits = new int[5];
	public int[] SelectedTraits {
		get{ return selectedTraits;}
		set{ selectedTraits = value;}
	}

	// Methods

	void Awake(){

		// get references for scripts
		characterInfoScript = GetComponent<CharacterInfo> ();

	} // Awake()
	
	void Start(){

		// get the length of traitsSelection array
		arrayLength = characterInfoScript.TraitsSelection.Length;

		posY = startingPoint + (arrayLength / 2) * spacing;		

		toggles = new Toggle[arrayLength];

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
		exitButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-55f, posY - 30f);
		nextButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (55f, posY - 30f);

	} // SetUpTraits()

	// Fires everytime a toggle is checked/unchecked
	public void CheckSelected(){

		int numberSelected = 0;
		int count = 0;

		foreach(Toggle toggle in toggles){


			if(toggle.isOn == true){

				if(numberSelected < 5){ // only add 5 trait indexes to array
					// add Trait to players selected trait list
					selectedTraits[numberSelected] = count;
				}

				// count the number of traits selected
				numberSelected++;
			} // if

			// To keep track of the current trait index
			count++;
		} // for

		// can only select 5 traits. if 5, can continue
		if(numberSelected == 5){

			nextButton.GetComponent<CanvasGroup> ().interactable = true;
		} else { // if > or < then 5, cant continue

			nextButton.GetComponent<CanvasGroup> ().interactable = false;
		} // if

	} // CheckSelected()

} // class
