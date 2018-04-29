using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private bool isWaiting;
	public GameObject[] towers;
	public GameObject user;
	public float timePeriodBetweenTowerSelection;
	[HideInInspector]
	public bool selectedCanon;
	// Use this for initialization
	void Start () {
		selectedCanon = false;
		isWaiting = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!isWaiting)
			StartCoroutine (ChooseTower ());
	}

	IEnumerator ChooseTower()
	{
		isWaiting = true;
		if (!selectedCanon) {
			int choice = Random.Range (0, towers.Length);
			towers[choice].GetComponent<TowerController> ().isChosen = true;

		}

		yield return new WaitForSeconds (timePeriodBetweenTowerSelection);
		isWaiting = false;
	}
}
