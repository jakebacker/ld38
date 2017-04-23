using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	Vector2 spawnPosition;
	//public static float timeout = 5.0f;
	int randomTypeNum = 0;
	BacteriumType type = BacteriumType.COCCUS;


	// Use this for initialization
	void Start () {
		spawnPosition = new Vector2(0, 0);

		StartCoroutine("Spawn");
		StartCoroutine("UpdateTimeout");
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerController.isDead)
		{
			StopAllCoroutines();
		}
	}

	IEnumerator UpdateTimeout() {
		while (true)
		{
			yield return new WaitForSeconds(10.0f);
			if (PlayerController.timeout > 1)
			{
				PlayerController.timeout -= 0.25f;
				PlayerController.UpdateUI();
				Debug.Log("Updating Timeout");
			}
		}
	}

	IEnumerator Spawn() {
		while (true)
		{
			yield return new WaitForSeconds(PlayerController.timeout);
			randomTypeNum = Random.Range(1, 76);

			if (randomTypeNum <= 15)
			{
				type = BacteriumType.COCCUS;
			}
			else if (randomTypeNum > 15 && randomTypeNum <= 28)
			{
				type = BacteriumType.DIPLOCOCCI;
			}
			else if (randomTypeNum > 28 && randomTypeNum <= 36)
			{
				type = BacteriumType.TETRAD;
			}
			else if (randomTypeNum > 36 && randomTypeNum <= 50)
			{
				type = BacteriumType.BACILLUS;
			}
			else if (randomTypeNum > 50 && randomTypeNum <= 62)
			{
				type = BacteriumType.DIPLOBACILLI;
			}
			else if (randomTypeNum > 62 && randomTypeNum <= 70)
			{
				type = BacteriumType.STREPTOBACILLI;
			}
			else if (randomTypeNum > 70 && randomTypeNum <= 76)
			{
				type = BacteriumType.PALISADES;
			}
				
			spawnPosition = new Vector2(Random.Range(-6, 6), Random.Range(-5, 5));

			WorldController.SpawnBacteria(type, spawnPosition);
		}
	}
}
