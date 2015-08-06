using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// for updating variables in employeeInfoCards

public class EmployeeInfoCard : MonoBehaviour {

	/*===================== UI Elements =====================================================================================*/

	public Image employeePicture;
	public Text employeeNameText;
	public Text employeeGenderText;
	public Text employeePositionText;


	/*===================== Variables =====================================================================================*/

	public Employee employee;
	public int employeeIndex;

} // class
