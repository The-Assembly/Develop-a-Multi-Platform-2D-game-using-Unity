using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KillPlayer : MonoBehaviour {

	public Sprite deadSprite;
	private SpriteRenderer sr;
	private LevelManager lm;
	private PlayerController player;



	void Start ()
	{
		sr = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
		lm = FindObjectOfType<LevelManager>();
		player = FindObjectOfType<PlayerController>();


	}

	void OnCollisionEnter2D (Collision2D other)
	{	
		if(other.gameObject.tag == "Player")
		{
			if(lm.respawnSlider.value == lm.respawnSlider.maxValue){
				lm.respawnPlayer();
				lm.respawnSlider.value = lm.respawnSlider.minValue;
			} else {
				print ("Dead");
				player.playSound(3);
				sr.sprite = deadSprite;
				Time.timeScale = 0.03f;
				//Application.LoadLevel(Application.loadedLevel);
				lm.GameOverScreen();
				player.gameIsOver = true;


			}
		}
	}
}
