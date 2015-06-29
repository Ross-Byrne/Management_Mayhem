using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Business : MonoBehaviour {
	
	/*===================== Variables =====================================================================================*/

	public string Name { get; set;}
	public float BankAccount { get; set;}
	public int Reputation { get; set;}
	public int BuildingSize { get; set;} // no. of rooms
	private float buildingUpgradeCost;
	public float BuildingMaintenance { get; set;}
	private int maxEmployees;
	private int maxDealers;
	public float EmployeeSalary { get; set;} // Per Month
	private float totalEmployeeSalary; // total salary paid to all employees
	public int BusinessAge { get; set;} // in months
	private int productivityBonus;
	public int EquipmentUpgrades { get; set;} // + 10% productivity bonus per upgrade
	private float equipmentUpgradeCost;
	public float MoneyEarned { get; set;}

	
	/*===================== List of Employee GameObjects =====================================================================================*/

	private List<Employee> employees = new List<Employee> ();
	public List<Employee> Employees {
		get{ return employees;}
		set{ employees = value;}
	}


	/*===================== Get and Set Properties =====================================================================================*/

	/*===================== get/set BuildingUpgradeCost =====================================================================================*/

	public float BuildingUpgradeCost {
		get{ return BuildingSize * 1000;}
		set{ buildingUpgradeCost = value;}
	}
	
	/*===================== get/set MaxEmployees =====================================================================================*/

	public int MaxEmployees{
		// maximum number of employees business can have
		// is 5 employees per room
		get{ return BuildingSize * 5;}
		set{ maxEmployees = value;}
	}

	/*===================== get/set MaxDealers =====================================================================================*/

	public int MaxDealers{
		// maximum number of dealers a business can have
		// is 1 dealer per room
		get{ return BuildingSize;}
		set{ maxDealers = value;}
	}

	 
	/*===================== get/set TotalEmployeeSalary =====================================================================================*/

	public float TotalEmployeeSalary{
		// total employee salary is calculated
		// using employeeSalary * number of employees
		get{ return Employees.Count * EmployeeSalary;}
		set{ totalEmployeeSalary = value;}
	}
	
	/*===================== get/set ProductivityBonus =====================================================================================*/

	public int ProductivityBonus{
		get{
			int bonus = 0;

			// adds 1% + or - bonus for each 5 rep, per employee
			bonus += employees.Count * (Reputation / 5); 

			// Adds 10% bonus for each equipment upgrade
			bonus += (EquipmentUpgrades * 10); 
			
			return bonus;
		}
		set{ productivityBonus = value;}
	}
	
	/*===================== get/set EquipmentUpgradeCost =====================================================================================*/

	public float EquipmentUpgradeCost{
		// the equipment upgrades +1 is to get the cost of next upgrade
		// not the cost of the current upgrade number
		get{return (EquipmentUpgrades + 1) * 20000;} // each upgrade costs 20000 more then the last
		set{ equipmentUpgradeCost = value;}
	}


	/*===================== Methods =====================================================================================*/

	// sets up the business to its default values
	public void SetupBusiness(){


	} // SetupBusiness()



} // class