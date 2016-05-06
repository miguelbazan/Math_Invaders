
// <summary> newGame.cs</summary>
// <remarks>
// Este código maneja la selección de nombre de nuestro personaje
// </remarks>

using UnityEngine; 
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class newGame : MonoBehaviour {


	//El inputfield y la variable a la que mandaremos el nombre que sacamos de playerprefs
	public InputField nombre;
	public string nom = "";


	// Update is called once per frame
	void Update () {
		//Guardamos el nombre que pone el niño como "nombre", para poder cargarlo en la siguiente escena
		PlayerPrefs.SetString ("nombre", nombre.text);
		Debug.Log (nombre.text);
	}

	/**
	 * Funcion: OnClick
	 * Mandamos el texto a una variable
	 **/
	public void onClick(){
		//Se manda el texto
		nom = nombre.text;
	}


	/**
	 * func ElijeNino()
	 * Despues de consultar su jugador, se carga el nivel
	 **/

	public void elijeNino(){
		Application.LoadLevel (11);
	}

		
}
