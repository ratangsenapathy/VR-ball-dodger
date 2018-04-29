using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanonballController : MonoBehaviour {

	private GameObject user;
	private Vector3 target;
	public float speed;
	private bool targetReached = false;
	// Use this for initialization
	void Start () {
		user = GameObject.Find("GameManager").GetComponent<GameManager> ().user;
		target = user.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		//if (transform.position == target)
			//Destroy (this.gameObject);

		if (!targetReached) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target, step);
		} else {
			float step = speed * Time.deltaTime;
			if (Vector3.Distance (user.transform.position, target) < 0.30)
				SceneManager.LoadScene ("GameOverScene", LoadSceneMode.Single);
			transform.position = Vector3.MoveTowards (transform.position,  transform.position+ transform.forward, step);
			if (Vector3.Distance (transform.position, target) > 10)
				Destroy (gameObject);
		}
		if (transform.position == target) {
			targetReached = true;
		}
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("Hello");
		if (other.CompareTag ("MainCamera")) {
			SceneManager.LoadScene ("GameOverScene", LoadSceneMode.Single);
		}
	}
}
