using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour

{
    public Text PlayerNameInput;
    public Text HighScoreMenuText;
    public void PlayerNameSelected(string playerName)
    {
        // add code here to handle when a color is selected
        SaveManager.Instance.currentPlayer = playerName;
    }

    private void Awake()
    {
        SaveManager.Instance.LoadHighScore();
        HighScoreMenuText.text = "Best Score : " + SaveManager.Instance.SavedData.PlayerName + " : " + SaveManager.Instance.SavedData.highScore;
        //Debug.Log(SaveManager.Instance.SavedData.PlayerName);
        //Debug.Log(SaveManager.Instance.SavedData.highScore);
    }


    public void StartNew()
    {
        PlayerNameSelected(PlayerNameInput.text);
        SceneManager.LoadScene(1);
    }
}
