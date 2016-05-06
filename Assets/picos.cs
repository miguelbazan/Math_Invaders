// <summary> picos.cs</summary>
// <remarks>
// Este código maneja los picos, sus funciones, etc.
// </remarks>


using UnityEngine;
using System.Collections;

public class picos : MonoBehaviour {
	public PlayerController player; //Referencia a mi jugador
	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> (); //Inicializamos mi referencia de jugador

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
	
		if (other.tag == "Player") {
			player.fVida-= 2; //Si colisiona con el jugador, le restamos dos puntos de vida.

		}
	}
}
