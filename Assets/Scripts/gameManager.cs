using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public string bestScoreName = "name";
    public int bestScore = 0;

    public string userName;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    [System.Serializable]
    class saveData
    {
        public string bestScoreName;
        public int bestScore;
    }

    public void SaveTheData()
    {
        saveData data = new saveData();
        data.bestScoreName = bestScoreName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void loadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            saveData data = JsonUtility.FromJson<saveData>(json);

            bestScoreName = data.bestScoreName;
            bestScore = data.bestScore;
        }
    }
}
