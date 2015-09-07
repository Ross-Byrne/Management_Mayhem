using UnityEngine;
using System.Collections;

// Controls the time and date of the game

// Date structure to hold the worlds date

public struct DateStruct {

	public int Year { get; set; }
	public int Month { get; set; }
	public int Day { get; set; }
	
	public string Date(){

		// Returns the world date in DD/MM/YYYY formate
		return string.Format ("{0}/{1}/{2}", Day, Month, Year);

	} // Date()

} // DateStruct

public class TimeDateManager : MonoBehaviour {

	/*===================== Variables =====================================================================================*/

	public DateStruct worldDate;


	/*===================== Methods =====================================================================================*/
	
	/*===================== SetUpWorldDate() =====================================================================================*/

	// to initialise the world date
	public void SetUpWorldDate(int day, int month, int year) {

		// set day of month
		worldDate.Day = day;

		// set month
		worldDate.Month = month;

		// set year
		worldDate.Year = year;

	} // SetUpWorldDate()


	/*===================== MoveToNextDay() =====================================================================================*/

	// to progress the date forward, day by day
	public void MoveToNextDay() {

		// if the next day of the month is a valid date 
		if (ValidateDate (worldDate.Day + 1, worldDate.Month, worldDate.Year)) {

			// increase the day of the month by One
			worldDate.Day++;

		} else { // if not a valid date

			// Set day of month back to 1
			worldDate.Day = 1;

			// if month is equal to 12
			if(worldDate.Month == 12){

				// set month back to 1
				worldDate.Month = 1;
				
				// increase year by one
				worldDate.Year++;

			} else { // if month is not equal to 12

				// increase month by One
				worldDate.Month++;

			} // if
		} // if

	} // MoveToNextDay()


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
