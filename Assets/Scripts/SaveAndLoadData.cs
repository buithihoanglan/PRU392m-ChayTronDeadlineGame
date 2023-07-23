using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveAndLoadData : MonoBehaviour
{
    [Serializable]
    public class Data
    {
        public int HighestScore;
    }

    public void saveData()
    {
        //get data
        Data data = new Data();

        data.HighestScore = ScoreController.score;

        //save
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void loadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            if (json.Length != 2)
            {
                Data data = JsonUtility.FromJson<Data>(json);

                ScoreController.highestScore = data.HighestScore;
            }
        }
    }

    private void OnApplicationQuit()
    {
        saveData();
    }

    private void Awake()
    {
        loadData();
    }
}
