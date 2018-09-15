using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
	public Text scoreText;
	public static int score;
    public GameObject gameOverCanvas;
    public bool gameIsOver;

    private PlayerController player;

	//Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		scoreText.text = "Score : ";
		score = 0;
        if (gameOverCanvas != null) {
            gameOverCanvas.SetActive(false);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score : " + score;
        if(gameIsOver) {
            gameOverCanvas.SetActive(true);
        }
	}

    public void StartAgain () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
