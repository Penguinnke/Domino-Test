using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyPad : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Ans;
    public string Answer = "123456789";
    private bool isCodeCorrect = false;
    private bool isCodeIncorrect = false;

    public void Number(int number)
    {
        if (isCodeCorrect || isCodeIncorrect)
        {
            return;
        }

        Ans.text += number.ToString();
    }

    public void Execute()
    {
        if (isCodeCorrect || isCodeIncorrect)
        {
            return;
        }

        if (Ans.text == Answer)
        {
            Ans.text = "CORRECT";
            isCodeCorrect = true;
        }
        else
        {
            Ans.text = "INCORRECT";
            isCodeIncorrect = true;
            StartCoroutine(ResetCodeAfterDelay(2f)); 
        }
    }

    private IEnumerator ResetCodeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Ans.text = "";
        isCodeCorrect = false;
        isCodeIncorrect = false;
    }
}
