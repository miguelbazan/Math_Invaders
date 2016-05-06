// <summary> setLevel2.cs</summary>
// <remarks>
// Este código maneja el setteo de nivel de mi jugador
// </remarks>


using UnityEngine;
using System.Collections;

public class setLevel2 : MonoBehaviour {
	public PlayerController jugador;
	// Use this for initialization
	void Start () {
		jugador = FindObjectOfType<PlayerController> ();
	}

	/**
	 *Func OntriggerEnter2D
	 *Manejamos los triggers con el jugador, cuando colisiona con el jugador se le settea el nivel como 2.
	 **/
	void OnTriggerEnter2D(Collider2D player){
		if (player.tag == "Player") {
			jugador.currentLevel = 2;
			PlayerPrefs.SetInt (jugador.nombre + "Nivel", 2);
}
	}
}