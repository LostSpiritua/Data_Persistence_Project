using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestPlayerList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // visualize new game list frome bestplayers data
        gameObject.GetComponent<TMP_Text>().text = "1. " + GameManager.Instance.bestScoreList[0,0] + " - - - " + GameManager.Instance.bestScoreList[0, 1];

        for (int i = 1; i < 10; i++)
        {
            gameObject.GetComponent<TMP_Text>().text += "\n" + (i+1) + ". " + GameManager.Instance.bestScoreList[i, 0] + " - - - " + GameManager.Instance.bestScoreList[i, 1];
        }
    }
 }
