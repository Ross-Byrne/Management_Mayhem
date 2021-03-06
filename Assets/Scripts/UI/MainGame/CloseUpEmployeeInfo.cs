﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Class to control the CloseUpEmployeeInfo UI Elements

public class CloseUpEmployeeInfo : MonoBehaviour {

	/*===================== UI Elements =====================================================================================*/

	public Image employeePicture;
	public Text employeeNameText;
	public Text employeeGenderText;
	public Text employeePositionText;
	public Text employeeSalaryText;


	/*===================== Methods =====================================================================================*/

	/*===================== UpdateEmployeeCloseUp() =====================================================================================*/

	// selectedEmployee is the employee clicked that is being displayed on display cards
	public void UpdateEmployeeCloseUp(Employee selectedEmployee){

		// display the employees Name
		employeeNameText.text = string.Format("Name: {0}.", selectedEmployee.Name);

		// display the employees gender
		if(selectedEmployee.Gender == 'M'){

			// display gender
			employeeGenderText.text = "Gender: Male.";
		} else if(selectedEmployee.Gender == 'F'){

			// display gender
			employeeGenderText.text = "Gender: Female.";
		} // if

		// display the employees position
		employeePositionText.text = string.Format("Position: {0}.", selectedEmployee.Position);

		// display the employees salary
		employeeSalaryText.text = string.Format("Current Salary For Position: ${0} Per Hour.",selectedEmployee.Salary.ToString("F"));
		
	} // UpdateEmployeeCloseUp()
	
} // class
