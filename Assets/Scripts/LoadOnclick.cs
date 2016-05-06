// <summary> LoadOnclick.cs</summary>
// <remarks>
// Este código maneja el cambio de una escena a otra
// </remarks>


using UnityEngine;
using System.Collections;

public class LoadOnclick : MonoBehaviour {

	/**
	 * Funcion LoadScene
	 * Cargamos una escena que queramos
	 **/

	public void LoadScene(int level){

		Application.LoadLevel (level);

	}
		
}
