using UnityEngine;
using System.Collections;


public class grapeController : MonoBehaviour {
	public float xSpeed;
	private LevelManager lm;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		lm = FindObjectOfType<LevelManager>();
		player = FindObjectOfType<PlayerController>();
		Destroy(gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3 (-xSpeed * Time.deltaTime, 0, 0));
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
			player.playSound(2);
			Destroy(gameObject);
			lm.respawnSlider.value += 50;

		}
	}
}
