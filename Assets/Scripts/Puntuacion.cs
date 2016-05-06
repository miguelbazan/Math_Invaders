// <summary> Puntuacion.cs</summary>
// <remarks>
// Este código maneja la puntuacion del juego
// </remarks>


using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Puntuacion : MonoBehaviour {
	public Text puntos = null; //El text que usamos para desplegar los puntos
	public int score = 0; //El score que maneja

	// Use this for initialization
	void Start () {
		//Inicializamos los puntos
		puntos.text = "0";
	}
		
}
