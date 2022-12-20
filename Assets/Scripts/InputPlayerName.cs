using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[DefaultExecutionOrder(1000)]
public class InputPlayerName : MonoBehaviour
{
    private void Start()
    {
        //Set to input field text last session player's name
        gameObject.GetComponent<TMP_InputField>().text = GameManager.Instance.lastPlayerName;
    }
    // Save New Player name from input field at start menu when do any action with input field
    public void UpdatePlayerName()
    {
        var playerName = gameObject.GetComponent<TMP_InputField>().text;

        if (playerName == "")
        {
            GameManager.Instance.playerName = "noname";
        }
        else
        {
            GameManager.Instance.playerName = playerName;    

        }
    }
}
