using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BestScore : MonoBehaviour
{
    public static BestScore Instance;

    public TextMeshProUGUI playerName;
    public string playerNameString;
    public int bestScore;
    public string player;
    

    private void Awake()
    {
     
        // don't destroy this gameobject when the scene change. 
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (playerName != null)
        {
            playerNameString = playerName.text;
        }
        
    }
    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string player;
    }
    public void SaveBestScore(int score,string player)
    {
        SaveData data = new SaveData();
        if (score > bestScore)
        {
            data.bestScore = score;
            data.player = player;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

    }
    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            player = data.player;
        }
        
    }
    public void PrintBestScore(Text bestScoreText)
    {
        LoadBestScore();
        bestScoreText.text = "Best Score : " + BestScore.Instance.player + " : " + BestScore.Instance.bestScore;

    }
}
