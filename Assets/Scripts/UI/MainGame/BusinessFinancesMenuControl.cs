using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Script to control Menus in Business Finances Menu

public class BusinessFinancesMenuControl : MonoBehaviour {

	/*===================== GameObjects =====================================================================================*/

	// Menus

	public GameObject maintenanceMenu;
	public GameObject fundingMenu;
	public GameObject employeeSalMenu;


	/*===================== UI Elements =====================================================================================*/

	// Buttons

	public Button maintenanceButton;
	public Button fundingButton;
	public Button employeeSalButton;

	// Text

	public Text headingText;


	/*===================== Methods =====================================================================================*/

	/*===================== maintenanceButtonControl() =====================================================================================*/

	// Fires when maintenanceButton is Clicked
	public void maintenanceButtonControl(){

		// Turn off other menus
		fundingMenu.SetActive (false);
		employeeSalMenu.SetActive (false);

		// Update Heading Text
		headingText.text = "Building Maintenance";

		// Turn on Menu
		maintenanceMenu.SetActive (true);

		// Disable button to show it was selected
		maintenanceButton.interactable = false;

		// Activate other menu buttons
		fundingButton.interactable = true;
		employeeSalButton.interactable = true;

	} // maintenanceControl()


	/*===================== fundingButtonControl() =====================================================================================*/

	// Fires when fundingButton is Clicked
	public void fundingButtonControl(){
		
		// Turn off other menus
		maintenanceMenu.SetActive (false);
		employeeSalMenu.SetActive (false);
		
		// Update Heading Text
		headingText.text = "Funding";
		
		// Turn on Menu
		fundingMenu.SetActive (true);
		
		// Disable button to show it was selected
		fundingButton.interactable = false;
		
		// Activate other menu buttons
		maintenanceButton.interactable = true;
		employeeSalButton.interactable = true;

	} // fundingButtonControl()


	/*===================== employeeSalaryButtonControl() =====================================================================================*/

	// Fires when employeeSalButton is Clicked
	public void employeeSalaryButtonControl(){
		
		// Turn off other menus
		maintenanceMenu.SetActive (false);
		fundingMenu.SetActive (false);
		
		// Update Heading Text
		headingText.text = "Employee Salary";
		
		// Turn on Menu
		employeeSalMenu.SetActive (true);
		
		// Disable button to show it was selected
		employeeSalButton.interactable = false;
		
		// Activate other menu buttons
		maintenanceButton.interactable = true;
		fundingButton.interactable = true;

	} // employeeSalaryButtonControl()


} // class
