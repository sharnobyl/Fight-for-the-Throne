using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreSystem : MonoBehaviour
{
    public Text highscoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerCombat.playerScore > PlayerPrefs.GetInt("highScore", 0)) {
            PlayerPrefs.SetInt("highScore", PlayerCombat.playerScore);
        }
        highscoreText.text = PlayerPrefs.GetInt("highScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //if(PlayerCombat.playerScore > PlayerPrefs.GetInt("highScore", 0)) {
        //PlayerPrefs.SetInt("highScore", PlayerCombat.playerScore);
        //}
        //highscoreText.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        //scoreText.text = player.GetComponent<PlayerCombat>().playerScore.ToString();
        //scoreText.text = PlayerCombat.playerScore.ToString();
    }
    public void Reset()
    {
        PlayerPrefs.DeleteKey("highScore");
        highscoreText.text = "0";
        highscoreText.text = PlayerPrefs.GetInt("highScore", 0).ToString();
    }
}
