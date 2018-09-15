using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
	public Text scoreText;
	public static int score;
	public Slider respawnSlider;
	public bool playerRespawned;
	public Text HighScoreText;
	public Text gameOverScoreText;
	public GameObject GameOverCanvas;

	public Text Gameover;




	private PlayerController player;

	//Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		playerRespawned = false;
		scoreText.text = "Score : ";
		score = 0;
		respawnSlider.value = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score : " + score;
		if(score > PlayerPrefs.GetInt("HIGHSCORE_KEY")){
			PlayerPrefs.SetInt("HIGHSCORE_KEY", LevelManager.score);
		}
	}

	public void respawnPlayer() {
		Time.timeScale = 0;
		player.gameIsOver = false;
		playerRespawned = true;

	}

	public void GameOverScreen () {
		GameOverCanvas.SetActive(true);
		gameOverScoreText.text = "SCORE : " + score;
		HighScoreText.text = "HIGHSCORE : " +PlayerPrefs.GetInt("HIGHSCORE_KEY");
	
	}





}
