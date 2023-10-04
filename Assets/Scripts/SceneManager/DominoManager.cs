using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoManager : MonoBehaviour
{
    private const string DominoName = "Domino's";
    private const string ChosenDominoKey = "ChosenDominoName";

    void Start()
    {
        string chosenDominoName = PlayerPrefs.GetString(ChosenDominoKey);

        if (string.IsNullOrEmpty(chosenDominoName))
        {
            // This is the first time the scene is loaded.
            // Find all GameObjects with the name "Domino's" in the scene.
            GameObject[] dominos = GameObject.FindGameObjectsWithTag(DominoName);

            if (dominos.Length > 0)
            {
                // Choose the first "Domino's" GameObject found.
                chosenDominoName = dominos[0].name;

                // Save the chosen "Domino's" name in PlayerPrefs.
                PlayerPrefs.SetString(ChosenDominoKey, chosenDominoName);
            }
        }

        // Loop through all GameObjects with the name "Domino's" in the scene.
        GameObject[] allDominos = GameObject.FindGameObjectsWithTag(DominoName);

        foreach (GameObject domino in allDominos)
        {
            // Check if the GameObject's name matches the chosen one.
            if (domino.name == chosenDominoName)
            {
                // Ensure that the chosen "Domino's" GameObject is not destroyed when reloading the scene.
                DontDestroyOnLoad(domino);
            }
            else
            {
                // Destroy any other instances of "Domino's."
                Destroy(domino);
            }
        }
    }
}