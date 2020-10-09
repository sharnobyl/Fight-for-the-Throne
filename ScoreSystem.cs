using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    private GameObject player;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (SceneManager.GetActiveScene().name == "GameScene") {
        PlayerCombat.playerScore = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = player.GetComponent<PlayerCombat>().playerScore.ToString();
        scoreText.text = PlayerCombat.playerScore.ToString();
    }
}
