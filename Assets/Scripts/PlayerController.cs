using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb2d;
	private float yValue = 0;
	private LevelManager lm;
	private BoxCollider2D bc2d;
	private SpriteRenderer sr;

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
		if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !lm.gameIsOver)
		{	playSound(0);
			Time.timeScale = 1;

			GetComponent<Rigidbody2D>().gravityScale = 2.5f;
			rb2d.velocity = Vector2.zero;
			rb2d.AddForce(new Vector2 (0,450));
			transform.localEulerAngles = new Vector3 ( 0 , 0 , 15);
			yValue = transform.position.y;
		}

		if(transform.position.y < yValue )
		{
			transform.localEulerAngles = new Vector3 ( 0 , 0 , -15);
		}
	}
	

	public void playSound (int soundIndex)
	{
        if(Sounds.Length > 0) {
            audio.PlayOneShot(Sounds[soundIndex]);
        }
	}
}
