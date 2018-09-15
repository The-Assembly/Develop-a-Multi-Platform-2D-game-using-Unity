using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

	public float xSpeed;
	public float ySpeed;

	public float time;
	public float cherryTime;
	public GameObject obstaclePrefab;
	public GameObject cherryPrefab;

	private float yMin,yMax;
	private Vector3 position;
	private Vector3 cherryPosition;

	// Use this for initialization
	void Start () {
		yMin = -5;
		yMax = 0;
		Invoke("obstacleGeneration", time);
		if(Random.Range(0,2) == 1){
			Invoke ("cherryGeneration", cherryTime);
		}
		Destroy(gameObject , 8);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3 (-xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0));
		if(transform.position.y >= 0)
			ySpeed = -ySpeed;
		if(transform.position.y <= -5)
			ySpeed = Mathf.Abs(ySpeed);
	}

	void obstacleGeneration () {
		position = new Vector3 (16.5f,Random.Range(yMin, yMax)); 
		Instantiate(obstaclePrefab, position , Quaternion.identity);
	}

	void cherryGeneration() {
		cherryPosition = new Vector3(28 , Random.Range(3f, 9.5f));
		Instantiate(cherryPrefab, cherryPosition, Quaternion.identity);
	}
}
