using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterCreationUIControl : MonoBehaviour {

	// Menus

	public GameObject mainMenu;
	public GameObject characterNameMenu;
	public GameObject characterTraitsMenu;
	public GameObject setupBusinessMenu;
	public GameObject selectGameDiffMenu;

	// UI Elements

	public InputField playerNameInput;
	public InputField businessNameInput;
	public Button savePlayerNameButton;		// nextButton on characterNameMenu
	public Button saveBusinessNameButton;	// nextButton on setupBusinessMenu
	public Button finishButton;				// finishButton on selectGameDiffMenu
	public Toggle easyToggle;
	public Toggle normalToggle;
	public Toggle hardToggle;

	// Variables

	private char gameDiff;
	
	// Methods
	
	//void Awake(){

		// Get reference for menu because it was instantiated 
		//mainMenu = GameObject.FindWithTag("MainMenu");
	//} // Awake


	// To get the menu Setup. Runs when player goes to visit it
	public void SetUp(){

		// Activates Character Name Menu
		characterNameMenu.gameObject.SetActive (true);

		// Clears playerNameInput
		playerNameInput.text = "";

		// resets selected traits
		characterTraitsMenu.GetComponent<GeneratePlayerTraits> ().ResetTraits ();

		// Clears businessNameInput
		businessNameInput.text = "";

		// Makes nextButton not interactable
		savePlayerNameButton.GetComponent<CanvasGroup> ().interactable = false;
		saveBusinessNameButton.GetComponent<CanvasGroup> ().interactable = false;
		finishButton.GetComponent<CanvasGroup> ().interactable = false;

	} // SetUp()


	// its run every time the input field changes
	// to check to make sure it's a valid name
	public void ValidPlayerName(){

		if (playerNameInput.text.Equals("") || playerNameInput.text.StartsWith(" ")) { // if input is blank or starts with space

			savePlayerNameButton.GetComponent<CanvasGroup> ().interactable = false;
		} else { // if it doesn't = a valid name

			savePlayerNameButton.GetComponent<CanvasGroup> ().interactable = true;
		}// if
	} // ValidPlayerName()


	// its run every time the input field changes
	// to check to make sure it's a valid name
	public void ValidBusinessName(){
		
		if (businessNameInput.text.Equals("") || businessNameInput.text.StartsWith(" ")) { // if input is blank or starts with space
			
			saveBusinessNameButton.GetComponent<CanvasGroup> ().interactable = false;
		} else { // if it doesn't = a valid name
			
			saveBusinessNameButton.GetComponent<CanvasGroup> ().interactable = true;
		}// if
	} // ValidBusinessName()


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


	// Saves the name of the business and moves to next section
	public void SaveBusinessName(){

		// saves business name by setting it in gameManager
		GameManager.gameManager.BName = businessNameInput.text;

		// deactivates setupBusinessMenu and activates selectGameDiffMenu
		setupBusinessMenu.gameObject.SetActive (false);
		selectGameDiffMenu.gameObject.SetActive (true);

	} // SaveBusinessName()


	// fires every time a game Diff toggle is clicked
	// to make sure a game difficulty is selected
	public void ValidGameDiff(){

		if (easyToggle.isOn) { // if easy game Diff is selected

			// Saves game difficulty to gameDiff
			gameDiff = 'E'; // easy

			// Makes finishButton clickable
			finishButton.GetComponent<CanvasGroup> ().interactable = true;

		} else if (normalToggle.isOn) { // if normal game Diff is selected

			// Saves game difficulty to gameDiff
			gameDiff = 'N'; // normal
			
			// Makes finishButton clickable
			finishButton.GetComponent<CanvasGroup> ().interactable = true;

		} else if (hardToggle.isOn) { // hard game Diff is selected

			// Saves game difficulty to gameDiff
			gameDiff = 'H'; // hard
			
			// Makes finishButton clickable
			finishButton.GetComponent<CanvasGroup> ().interactable = true;


		} else { // if no difficulty is selected

			// make finishButton non clickable
			finishButton.GetComponent<CanvasGroup> ().interactable = false;

		} // if

	} // ValidGameDiff()


	// Save game difficulty and finishes character creation
	public void SaveGameDiffAndFinish(){

		// Saves Game Difficulty to gameManager
		GameManager.gameManager.GDif = gameDiff;

		// Loads Next Scene, New Game Ready to start
		Application.LoadLevel("Main"); // Loads Second Scene

	} // SaveGameDiffAndFinish()

	
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
