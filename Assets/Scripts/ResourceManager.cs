using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public int Wood { get; private set; } = 0;
    public int Stone { get; private set; } = 0;
    public int Food { get; private set; } = 0;
    public int Wealth { get; private set; } = 0;


    [SerializeField] TextMeshProUGUI woodText;
    [SerializeField] TextMeshProUGUI stoneText;
    [SerializeField] TextMeshProUGUI foodText;
    [SerializeField] TextMeshProUGUI wealthText;

    public void AddResource(string resourceName, int value)
    {

        switch (resourceName)
        {

            case "wood":
                Wood += value;
                woodText.text = Wood.ToString();
               
                break;

            case "stone":
                Stone += value;
                stoneText.text = Stone.ToString();
                break;

            case "food":
                Food += value;
                foodText.text = Food.ToString();
                break;

            case "wealth":
                Wealth += value;
                wealthText.text = Wealth.ToString();
                break;
        }
        
    }

    public void SubResource(string resourceName, int value)
    {
        switch (resourceName)
        {

            case "wood":
                Wood -= value;
                woodText.text = Wood.ToString();

                break;

            case "stone":
                Stone -= value;
                stoneText.text = Stone.ToString();
                break;

            case "food":
                Food -= value;
                foodText.text = Food.ToString();
                break;

            case "wealth":
                Wealth -= value;
                wealthText.text = Wealth.ToString();
                break;
        }
    }

}
