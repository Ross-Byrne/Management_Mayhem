using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterCreationUIControl : MonoBehaviour {

	/*===================== Menus =====================================================================================*/

	public GameObject mainMenu;
	public GameObject characterNameMenu;
	public GameObject characterTraitsMenu;
	public GameObject setupBusinessMenu;
	public GameObject selectGameDiffMenu;


	/*===================== UI Elements =====================================================================================*/

	public InputField playerNameInput;
	public InputField businessNameInput;
	public Button savePlayerNameGenderButton;		// nextButton on characterNameGenderMenu
	public Button saveBusinessNameButton;	// nextButton on setupBusinessMenu
	public Button finishButton;				// finishButton on selectGameDiffMenu

	public Toggle maleToggle;
	public Toggle femaleToggle;
	public Toggle easyToggle;
	public Toggle normalToggle;
	public Toggle hardToggle;


	/*===================== Variables =====================================================================================*/

	private char gameDiff;


	/*===================== Methods =====================================================================================*/

	/*===================== Awake() =====================================================================================*/

	void Awake(){

		// Get reference for menu because it was instantiated 
		mainMenu = GameObject.FindWithTag("MainMenu");

	} // Awake()


	/*===================== SetUp() =====================================================================================*/

	// To get the menu Setup. Runs when player goes to visit it
	public void SetUp(){

		// Sets isNewGameCreated to false
		GameManager.gameManager.IsNewGameCreated = false;

		// Activates Character Name Menu
		characterNameMenu.gameObject.SetActive (true);

		// Clears playerNameInput
		playerNameInput.text = "";

		// Clears selected gender
		maleToggle.isOn = false;
		femaleToggle.isOn = false;

		// resets selected traits
		characterTraitsMenu.GetComponent<GeneratePlayerTraits> ().ResetTraits ();

		// Clears businessNameInput
		businessNameInput.text = "";

		// Clears selected game difficulty
		easyToggle.isOn = false;
		normalToggle.isOn = false;
		hardToggle.isOn = false;

		// Makes nextButton not interactable
		savePlayerNameGenderButton.interactable = false;
		saveBusinessNameButton.interactable = false;
		finishButton.interactable = false;

	} // SetUp()


	/*===================== ValidNameAndGender() =====================================================================================*/

	// checks to see if players name and gender a valid
	public void ValidNameAndGender(){

		// if players name and gender is valid
		if (ValidPlayerName () && ValidPlayerGender ()) {

			Debug.Log ("Valid");
			// activate the next button
			savePlayerNameGenderButton.interactable = true;

		} else { // if not valid

			Debug.Log ("Invalid");

			// deavtivate next button
			savePlayerNameGenderButton.interactable = false;
		} // if
	} // ValidNameAndGender()

	/*===================== ValidPlayerName() =====================================================================================*/

	// Checks to make sure a valid name is entered
	public bool ValidPlayerName(){

		// if input is blank or starts with space
		if (playerNameInput.text.Equals("") || playerNameInput.text.StartsWith(" ")) { 

			return false;

		} else { // if it doesn't = a valid name

			Debug.Log ("Valid Name");

			return true;

		}// if
	} // ValidPlayerName()


	/*===================== ValidPlayerGender() =====================================================================================*/
	
	// checks if a valid gender has been selected
	public bool ValidPlayerGender(){

		if (maleToggle.isOn) { // if selected male

			Debug.Log ("Valid Gender");

			// Saves player gender
			GameManager.gameManager.PGender = 'M'; // Male

			return true;
			
		} else if (femaleToggle.isOn) { // if normal game Diff is selected

			Debug.Log ("Valid Gender");
			// Saves player gender
			GameManager.gameManager.PGender = 'F'; // Female

			return true;
			
		}  else { // if no difficulty is selected

			// Clears Gender
			GameManager.gameManager.PGender = ' ';

			return false;
			
		} // if
	} // ValidPlayerGender()

	/*===================== ValidBusinessName() =====================================================================================*/

	// its run every time the input field changes
	// to check to make sure it's a valid name
	public void ValidBusinessName(){
		
		if (businessNameInput.text.Equals("") || businessNameInput.text.StartsWith(" ")) { // if input is blank or starts with space
			
			saveBusinessNameButton.interactable = false;
		} else { // if it doesn't = a valid name
			
			saveBusinessNameButton.interactable = true;
		}// if
	} // ValidBusinessName()


	/*===================== SavePlayerName() =====================================================================================*/

	// Saves players name that was entered and moves to next section 
	public void SavePlayerName(){

		// save player name by setting it in gamemanager
		GameManager.gameManager.PName = playerNameInput.text;

		// deactivate enterCharacterName and activate select character trait
		characterNameMenu.SetActive (false);
		characterTraitsMenu.SetActive (true);

	} // SavePlayerName()


	/*===================== SavePlayerTraits() =====================================================================================*/

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
		characterTraitsMenu.SetActive (false);
		setupBusinessMenu.SetActive (true);

	} // SavePlayerTraits()


	/*===================== SaveBusinessName() =====================================================================================*/

	// Saves the name of the business and moves to next section
	public void SaveBusinessName(){

		// saves business name by setting it in gameManager
		GameManager.gameManager.BName = businessNameInput.text;

		// deactivates setupBusinessMenu and activates selectGameDiffMenu
		setupBusinessMenu.SetActive (false);
		selectGameDiffMenu.SetActive (true);

	} // SaveBusinessName()


	/*===================== ValidGameDiff() =====================================================================================*/

	// fires every time a game Diff toggle is clicked
	// to make sure a game difficulty is selected
	public void ValidGameDiff(){

		if (easyToggle.isOn) { // if easy game Diff is selected

			// Saves game difficulty to gameDiff
			gameDiff = 'E'; // easy

			// Makes finishButton clickable
			finishButton.interactable = true;

		} else if (normalToggle.isOn) { // if normal game Diff is selected

			// Saves game difficulty to gameDiff
			gameDiff = 'N'; // normal
			
			// Makes finishButton clickable
			finishButton.interactable = true;

		} else if (hardToggle.isOn) { // hard game Diff is selected

			// Saves game difficulty to gameDiff
			gameDiff = 'H'; // hard
			
			// Makes finishButton clickable
			finishButton.interactable = true;


		} else { // if no difficulty is selected

			// make finishButton non clickable
			finishButton.interactable = false;

		} // if

	} // ValidGameDiff()


	/*===================== SaveGameDiffAndFinish() =====================================================================================*/

	// Save game difficulty and finishes character creation
	public void SaveGameDiffAndFinish(){

		// Saves Game Difficulty to gameManager
		GameManager.gameManager.GDif = gameDiff;

		// Deactivates the sections of Character Creation Menu
		characterNameMenu.SetActive (false);
		characterTraitsMenu.SetActive (false);
		setupBusinessMenu.SetActive (false);
		selectGameDiffMenu.SetActive (false);
		
		// Deactivates Character Creation Menu itself
		gameObject.SetActive(false); 

		// Set isNewGameCreated to true
		GameManager.gameManager.IsNewGameCreated = true;

		// Loads Next Scene, New Game Ready to start
		Application.LoadLevel("Main"); // Loads Second Scene

	} // SaveGameDiffAndFinish()


	/*===================== Exit() =====================================================================================*/

	// To exit character Creation Menu
	public void Exit(){

		// Deactivates the sections of Character Creation Menu
		characterNameMenu.SetActive (false);
		characterTraitsMenu.SetActive (false);
		setupBusinessMenu.SetActive (false);
		selectGameDiffMenu.SetActive (false);

		// Deactivates Character Creation Menu itself
		gameObject.SetActive(false); 

		// activates the main menu
		mainMenu.SetActive(true);
	} // Exit()

} // class
