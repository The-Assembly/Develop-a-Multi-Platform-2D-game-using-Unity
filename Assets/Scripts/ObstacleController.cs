using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

	public float xSpeed;
	public float ySpeed;

	public float time;
	public GameObject obstaclePrefab;

	private float yMin,yMax;
	private Vector3 position;

	// Use this for initialization
	void Start () {
		yMin = -2;
		yMax = 3;
		Invoke("obstacleGeneration", time);
		Destroy(gameObject , 8);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3 (-xSpeed * Time.deltaTime, 0 , 0));
	}

	void obstacleGeneration () {
		position = new Vector3 (8f,Random.Range(yMin, yMax)); 
		Instantiate(obstaclePrefab, position , Quaternion.identity);
	}

}
