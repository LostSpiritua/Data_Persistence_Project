using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public string lastPlayerName;
    // template for best players list
    public string[,] bestScoreList = new string[10, 2] { { "Name", "0" }, { "Name", "0" }, { "Name", "0" }, {"Name", "0"}, {"Name", "0"}
    , {"Name", "0"}, {"Name", "0"}, {"Name", "0"}, {"Name", "0"}, {"Name", "0"}};
    // Start is called before the first frame update
    void Start()
    {
        //Check for existing of GameManager in scene
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadDataFromFile();
        
    }

    // Put scores and player's name to bestscore list, if new scores better than existing. List may save 10 best scores and names
    public void PutScoreToBestList(string name, int score)
    {
        int newStrokeForScore = 10;

        // Check new scores > if that worse than any in list > stop method
        if (int.Parse(bestScoreList[9, 1]) >= score)
        {
            return;
        }

        // Check where put new score in list
        for (int i = 0; i < 10 && newStrokeForScore == 10; i++)
        {
            if (int.Parse(bestScoreList[i, 1]) < score)
            {
                newStrokeForScore = i;

            }
        }

        //All old scores worse than new put down -1 stroke
        for (int l = 9; l > newStrokeForScore; l--)
        {
            bestScoreList[l, 0] = bestScoreList[l - 1, 0];
            bestScoreList[l, 1] = bestScoreList[l - 1, 1];
        }

        //Write new scores at list
        bestScoreList[newStrokeForScore, 0] = name;
        bestScoreList[newStrokeForScore, 1] = "" + score;

    }

    //Get name and score of best player from ScoreList
    public string GetBestPlayer()
    {
        string best = bestScoreList[0, 0] + " : " + bestScoreList[0, 1];
        Debug.Log(best);
        return best;
    }

    [System.Serializable]

    //Specific class of game data for saving in json file
    class SaveData
    {
        public string lastPlayerName;
        public string[] bestScoreName;
        public string[] bestScore;
    }

    //Saving game data to file
    public void SaveDataToFile()
    {
        SaveData data = new SaveData();
        data.lastPlayerName = lastPlayerName;
        data.bestScore = ConvertMultiArrayToSimple(bestScoreList, 1);
        data.bestScoreName = ConvertMultiArrayToSimple(bestScoreList, 0);

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    //Load game data from file
    public void LoadDataFromFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            lastPlayerName = data.lastPlayerName;
            bestScoreList = ConvertSimpleArrayToMulti(data.bestScoreName, data.bestScore);
        }
    }

    //Convert nonserialize multiarray to serialize standart array
    private string[] ConvertMultiArrayToSimple(string[,] marray, int index)
    {
        string[] simpleArray = new string[10];

        for (int i = 0; i < 10; i++)
        {
            simpleArray[i] = marray[i, index];
        }
        return simpleArray;
    }

    //Convert 2 serilalize standart array to one multiarray
    private string[,] ConvertSimpleArrayToMulti(string[] s1, string[] s2)
    {
        string[,] multiArray = new string[10,2];
        
        for (int i = 0; i < 10; i++)
        {
            multiArray[i, 0] = s1[i];
            multiArray[i, 1] = s2[i];
        }
        return multiArray;
    }
}
