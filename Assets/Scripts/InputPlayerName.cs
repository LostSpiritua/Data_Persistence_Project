using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputPlayerName : MonoBehaviour
{
    
    public void UpdatePlayerName()
    {
        GameManager.Instance.playerName = gameObject.GetComponent<TMP_InputField>().text;    
    }
}
