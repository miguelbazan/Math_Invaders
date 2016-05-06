using UnityEngine;
using System.Collections;

public class lifeController : MonoBehaviour {

	public PlayerController jugador;
	public AudioSource sonido;
	// Use this for initialization
	void Start () {
		jugador = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player") {
			jugador.fVida += 1;
			sonido.Play ();
			Destroy (gameObject);
		}
	}
}
