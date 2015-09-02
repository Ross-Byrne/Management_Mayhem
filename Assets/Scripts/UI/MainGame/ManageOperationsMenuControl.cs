using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Script to control the Manage Operations Menus

public class ManageOperationsMenuControl : MonoBehaviour {

	/*===================== GameObjects =====================================================================================*/
	
	// Menus
	
	public GameObject productionMenu;
	public GameObject contractsMenu;
	public GameObject researchDevelopmentMenu;
	public GameObject dealingMenu;
	public GameObject drugLabMenu;
	
	
	/*===================== UI Elements =====================================================================================*/
	
	// Buttons
	
	public Button productionButton;
	public Button contractsButton;
	public Button researchDevelopButton;
	public Button dealingButton;
	public Button drugLabButton;
	
	// Text
	
	public Text headingText;
	
	
	/*===================== Methods =====================================================================================*/
	
	/*===================== ProductionButtonControl() =====================================================================================*/
	
	// Fires when productionButton is Clicked
	public void ProductionButtonControl(){
		
		// Turn off other menus
		contractsMenu.SetActive (false);
		researchDevelopmentMenu.SetActive (false);
		dealingMenu.SetActive (false);
		drugLabMenu.SetActive (false);
		
		// Update Heading Text
		headingText.text = "Production";
		
		// Turn on Menu
		productionMenu.SetActive (true);
		
		// Disable button to show it was selected
		productionButton.interactable = false;
		
		// Activate other menu buttons
		contractsButton.interactable = true;
		researchDevelopButton.interactable = true;
		dealingButton.interactable = true;
		drugLabButton.interactable = true;

	} // ProductionButtonControl()
	
	
	/*===================== ContractsButtonControl() =====================================================================================*/
	
	// Fires when contractsButton is Clicked
	public void ContractsButtonControl(){
		
		// Turn off other menus
		productionMenu.SetActive (false);
		researchDevelopmentMenu.SetActive (false);
		dealingMenu.SetActive (false);
		drugLabMenu.SetActive (false);
		
		// Update Heading Text
		headingText.text = "Contracts";
		
		// Turn on Menu
		contractsMenu.SetActive (true);
		
		// Disable button to show it was selected
		contractsButton.interactable = false;
		
		// Activate other menu buttons
		productionButton.interactable = true;
		researchDevelopButton.interactable = true;
		dealingButton.interactable = true;
		drugLabButton.interactable = true;
		
	} // ContractsButtonControl()
	
	
	/*===================== ResearchDevelopButtonControl() =====================================================================================*/
	
	// Fires when researchDevelopButton is Clicked
	public void ResearchDevelopButtonControl(){
		
		// Turn off other menus
		productionMenu.SetActive (false);
		contractsMenu.SetActive (false);
		dealingMenu.SetActive (false);
		drugLabMenu.SetActive (false);
		
		// Update Heading Text
		headingText.text = "Research & Development";
		
		// Turn on Menu
		researchDevelopmentMenu.SetActive (true);
		
		// Disable button to show it was selected
		researchDevelopButton.interactable = false;
		
		// Activate other menu buttons
		productionButton.interactable = true;
		contractsButton.interactable = true;
		dealingButton.interactable = true;
		drugLabButton.interactable = true;
		
	} // ResearchDevelopButtonControl()


	/*===================== DealingButtonControl() =====================================================================================*/
	
	// Fires when dealingButton is Clicked
	public void DealingButtonControl(){
		
		// Turn off other menus
		productionMenu.SetActive (false);
		contractsMenu.SetActive (false);
		researchDevelopmentMenu.SetActive (false);
		drugLabMenu.SetActive (false);
		
		// Update Heading Text
		headingText.text = "Dealing";
		
		// Turn on Menu
		dealingMenu.SetActive (true);
		
		// Disable button to show it was selected
		dealingButton.interactable = false;
		
		// Activate other menu buttons
		productionButton.interactable = true;
		contractsButton.interactable = true;
		researchDevelopButton.interactable = true;
		drugLabButton.interactable = true;
		
	} // DealingButtonControl()


	/*===================== DrugLabButtonControl() =====================================================================================*/
	
	// Fires when drugLabButton is Clicked
	public void DrugLabButtonControl(){
		
		// Turn off other menus
		productionMenu.SetActive (false);
		contractsMenu.SetActive (false);
		researchDevelopmentMenu.SetActive (false);
		dealingMenu.SetActive (false);
		
		// Update Heading Text
		headingText.text = "The Lab";
		
		// Turn on Menu
		drugLabMenu.SetActive (true);
		
		// Disable button to show it was selected
		drugLabButton.interactable = false;
		
		// Activate other menu buttons
		productionButton.interactable = true;
		contractsButton.interactable = true;
		researchDevelopButton.interactable = true;
		dealingButton.interactable = true;
		
	} // DrugLabButtonControl()

} // class
