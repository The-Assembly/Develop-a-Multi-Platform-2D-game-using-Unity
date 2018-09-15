using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KillPlayer : MonoBehaviour {

	public Sprite deadSprite;
	private SpriteRenderer sr;
	private LevelManager lm;
	private PlayerController player;

	void Awake ()
	{
		sr = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
		lm = FindObjectOfType<LevelManager>();
		player = FindObjectOfType<PlayerController>();
    }

	void OnCollisionEnter2D (Collision2D other)
	{	
		if(other.gameObject.tag == "Player")
		{
			print ("Dead");
			player.playSound(2);
            if(deadSprite != null) {
                sr.sprite = deadSprite;
            }
            Time.timeScale = 0.03f;
			lm.gameIsOver = true;
		}
	}
}
