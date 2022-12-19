using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public string lastPlayerName;
    public string[,] bestScoreList = new string[10, 2] { { "lost", "100" }, { "int", "15" }, { "lost", "10" }, { "lost", "10" }, { "lost", "10" }
    , { "lost", "10" }, { "lost", "10" }, { "lost", "8" }, { "lost", "5" }, { "lost", "1" }};
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    public void PutScoreToBestList(string name, int score)
    {
        int newStrokeForScore = 0;

        if (int.Parse(bestScoreList[9, 1]) >= score) 
        {
            return;
        }

        for (int i = 0; i < 10 && newStrokeForScore == 0; i++)
        {
            if (int.Parse(bestScoreList[i, 1]) < score)
            {
                newStrokeForScore = i;
                
            }
        }

        for (int l = 9; l > newStrokeForScore; l--)
        {
            bestScoreList[l, 0] = bestScoreList[l - 1, 0];
            bestScoreList[l, 1] = bestScoreList[l - 1, 1];
        }

        bestScoreList[newStrokeForScore, 0] = name;
        bestScoreList[newStrokeForScore, 1] = "" + score;

    }

    [System.Serializable]

    class SaveData
    {
        public string lastPlayerName;
        public string[,] bestScoreList;
    }

}
