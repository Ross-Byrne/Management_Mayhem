using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Business : MonoBehaviour 
{
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
	public List<Employee> Employees 
	{
		get{ return employees;}
		set{ employees = value;}
	}


	/*===================== Get and Set Properties =====================================================================================*/

	/*===================== get/set BuildingUpgradeCost =====================================================================================*/

	public float BuildingUpgradeCost 
	{
		get{ return BuildingSize * 1000;}
		set{ buildingUpgradeCost = value;}
	}
	
	/*===================== get/set MaxEmployees =====================================================================================*/

	public int MaxEmployees
	{
		// maximum number of employees business can have
		// is 5 employees per room
		get{ return BuildingSize * 5;}
		set{ maxEmployees = value;}
	}

	/*===================== get/set MaxDealers =====================================================================================*/

	public int MaxDealers
	{
		// maximum number of dealers a business can have
		// is 1 dealer per room
		get{ return BuildingSize;}
		set{ maxDealers = value;}
	}

	 
	/*===================== get/set TotalEmployeeSalary =====================================================================================*/

	public float TotalEmployeeSalary
	{
		// total employee salary is calculated
		// using employeeSalary * number of employees
		get{ return Employees.Count * EmployeeSalary;}
		set{ totalEmployeeSalary = value;}
	}
	
	/*===================== get/set ProductivityBonus =====================================================================================*/

	public int ProductivityBonus
	{
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

	public float EquipmentUpgradeCost
	{
		// the equipment upgrades +1 is to get the cost of next upgrade
		// not the cost of the current upgrade number
		get{return (EquipmentUpgrades + 1) * 20000;} // each upgrade costs 20000 more then the last
		set{ equipmentUpgradeCost = value;}
	}


	/*===================== Methods =====================================================================================*/

	/*===================== Awake() =====================================================================================*/

	void Awake()
	{

		// Sets up business by setting variables to default values
		SetupBusiness();
	} // Awake()


	/*===================== SetupBusiness() =====================================================================================*/

	// sets up the business to its default values
	public void SetupBusiness()
	{
		Name = "";
		BankAccount = 0f;
		Reputation = 0; // +25 because of 1000 for maintenance and -25 because salary is 800
		BuildingSize = 3;
		BuildingUpgradeCost = BuildingSize *1000;
		BuildingMaintenance = 1000; // medium maintenance level
		MaxEmployees = 0;
		EmployeeSalary = 800;
		BusinessAge = 0;
		ProductivityBonus = 0;
		EquipmentUpgrades = 0;
	} // SetupBusiness()


	/*===================== ProduceProducts() =====================================================================================*/
	
	// generates money for business
	// by producing products + selling them
	public void ProduceProducts()
	{
		float bonus = 0;
		
		MoneyEarned = employees.Count * 1000; // business makes 1000 per employee a month
		
		bonus = ((float)ProductivityBonus / 100); // getting the productivity bonus %
		
		MoneyEarned = MoneyEarned + (MoneyEarned * bonus); // Adding the productivity bonus on to money earned
		
		BankAccount += MoneyEarned; // adds money earned into bank account
	} // ProduceProducts()


	/*===================== SellDrugs() =====================================================================================*/
	
/*	public void SellDrugs(Player player)
	{
		MoneyEarned = dealers.Count * 500;
		
		BankAccount = BankAccount + (MoneyEarned / 2); // half goes to business
		player.BankAccount = player.BankAccount + (MoneyEarned / 2); // half goes to the player
	} // SellDrugs()*/


	/*===================== MakeDrugs() =====================================================================================*/
	
	public void MakeDrugs(Player player)
	{
		MoneyEarned = 5000; // drugs produced = 5,000 a month
		
		BankAccount += (MoneyEarned / 2); // half goes to business
		player.BankAccount += (MoneyEarned / 2); // half goes to the player
	} // MakeDrugs()


	/*===================== PayEmployees() =====================================================================================*/
	
	// pays employees for the month
	public void PayEmployees()
	{
		if(TotalEmployeeSalary > BankAccount)
		{
			// flag business as not able to pay salary without going into debt
			return;
		}
		// takes the total salary out of the business bank account
		BankAccount -= TotalEmployeeSalary;
	} // PayEmployees()


	/*===================== payEmployeesAnyway() =====================================================================================*/
	
	public void PayEmployeesAnyway()
	{
		// takes the total salary out of the business bank account
		// Even when the business is in debt
		BankAccount -= TotalEmployeeSalary;
	} // PayEmployeesAnyway()

} // class