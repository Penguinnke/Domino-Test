using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToggleScript : MonoBehaviour
{
    public TagSystem3 scriptWithStrings;
    public DominoColour DominoColoursOG1;
    public DominoColourZero DominoColourZero1;
    public DominoColour DominoColoursOG2;
    public DominoColourZero DominoColourZero2;
    public Button toggleButton;

    public string tag_CHANGE = "Number0";

    public string tagA_Right_OG = "_tagA_RIGHT";
    public string tagB_Left_OG = "_tagB_LEFT";
    public string tagC_Up_OG = "_tagC_UP";
    public string tagD_Down_OG = "_tagD_DOWN";

    private bool isFirstState = true;
    private bool isScriptActive = true;

    private void Start()
    {
        toggleButton.onClick.AddListener(ToggleScriptActivation);
    }

    private void ToggleScriptActivation()
    {
        if (!isScriptActive)
        {
            return; // Exit the method if the script is not active
        }

        if (isFirstState)
        {
            // Change the public strings to the first set of values
            scriptWithStrings.tagA_Right = tag_CHANGE;
            scriptWithStrings.tagB_Left = tag_CHANGE;
            scriptWithStrings.tagC_Up = tag_CHANGE;
            scriptWithStrings.tagD_Down = tag_CHANGE;

            DominoColoursOG1.enabled = false;
            DominoColourZero1.enabled = true;
            DominoColoursOG2.enabled = false;
            DominoColourZero2.enabled = true;
        }
        else
        {
            // Change the public strings to the second set of values
            scriptWithStrings.tagA_Right = tagA_Right_OG;
            scriptWithStrings.tagB_Left = tagB_Left_OG;
            scriptWithStrings.tagC_Up = tagC_Up_OG;
            scriptWithStrings.tagD_Down = tagD_Down_OG;

            DominoColoursOG1.enabled = true;
            DominoColourZero1.enabled = false;
            DominoColoursOG2.enabled = true;
            DominoColourZero2.enabled = false;
        }

        // Toggle the state
        isFirstState = !isFirstState;
    }

    public void SetScriptActive(bool isActive)
    {
        isScriptActive = isActive;
    }
}