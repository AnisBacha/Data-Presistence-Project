using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MenuUIHandler : MonoBehaviour
{
    public Text bestScore;
    public TextMeshProUGUI playerName;
    public int HighestScore;
    private void Start()
    {
        BestScore.Instance.PrintBestScore(bestScore);
    }
    public void StartNew()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Update()
    {
        
    }
    

}
