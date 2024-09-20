using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager Instance;
    [SerializeField] public string playerName = "";
    [SerializeField] public string highScoreName = "";
    [SerializeField] public int highScore = 0;

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string highScoreName;
        public int highScore;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScoreName = highScoreName;
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            highScoreName = data.highScoreName;
            highScore = data.highScore;
        }
    }
}
