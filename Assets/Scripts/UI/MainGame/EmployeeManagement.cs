using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class EmployeeManagement : MonoBehaviour {
 
	/*===================== UI Elements =====================================================================================*/

	// Text

	public Text employeeInfoText;
	public Text dealerInfoText;
	public Text listOfEmployeesText;
	
	// Buttons

	public Button currentEmplyButton;
	public Button newAppsButton;
	public Button nextButton;
	public Button backButton;


	/*===================== GameObjects =====================================================================================*/

	// GameObjects in ListOfEmployees

	public GameObject employeeInfoCard1;
	public GameObject employeeInfoCard2;
	public GameObject employeeInfoCard3;
	public GameObject employeeInfoCard4;
	public GameObject employeeInfoCard5;

	// GameObjects in CloseUpEmployeeInfo

	public GameObject employeeInfo;
	public GameObject hireFireButton;


	/*===================== Variables =====================================================================================*/

	// to keep track of the current index when moving between pages
	private int currentEmployeeIndex = 0;

	// keeps track of num of employees on current page
	private int numOfEmployeesOnPage = 0;


	/*===================== Methods =====================================================================================*/

	/*===================== SetUpMenu() =====================================================================================*/

	// Sets up the Employee Management Menu when it is opened
	public void SetUpMenu(){

		// Show how many employees you have
		UpdateEmployeeCountText ();

		// Select Current Employees as default selected button
		CurrentEmployeesControl ();

	} // SetUpMenu()


	/*===================== CurrentEmployeesControl() =====================================================================================*/

	// Fires when currentEmployees button is pressed
	public void CurrentEmployeesControl(){

		// reset value
		currentEmployeeIndex = 0;
		numOfEmployeesOnPage = 0;

		// Change ListOfEmployees Text to Say Current Employees
		listOfEmployeesText.text = "Current Employees";

		// Display the list of hired employees
		DisplayListOfEmployees ();

		// Make current employees button non interactible because it's selected
		currentEmplyButton.interactable = false;

		// Make new applications selectable
		newAppsButton.interactable = true;

	} // CurrentEmployeesControl()


	/*===================== NewApplicationsControl() =====================================================================================*/
	
	// Fires when currentEmployees button is pressed
	public void NewApplicationsControl(){

		// reset value
		currentEmployeeIndex = 0;
		numOfEmployeesOnPage = 0;

		// Change ListOfEmployees Text to Say New Applications
		listOfEmployeesText.text = "New Applications";

		// Display the list of new applications
		DisplayListOfNewApps ();

		// Make new applications button non interactible because it's selected
		newAppsButton.interactable = false;
		
		// Make current employees selectable
		currentEmplyButton.interactable = true;

	} // NewApplicationsControl()


	/*===================== NextButtonControl() =====================================================================================*/

	// fires when nextButton is clicked, goes forward a page of employees
	public void NextButtonControl(){

		// display next page of employees
		DisplayListOfEmployees ();

	} // NextButtonControl()


	/*===================== BackButtonControl() =====================================================================================*/

	// fires when backButton is clicked, goes back a page of employees
	public void BackButtonControl(){

		// going back so reduce currentEmployeeIndex by amount on current page + one full page
		// So you can clear the page your on, and the previous page, so the code will reprint the last page
		currentEmployeeIndex -= numOfEmployeesOnPage + 5;

		// display next page of employees
		DisplayListOfEmployees ();
		
	} // BackButtonControl()


	/*===================== DisplayListOfEmployees() =====================================================================================*/

	// Displays the list of hired employees
	void DisplayListOfEmployees(){

		// reset some values
		int numOfEmployees = 0;
		numOfEmployeesOnPage = 0;

		// Turn off all Info cards
		employeeInfoCard1.SetActive (false);
		employeeInfoCard2.SetActive (false);
		employeeInfoCard3.SetActive (false);
		employeeInfoCard4.SetActive (false);
		employeeInfoCard5.SetActive (false);

		// Get the number of employees currently hired
		numOfEmployees = GameManager.businessScript.Employees.Count;

		// if enough employees for more then one page and current index is not 0 (Not on first page)
		if (numOfEmployees >= 5 && currentEmployeeIndex != 0) {

			// if less then five, fill as many cards that are needed
			if((numOfEmployees-1) - currentEmployeeIndex < 5){
				int temp = 0;

				// save currentEmployeeIndex
				temp = currentEmployeeIndex;

				// fill the info cards
				for(int i = 0; i < (numOfEmployees-1) - temp; i++){

					// Save current employee index
					currentEmployeeIndex++;

					// update info cards
					UpdateEmployeeInfoCard(i+1, currentEmployeeIndex, GameManager.businessScript.Employees[currentEmployeeIndex].GetComponent<Employee>());

					// save num of employees on page
					numOfEmployeesOnPage++;
				} // for
			} // if
			
			// if there are five or more, just fill another five cards
			if((numOfEmployees-1) - currentEmployeeIndex >= 5){
				int temp = 0;

				temp = currentEmployeeIndex;
				// fill all 5 info cards
				for(int i = 0; i < 5; i++){
					
					// Save current employee index
					currentEmployeeIndex++;
					
					// update info cards
					UpdateEmployeeInfoCard(i+1, currentEmployeeIndex, GameManager.businessScript.Employees[currentEmployeeIndex].GetComponent<Employee>());
				} // for

				// save num of employees on page
				numOfEmployeesOnPage = 5;
			} // if
			
		} // if

		// if there is more then 5 employees and are going through first 5
		if (numOfEmployees >= 5 && currentEmployeeIndex == 0) {

			// fill all 5 info cards
			for(int i = 0; i < 5; i++){

				// update info cards
				UpdateEmployeeInfoCard(i+1, i, GameManager.businessScript.Employees[i].GetComponent<Employee>());

				// Save current employee index
				currentEmployeeIndex = i;
			} // for

			// save num of employees on page
			numOfEmployeesOnPage = 5;

		} // if

		// if there is less then five in total
		if (numOfEmployees < 5) {

			// fill the info cards
			for(int i = 0; i < numOfEmployees; i++){

				// update info cards
				UpdateEmployeeInfoCard(i+1, i, GameManager.businessScript.Employees[i].GetComponent<Employee>());

				// Save current employee index
				currentEmployeeIndex = i;
			} // for
		
			// save num of employees on page
			numOfEmployeesOnPage = currentEmployeeIndex+1;
		} // if

		// to see user can go back for forward a page
		if(numOfEmployees-1 > currentEmployeeIndex){
			
			// if number of employees is greater then last printed employee, can go next page
			nextButton.interactable = true;
		} else {
			
			// otherwise cant
			nextButton.interactable = false;
		} // if
		
		if(currentEmployeeIndex > 4){

			// if the index of last printed employee is > 5, means can go back a page
			backButton.interactable = true;
		} else {
			
			// otherwise cant go back
			backButton.interactable = false;
		} // if

	} // DisplayListOfEmployees()


	/*===================== DisplayListOfNewApps() =====================================================================================*/
	
	// Displays the list of new applications
	void DisplayListOfNewApps(){

		// Turn off all Info cards
		employeeInfoCard1.SetActive (false);
		employeeInfoCard2.SetActive (false);
		employeeInfoCard3.SetActive (false);
		employeeInfoCard4.SetActive (false);
		employeeInfoCard5.SetActive (false);
		
	} // DisplayListOfNewApps()


	/*===================== UpdateEmployeeInfoCard() =====================================================================================*/

	// takes number 1-5, the index the employee is at and updates that card will given employee details 
	void UpdateEmployeeInfoCard(int number, int employeeIndex, Employee employee){

		string gender = " ";

		switch (number) {
		case 1:
			employeeInfoCard1.GetComponent<EmployeeInfoCard>().employee = employee;
			employeeInfoCard1.GetComponent<EmployeeInfoCard>().employeeIndex = employeeIndex;
			employeeInfoCard1.GetComponent<EmployeeInfoCard>().employeeNameText.text = employee.Name;

			if(employee.Gender == 'M'){
				gender = "Male";
			} else if(employee.Gender == 'F') {
				gender = "Female";
			} // if

			employeeInfoCard1.GetComponent<EmployeeInfoCard>().employeeGenderText.text = gender;
			employeeInfoCard1.GetComponent<EmployeeInfoCard>().employeePositionText.text = employee.Position;

			// Activate info card
			employeeInfoCard1.SetActive(true);
			break;
		case 2: 
			employeeInfoCard2.GetComponent<EmployeeInfoCard>().employee = employee;
			employeeInfoCard2.GetComponent<EmployeeInfoCard>().employeeIndex = employeeIndex;
			employeeInfoCard2.GetComponent<EmployeeInfoCard>().employeeNameText.text = employee.Name;
			
			if(employee.Gender == 'M'){
				gender = "Male";
			} else if(employee.Gender == 'F'){
				gender = "Female";
			} // if
			
			employeeInfoCard2.GetComponent<EmployeeInfoCard>().employeeGenderText.text = gender;
			employeeInfoCard2.GetComponent<EmployeeInfoCard>().employeePositionText.text = employee.Position;

			// Activate info card
			employeeInfoCard2.SetActive(true);
			break;
		case 3:
			employeeInfoCard3.GetComponent<EmployeeInfoCard>().employee = employee;
			employeeInfoCard3.GetComponent<EmployeeInfoCard>().employeeIndex = employeeIndex;
			employeeInfoCard3.GetComponent<EmployeeInfoCard>().employeeNameText.text = employee.Name;
			
			if(employee.Gender == 'M'){
				gender = "Male";
			} else if(employee.Gender == 'F'){
				gender = "Female";
			} // if
			
			employeeInfoCard3.GetComponent<EmployeeInfoCard>().employeeGenderText.text = gender;
			employeeInfoCard3.GetComponent<EmployeeInfoCard>().employeePositionText.text = employee.Position;

			// Activate info card
			employeeInfoCard3.SetActive(true);
			break;
		case 4:
			employeeInfoCard4.GetComponent<EmployeeInfoCard>().employee = employee;
			employeeInfoCard4.GetComponent<EmployeeInfoCard>().employeeIndex = employeeIndex;
			employeeInfoCard4.GetComponent<EmployeeInfoCard>().employeeNameText.text = employee.Name;
			
			if(employee.Gender == 'M'){
				gender = "Male";
			} else if(employee.Gender == 'F') {
				gender = "Female";
			} // if
			
			employeeInfoCard4.GetComponent<EmployeeInfoCard>().employeeGenderText.text = gender;
			employeeInfoCard4.GetComponent<EmployeeInfoCard>().employeePositionText.text = employee.Position;

			// Activate info card
			employeeInfoCard4.SetActive(true);
			break;
		case 5:
			employeeInfoCard5.GetComponent<EmployeeInfoCard>().employee = employee;
			employeeInfoCard5.GetComponent<EmployeeInfoCard>().employeeIndex = employeeIndex;
			employeeInfoCard5.GetComponent<EmployeeInfoCard>().employeeNameText.text = employee.Name;
			
			if(employee.Gender == 'M'){
				gender = "Male";
			} else if(employee.Gender == 'F') {
				gender = "Female";
			} // if
			
			employeeInfoCard5.GetComponent<EmployeeInfoCard>().employeeGenderText.text = gender;
			employeeInfoCard5.GetComponent<EmployeeInfoCard>().employeePositionText.text = employee.Position;

			// Activate info card
			employeeInfoCard5.SetActive(true);
			break;
		} // switch

	} // UpdateEmployeeInfoCard()


	/*===================== UpdateEmployeeCountText() =====================================================================================*/

	void UpdateEmployeeCountText(){

		StringBuilder str = new StringBuilder ();

		int employeeCount = 0;
		int maxEmployees = 0;
		int dealerCount = 0;
		int maxDealers = 0;

		employeeCount = GameManager.businessScript.Employees.Count;
		maxEmployees = GameManager.businessScript.MaxEmployees;


		employeeInfoText.text = str.Append ("You have ").Append (employeeCount).Append (" out of the ").Append (
			maxEmployees).Append (" Employees you can hire.").ToString ();

		// clear string
		str.Length = 0;

	} // UpdateEmployeeCountText()


	/*===================== EmployeeSelected() =====================================================================================*/

	// Fires when an employee infocard is selected
	public void EmployeeSelected(GameObject employeeSelected){

		// update close up employee info
		employeeInfo.GetComponent<CloseUpEmployeeInfo> ().UpdateEmployeeCloseUp (employeeSelected.GetComponent<EmployeeInfoCard>().employee);

		// activate employeeInfo
		employeeInfo.SetActive (true);

		// active hire/fireButton
		hireFireButton.SetActive (true);

		// update hire/firebutton
		hireFireButton.GetComponentInChildren<Text> ().text = "Fire";

	} // EmployeeSelected()

} // class
