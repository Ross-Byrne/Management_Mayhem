using UnityEngine;
using System.Collections;

// Script that handles the generation of products the business can produce.

public class GenerateProducts : MonoBehaviour {

    /*===================== Variables =====================================================================================*/

    public int numOfProducts;
    public string[] names = {"Micro Chips", "Circuit Boards", "Memory Modules", "Hard Drives", "Optical Drives", "Video Cards" };
    public int[] resourceCost = { 2, 3, 6, 7, 9, 12 };
    public int[] powerUsage = { 5, 5, 5, 5, 5, 10};
    public float[] profit = { 4f, 5.50f, 7f, 9f, 12f, 15f };

    // the cost of each resource unit
    public float costOfResourceUnits = 5f;

    /*===================== Methods =====================================================================================*/

    /*===================== GetNumberOfProducts() =====================================================================================*/

    public int GetNumberOfProducts() {

        numOfProducts = 0;

        // get the number of products, based on number of names
        numOfProducts = names.Length;

        // return number of products
        return numOfProducts;

    } // GetNumberOfProducts()


    /*===================== SetUpProducts() =====================================================================================*/

    // sets up the product values
    public void SetUpProducts(Product[] products) {

        // if there aren't enough values to populate products
        if(resourceCost.Length != numOfProducts ||
            powerUsage.Length != numOfProducts ||
            profit.Length != numOfProducts) {

            // exit 
            return;

        } // if

        // populate product values
        for(int i = 0; i < numOfProducts; i++) {

            // give products their number
            products[i].Number = i + 1;
            
            // give products their names
            products[i].Name = names[i];

            // give products thier resource cost
            products[i].ResourceCost = resourceCost[i];

            // give products their power usage
            products[i].PowerUsage = powerUsage[i];

            // calculate products market value
            products[i].MarketValue = ((resourceCost[i] * costOfResourceUnits) + profit[i]);

        } // for

    } // SetUpProducts()


} // class
