using UnityEngine;
using System.Collections;

public class StartNewGame : MonoBehaviour {

	// Starting a new Game
	public void NewGame(){

		// Creating A Character
		//CreateCharacter(player, business, gameManager, menuManager);

		// Setup Business if character is created
		/*if(gameManager.getIsCharacterCreated() == true)
		{
			SetUpBusiness(player, business, gameManager, menuManager);
		} // if
		
		// If the business has been setup, Set Game Difficulty
		if(gameManager.getIsBusinessSetup() == true)
		{
			SetGameDifficulty(business, gameManager);
		} // if*/

	} // startNewGame()

	// Creates new character
	void CreateCharacter(){
		int menuChoice = 0;
		bool createStage1, createStage2;

		GameManager.gameManager.isCharacterCreated = false; // set isCharacterCreated to false
		createStage1 = createStage2 = false;
		/*
		while(menuChoice != 99)
		{
			//menuManager.printCharacterCreateMenu();
			
			// to make sure the choice entered is in the right range
			//do
			//{
			//	System.out.print("\nEnter Option Choice: ");
				
			//	while(!console.hasNextInt()) 
			//	{
			//		System.out.print("\nEnter Option Choice: ");
			//		console.next(); // to advance Scanner past input
			//	} // while
				
			//	menuChoice = console.nextInt();
			//}while(menuChoice < 1 || menuChoice > 3); // do..while
			
			switch(menuChoice)
			{
			case 1:
				//console.nextLine(); // flush the buffer
				//System.out.print("\nPlease Enter your new Character's Name: ");
				//player.setName(console.nextLine());
				//GameManager.gameManager.playerScript.name =
				
				//System.out.println("\nYour Character's Name is: "+player.getName()+".");
				
				createStage1 = true; // to show stage is completed
				break;
			case 2:
				System.out.print("\n\t\t\tChoose Five Traits For Your Character!\n");
				
				for(int i = 0; i < gameManager.getPlayerTraitsSelectionLength(); i++)
				{
					System.out.printf("\n\t\t\t%d.) %s", i+1, gameManager.getPlayerTraitsSelection(i));
					
				} // for
				System.out.println();
				
				int choice;
				String tempTrait;
				int[] choiceRecord = {0,0,0,0,0};
				
				for(int i = 0; i < 5; i++)
				{
					// to make sure the choice entered is in the right range
					do
					{
						System.out.printf("%nChoose Character Trait %d: ", i+1);
						
						while(!console.hasNextInt()) 
						{
							System.out.printf("%nChoose Character Trait %d: ", i+1);
							console.next(); // to advance Scanner past input
						} // while
						
						choice = console.nextInt();
						
						// to make sure only one of each trait is picked...
						if(choice > 0 && choice < 11)
						{
							for(int j = 0; j < 5; j++)
							{
								if(choiceRecord[j] == choice) 	// the trait picked is checked against other traits picked
								{							  	// if the triat has alreadly been picked,
									System.out.printf("'%s' has Already been Chosen, Pick a Different Trait.%n", 
									                  gameManager.getPlayerTraitsSelection(choice-1)); 
									
									choice = 99; // exit
								} // if
							} // for
						} // if
						
					}while(choice < 1 || choice > 10); // do..while
					
					// to make sure only one of each trait is picked
					// choice is put into choiceRecord
					choiceRecord[i] = choice;
					
					tempTrait = gameManager.getPlayerTraitsSelection(choice-1);
					
					if(choice < 6) // if a good trait
					{
						business.setGoodReputation(business.getGoodReputation() + 5);
					}
					else // if a bad trait
					{
						business.setBadReputation(business.getBadReputation() + 5);
					}
					
					player.setTraits(i, tempTrait);
					System.out.println("\nTrait Chosen: " + tempTrait);
				} // for
				
				createStage2 = true; // to show stage is completed
				break;
			case 3:
				menuChoice=99;
				gameManager.setIsCharacterCreated(false);
				break;
			} // switch
			
			// if the Character is fully created, break out of while loop
			// to continue on to setup the business.
			if(createStage1 == true && createStage2 == true)
			{
				gameManager.setIsCharacterCreated(true);
				menuChoice = 99;
			} // if
			
		} // while
*/
	} // CreateCharacter()

	// Sets up the business
	void SetUpBusiness(){


	} // SetUpBusiness()

	void SetGameDifficulty(){

	} // SetGameDifficulty()

} // class
