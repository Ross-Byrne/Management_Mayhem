using UnityEngine;
using System.Collections;

// Controls the time and date of the game

public class TimeDateManager : MonoBehaviour {

	/*===================== DaysInMonth() =====================================================================================*/

	// gets the year and month and returns the max number of
	// days that can be in that month
	int DaysInMonth(int month, int year){

		int[] days = { 31, 0, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
		
		// if leap year, febuary has 29 instead of 28 days
		days[1] = ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) ? 29 : 28;
		
		return days[month - 1];
	} // DaysInMonth()


	/*===================== ValidateDate() =====================================================================================*/

	// checks to make sure that the date is valid
	// if it is possible to have the number of days
	// stated in the month of the year given
	// then date is valid and returns true
	public bool ValidateDate(int day, int month, int year){

		// Validates the date
		if (day >= 1 && day <= DaysInMonth(month, year)){
			return true;
		} // if
		
		return false;
	} // ValidateDate()

} // class
