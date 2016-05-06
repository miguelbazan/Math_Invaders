// <summary> guardarPregunta.cs</summary>
// <remarks>
// Este código maneja el guardado preguntas
// </remarks>


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class guardarPreguntas : MonoBehaviour {
	//Todos los inputs fields que manejamos en la pantalla: 
	public 	InputField pregunta; 
	public 	InputField resA;
	public 	InputField resB;
	public 	InputField resC;

	// Use this for initialization
	void Start () {
		pregunta.GetComponent<InputField> ();
		resA.GetComponent<InputField> ();
		resB.GetComponent<InputField> ();
		resC.GetComponent<InputField> ();
	}

	/**
	 * Func onClick()
	 * Funcion que guarda en dos archivos las preguntas y las respuestas.
	 **/

	public void onClick(){
		//Mandamos en sw1 la pregunta, el archivo las maneja de 1 en 1, mientras que sw2 maneja respuestas de 3 en 3
		StreamWriter sw1;
		StreamWriter sw2;

		sw1=File.AppendText("C:\\Users\\laptops\\Desktop\\2dPlatformer\\Assets\\Text\\textoPreguntas.txt");

		sw1.WriteLine(pregunta.text);
		sw1.WriteLine(resA.text);
		sw1.WriteLine(resB.text);
		sw1.WriteLine(resC.text);

		sw1.Close ();

		//Limpiamos los input fields para que no haya problema alguno
		pregunta.text = "";
		resA.text = "";
		resB.text = "";
		resC.text = "";


	}

}

