using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;

    [SerializeField] int currentBalance;
    public int CurrentBalance  {get {return currentBalance; } } // can access this from outside but cant set it.

    [SerializeField] TextMeshProUGUI displayBalance;

    void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }
    public void Deposit(int amount) 
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdrawal(int amount) // Guard statement
    {
        currentBalance -= Mathf.Abs(amount); // Mathf.Abs stops negative numbers from tricking the system
        // and taking(stealing) the money(like an enemy win) from you instead of just withdrawing. Now the deduction will only be
        // withdrawing and enter the equation as a positive 10 being.
        UpdateDisplay();
        if (currentBalance < 0)
        {
            //Lose the game;
            ReloadScene();
        }
    }
    void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }
    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
