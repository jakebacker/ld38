using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

	Camera cam;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		float axis = -Input.GetAxisRaw("MouseScrollWheel");
		if (cam.orthographicSize + axis > 0 && cam.orthographicSize + axis <= 30) {
			cam.orthographicSize += axis;
		}

		Vector3 locationModifier = new Vector3(0, 0, 0);

		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			locationModifier = new Vector3(0, 2, 0);
		}
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			locationModifier = new Vector3(0, -2, 0);
		}
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			locationModifier = new Vector3(-2, 0, 0);
		}
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			locationModifier = new Vector3(2, 0, 0);
		}

		if (!((cam.gameObject.transform.position + locationModifier).x > 10 ||
		    (cam.gameObject.transform.position + locationModifier).x < -10 ||
		    (cam.gameObject.transform.position + locationModifier).y > 10 ||
			(cam.gameObject.transform.position + locationModifier).y < -10))
		{
			cam.gameObject.transform.position += locationModifier;
		}
	}

	public static void SpawnBacteria(BacteriumType type) {
		GameObject bacteria = Instantiate(Resources.Load<GameObject>("prefabs/Bacteria"));
		Bacterium bacteriaScript = bacteria.GetComponent<Bacterium>();

		bacteriaScript.type = type;
	}
}
