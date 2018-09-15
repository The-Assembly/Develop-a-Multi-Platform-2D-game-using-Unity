using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	private PlayerController player;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			player.playSound(1);
			LevelManager.score++;
		}
	}
}
