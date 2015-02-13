using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject asteroid;
	public Vector3 spawnValues;
	public int asteroidCount;
	public float spawnWait;
	public float waveWait;
	public float startWait;
	private int score;
	public GUIText scoreText;

	void Start () {
		score = 0;
		UpdateScore ();
		StartCoroutine (spawnAsteroids ());
	}

	void UpdateScore ()
	{
		scoreText.text = "Score : " + score;
	}

	public void AddNewScore(int newScore){
		score += newScore;
		UpdateScore ();
	}

	IEnumerator spawnAsteroids ()
	{
		yield return new WaitForSeconds (startWait);

		while (true) {
			for (int i = 0; i < asteroidCount; i++) {
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (asteroid, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

}
