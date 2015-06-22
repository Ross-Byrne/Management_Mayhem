﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterCreationUIControl : MonoBehaviour {

	// Menus
	public GameObject mainMenu;

	// UI Elements
	public InputField playerNameInput;
	public Button nextButton;
	
	// Methods

	// To get the menu Setup. Runs when player goes to visit it
	public void SetUp(){

		nextButton.GetComponent<CanvasGroup> ().interactable = false;
	} // SetUp()

	// its run every time the input field changes
	// to check to make sure it's a valid name
	public void CanContinue(){

		if (playerNameInput.text.Equals("") || playerNameInput.text.StartsWith(" ")) { // if input is blank or starts with space

			nextButton.GetComponent<CanvasGroup> ().interactable = false;
		} else { // if it doesn't = a valid name

			nextButton.GetComponent<CanvasGroup> ().interactable = true;
		}// if
	} // CanContinue()

	public void SavePlayerName(){

		// save player name by setting it in gamemanager
		GameManager.gameManager.pName = playerNameInput.text;

	} // SavePlayerName()

	// To exit character Creation Menu
	public void Exit(){

		// Deactivates Character Creation Menu and Activates MainMenu
		gameObject.SetActive(false);
		mainMenu.gameObject.SetActive(true);
	} // Exit()

} // class