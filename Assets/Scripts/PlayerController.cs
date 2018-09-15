using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb2d;
	private float yValue = 0;
	private LevelManager lm;
	private BoxCollider2D bc2d;
	private SpriteRenderer sr;

	public bool gameIsOver;
	public Sprite grapeSprite;
	public Sprite normalSprite;
	public Sprite halfGrapeSprite;

	public AudioClip [] Sounds;
	private AudioSource audio;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		bc2d = GetComponent<BoxCollider2D>();
		lm = FindObjectOfType<LevelManager>();
		sr = GetComponent<SpriteRenderer>();
		Time.timeScale = 0;
		GetComponent<Rigidbody2D>().gravityScale = 0;
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!gameIsOver){
			if(lm.respawnSlider.value == lm.respawnSlider.maxValue){
				sr.sprite = grapeSprite;
			} else if(lm.respawnSlider.value == lm.respawnSlider.maxValue/2){
				sr.sprite = halfGrapeSprite;
			} 
		}
		if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !gameIsOver)
		{	playSound(0);
			Time.timeScale = 1;
			if(!lm.playerRespawned) {
				sr.enabled = true;
				bc2d.enabled = true;
			}
			GetComponent<Rigidbody2D>().gravityScale = 2.5f;
			rb2d.velocity = Vector2.zero;
			rb2d.AddForce(new Vector2 (0,450));
			transform.localEulerAngles = new Vector3 ( 0 , 0 , 15);
			yValue = transform.position.y;
			if(lm.playerRespawned){
				StartCoroutine(Flasher());
				lm.playerRespawned = false;
				sr.sprite = normalSprite;
			}
		}

		if(transform.position.y < yValue )
		{
			transform.localEulerAngles = new Vector3 ( 0 , 0 , -15);
		}
	}
	

	IEnumerator Flasher() {
		for(int i = 0; i < 2; i++){
			bc2d.enabled = false;
			sr.enabled = false;
			yield return new WaitForSeconds(0.05f);
			sr.enabled = true;
			yield return new WaitForSeconds(0.2f);
		}
	}

	public void playSound (int soundIndex)
	{
		audio.clip = Sounds[soundIndex];
		audio.Play ();
	}
}
