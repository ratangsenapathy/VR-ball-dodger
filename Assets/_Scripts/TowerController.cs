using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

	[HideInInspector]
	public bool isChosen;
	public float rotationSpeed;
	public GameObject towerTop;
	public Transform canonballSpawnPoint;
	public GameObject canonball;

	private GameManager gameManager;
	// Use this for initialization
	void Start () {
		isChosen = false;
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isChosen) {
			Vector3 oldDir = towerTop.transform.forward;
			Vector3 direction =  gameManager.user.transform.position - towerTop.transform.position;
			float step = rotationSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(towerTop.transform.forward,direction,step,0.0f);
			towerTop.transform.rotation = Quaternion.LookRotation (newDir);
			if (oldDir == newDir) {
				Instantiate (canonball, canonballSpawnPoint.position, Quaternion.identity);
				isChosen = false;
				gameManager.selectedCanon = false;
			}
		}
	}


}
