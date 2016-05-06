// <summary> EndGame.cs</summary>
// <remarks>
// Este código maneja el borrar un personaje
// </remarks>

using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	public string nombre; //El nombre del jugador actual

	void Start(){
		nombre = PlayerPrefs.GetString ("nombre");
	
	}


	//El niño borra su personaje
	public void BorrarPersonaje(){
	
		PlayerPrefs.DeleteKey (nombre + "Nivel");	
		PlayerPrefs.DeleteKey (nombre + "Puntos");
		PlayerPrefs.DeleteKey (nombre + "Nombre");	
	}

}
