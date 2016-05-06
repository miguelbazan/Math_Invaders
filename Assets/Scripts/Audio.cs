// <summary> Audio.cs</summary>
// <remarks>
// Este código maneja las opciones de pausar todo el audio o reanudarlo.
// </remarks>

using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

	/* Func muteAudio
	 * Silenciamos el audio del juego.
	 */
	public void muteAudio(){
		AudioListener.volume = 0.001f;
	}

	/* Func CargarNivel
	 * Silenciamos el audio del juego.
	 */

	public void UnmuteAudio(){
		AudioListener.volume = 1f;
	}
}
