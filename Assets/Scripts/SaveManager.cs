using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public SaveData SavedData = new SaveData();
    public string currentPlayer;

    //public Text PlayerName;
    //public int highScore;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveHighScore()
    {
        string json = JsonUtility.ToJson(SavedData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(json + "merhaba");
        Debug.Log(Application.persistentDataPath);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            SavedData.PlayerName = data.PlayerName;
            SavedData.highScore = data.highScore;
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public string PlayerName;
        public int highScore;
    }
}
