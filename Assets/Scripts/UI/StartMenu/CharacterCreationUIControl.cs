using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterCreationUIControl : MonoBehaviour {

	// Menus

	public GameObject mainMenu;
	public GameObject characterNameMenu;
	public GameObject characterTraitsMenu;
	public GameObject setupBusinessMenu;

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

		// resets selected traits
		characterTraitsMenu.GetComponent<GeneratePlayerTraits> ().ResetTraits ();

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
		GameManager.gameManager.PName = playerNameInput.text;

		// deactivate enterCharacterName and activate select character trait
		characterNameMenu.gameObject.SetActive (false);
		characterTraitsMenu.gameObject.SetActive (true);

	} // SavePlayerName()

	// Saves players traits selection and moves on to next section
	public void SavePlayerTraits(){

		// adds selected player traits to GameManager
		for (int i = 0; i < GameManager.gameManager.PTraits.Length; i++) {

			// gets the traits from the list of selectable traits in CharacterInfo
			// uses the array of selected traits from GeneratePlayerTraits as an index
			GameManager.gameManager.PTraits [i] = 
				characterTraitsMenu.GetComponent<CharacterInfo> ().TraitsSelection [characterTraitsMenu.GetComponent<GeneratePlayerTraits> ().SelectedTraits[i]];
		} // for

		// moves to next section
		characterTraitsMenu.gameObject.SetActive (false);
		setupBusinessMenu.gameObject.SetActive (true);

	} // SavePlayerTraits()
	
	// To exit character Creation Menu
	public void Exit(){

		// Deactivates the sections of Character Creation Menu
		characterNameMenu.gameObject.SetActive (false);
		characterTraitsMenu.gameObject.SetActive (false);
		setupBusinessMenu.gameObject.SetActive (false);

		// Deactivates Character Creation Menu itself
		gameObject.SetActive(false); 

		// activates the main menu
		mainMenu.gameObject.SetActive(true);
	} // Exit()

} // class
