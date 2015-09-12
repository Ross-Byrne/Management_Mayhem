using UnityEngine;
using System.Collections;

// Script that handles the generation of products the business can produce.

public class GenerateProducts : MonoBehaviour {

    /*===================== Variables =====================================================================================*/

    public Product[] products;
    public int numOfProducts;
    public string[] names = {"Micro Chips", "Circuit Boards", "Memory Modules", "Hard Drives", "Optical Drives", "Video Cards" };
    public int[] resourceCost = { 2, 3, 6, 7, 9, 12 };
    public int[] powerUsage = { 5, 5, 5, 5, 5, 10};
    public float[] profit = { 4f, 5.50f, 7f, 9f, 12f, 15f };

    /*===================== Methods =====================================================================================*/

    /*===================== Awake() =====================================================================================*/

    void Awake() {

        // set default number
        numOfProducts = 0;

        // get the number of products, based on number of names
        numOfProducts = names.Length;

        // initialise array of products
        products = new Product[numOfProducts];
    
    } // Awake()


    /*===================== SetUpProducts() =====================================================================================*/

    // sets up the product values
    public void SetUpProducts() {

        // if there aren't enough values to populate products
        if(resourceCost.Length != numOfProducts ||
            powerUsage.Length != numOfProducts ||
            profit.Length != numOfProducts) {

            // exit 
            return;

        } // if

        // populate product values
        for(int i = 0; i < numOfProducts; i++) {



        } // for

    } // SetUpProducts()


} // class
