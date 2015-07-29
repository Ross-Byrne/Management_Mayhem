using UnityEngine;
using System.Collections;

public class ManagementMenuControl : MonoBehaviour {

	/*===================== Menus =====================================================================================*/

	public GameObject managementMenu;
	public GameObject manageEmployeesMenu;
	public GameObject businessUpgradesMenu;
	public GameObject manageOperationsMenu;
	public GameObject businessFinancesMenu;


	/*===================== Methods =====================================================================================*/

	/*===================== EmployeeMenuControl() =====================================================================================*/

	public void EmployeeMenuControl(){

		// if menu is on
		if (manageEmployeesMenu.activeSelf) {

			// turn off
			manageEmployeesMenu.SetActive (false);

			// turn off background menu
			managementMenu.SetActive (false);
		} else {	// if off, turn on

			// make sure even other menu is off
			businessUpgradesMenu.SetActive(false);
			manageOperationsMenu.SetActive(false);
			businessFinancesMenu.SetActive (false);

			// turn on background menu
			managementMenu.SetActive(true);

			// Get employee menu ready
			manageEmployeesMenu.GetComponent<EmployeeManagement>().SetUpMenu();

			// turn on menu
			manageEmployeesMenu.SetActive(true);
		} // if
	} // EmployeeMenuControl()


	/*===================== UpgradesMenuControl() =====================================================================================*/
	
	public void UpgradesMenuControl(){
		
		// if menu is on
		if (businessUpgradesMenu.activeSelf) {
			
			// turn off
			businessUpgradesMenu.SetActive (false);
			
			// turn off background menu
			managementMenu.SetActive (false);
		} else {	// if off, turn on
			
			// make sure even other menu is off
			manageEmployeesMenu.SetActive(false);
			manageOperationsMenu.SetActive(false);
			businessFinancesMenu.SetActive (false);
			
			// turn on background menu
			managementMenu.SetActive(true);
			
			// turn on menu
			businessUpgradesMenu.SetActive(true);
		} // if
	} // UpgradesMenuControl()


	/*===================== OperationsMenuControl() =====================================================================================*/
	
	public void OperationsMenuControl(){
		
		// if menu is on
		if (manageOperationsMenu.activeSelf) {
			
			// turn off
			manageOperationsMenu.SetActive (false);
			
			// turn off background menu
			managementMenu.SetActive (false);
		} else {	// if off, turn on
			
			// make sure even other menu is off
			manageEmployeesMenu.SetActive(false);
			businessUpgradesMenu.SetActive(false);
			businessFinancesMenu.SetActive (false);
			
			// turn on background menu
			managementMenu.SetActive(true);
			
			// turn on menu
			manageOperationsMenu.SetActive(true);
		} // if
	} // OperationsMenuControl()


	/*===================== FinancesMenuControl() =====================================================================================*/
	
	public void FinancesMenuControl(){
		
		// if menu is on
		if (businessFinancesMenu.activeSelf) {
			
			// turn off
			businessFinancesMenu.SetActive (false);
			
			// turn off background menu
			managementMenu.SetActive (false);
		} else {	// if off, turn on
			
			// make sure even other menu is off
			manageEmployeesMenu.SetActive(false);
			businessUpgradesMenu.SetActive(false);
			manageOperationsMenu.SetActive(false);

			// turn on background menu
			managementMenu.SetActive(true);
			
			// turn on menu
			businessFinancesMenu.SetActive(true);
		} // if
	} // FinancesMenuControl()


} // class
