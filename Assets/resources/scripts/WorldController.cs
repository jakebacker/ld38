using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void SpawnBacteria(BacteriumType type) {
		GameObject bacteria = Instantiate(Resources.Load<GameObject>("prefabs/Bacteria"));
		Bacterium bacteriaScript = bacteria.GetComponent<Bacterium>();

		bacteriaScript.type = type;
	}
}
