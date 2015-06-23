using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterCreationUIControl : MonoBehaviour {

	// Menus
	public GameObject mainMenu;
	public GameObject characterNameMenu;
	public GameObject characterTraitsMenu;

	// UI Elements
	public InputField playerNameInput;
	public Button nextButton;
	
	// Methods

	// To get the menu Setup. Runs when player goes to visit it
	public void SetUp(){

		// Activates Character Name Menu
		characterNameMenu.gameObject.SetActive (true);

		// Clears playerNameInput
		playerNameInput.text = "";

		// Deactivates Character Trait Menu
		characterTraitsMenu.gameObject.SetActive (false);

		// Makes nextButton not interactable
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

	// Saves players name that was entered and moves to next section 
	public void SavePlayerName(){

		// save player name by setting it in gamemanager
		GameManager.gameManager.pName = playerNameInput.text;

		// deactivate enterCharacterName and activate select character trait
		characterNameMenu.gameObject.SetActive (false);
		characterTraitsMenu.gameObject.SetActive (true);

	} // SavePlayerName()

	// Saves players traits selection and moves on to next section
	public void SavePlayerTraits(){


	} // SavePlayerTraits()


	// To exit character Creation Menu
	public void Exit(){

		// Deactivates Character Creation Menu and Activates MainMenu
		characterNameMenu.gameObject.SetActive (false);
		characterTraitsMenu.gameObject.SetActive (false);
		gameObject.SetActive(false);

		mainMenu.gameObject.SetActive(true);
	} // Exit()

} // class
