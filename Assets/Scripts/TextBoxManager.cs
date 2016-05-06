using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;
using System.Text;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox; //Objeto de tipo TextBox en la escena

	public Text theText; //Objeto de tipo Texto en la escena
	public TextAsset textFile; //Objeto de tipo Asset en la escena

	public string[] textLines; //Arreglo de string para las preguntas

	public int currentLine = 0; //Int; linea actual de la que se lee el arreglo
	public int endAtLine = 0; //Linea final del arreglo

	public PlayerController player; //Objeto de tipo PlayerController del jugador en la escena
	public Enemigo[] enemigo;

	public bool isActive = false; //Variable de tipo bool para definir si esta activo el panel
	public bool stopPlayerMovement; //Variable de control para controlar el movimiento de jugador 

	public Button Button1; //Variable de tipo Button 
	public Button Button2;//Variable de tipo Button
	public Button Button3;//Variable de tipo Button

	public string respuestaCorrecta; //Variable de tipo String que incluye la respuesta correcta
	public string texto1; //Variable de tipo texto 
	public string texto2;//Variable de tipo texto
	public string texto3;//Varibale de tipo texto

	public bool isCorrect = false; //Variable de tipo bool de control para la respuesta correcta
	public bool isHitted = false; //Variable de control tipo bool para ver si un objeto fue golpeado

	public int iNumRandom; //Variable de tipo int, incluye un numero random

	// Use this for initialization
	void Start () {
		//Inicializamos la variable currentLine en 0 (inicio del arreglo)
		currentLine = 0; 
		//Buscamos el objeto en la escena de tipo PlayerController
		player = FindObjectOfType<PlayerController> ();
		//Buscamos el objeto en la escena de tipo Enemigo
		enemigo = FindObjectsOfType<Enemigo> ();
		//Si el archivo fue encontrado...
		if (textFile != null) {
			//leemos las lineas del archivo de texto
			textLines = (textFile.text.Split('\n'));
			//Leemos las preguntas del archivo del texto
			leerPreguntas ();
			//Inicializamos la variable endAtLine con el tama駉 del arreglo
			endAtLine = textLines.Length;
		}
		//Si la variable de control isActive es TRUE, activamos el panel de pregunta
		//Si la variable de control isActive es FALSE, desactivamos el panel de pregunta
		if (isActive) {
			//Activamos el panel
			EnableTextBox ();
		} else {
			//Descativamos el panle
			DisableTextBox ();
		}
	}

	// Update is called once per frame
	void Update () {
		//Mientras el panel este Activo, no pasamos a las siguientes instrucciones
		if (!isActive) {
			return;
		}
		//Leemos el string del arreglo en el indice currentLine
		theText.text = textLines [currentLine];
	}

	/**
	 * Funcion: EnableTextBox()
	 * Activa en la escena el panel de preguntas
	 **/

	public void EnableTextBox() { 
		//Activamos el textBox en la escena
		textBox.SetActive(true);
		//Marcamos con TRUE, debido a que el panel esta activo en  la escena
		isActive = true;
		//Asignamos la variable canDisparar del Player en FALSE para que no pueda dispara
		player.canDisparar = false;
		//Si stopPlayerMovement es TRUE...
		if(stopPlayerMovement) {
			//Marcamos la variable de control canMove del objeto Player como FALSE, para evitar que se mueva
			player.canMove  = false;
			//Marcamos la variable de control canMove del objeto Enemigo como FALSE, para evitar que se muevan
			for(int i=0; i<enemigo.Length;i++)
				enemigo[i].canMove = false;
		}
	}

	/**
	 * Funcion: DisableTextBox()
	 * Desactiva en la escena el panel de preguntas
	 **/
	public void DisableTextBox(){
		//Desactivamos el objeto de TextBox en la escena
		textBox.SetActive (false);
		//Marcamos la variable de control canMove del objeto Player como TRUE, para permitir que se mueva
		player.canMove = true;
		//Asignamos la variable canDisparar del Player en TRUE para que pueda dispara
		player.canDisparar = true;
		//Marcamos la variable de control canMove del objeto Enemigo como TRUE, para permitir que se muevan
		for (int i = 0; i < enemigo.Length; i++) {
			enemigo [i].canMove = true;
		}
		//Marcamos la variable de control de isCorrect en FALSE
		isCorrect = false;
		//Marcamos la variable de control isActive en FALSE
		isActive = false;
	}

	/**
	 * Funcion: correctAnswer()
	 * Funcion que realiza las acciones al momento de contestar de manera correcta
	 **/
	public void correctAnswer(){
		//Marcamos la variable de control isCorrect como TRUE, se馻lando que la respuesta es correcta
		isCorrect = true;
		//Desactivamos el panel de preguntas de la escena
		DisableTextBox ();
		//Aumentamos la linea actual del arreglo de preguntas en 4, para llegar a la siguiente
		currentLine += 4;
		//Leemos las preguntas y respuestas siguientes
		leerPreguntas();
		//Si algun enemigo, su variable de control isHitted es TRUE, lo eliminamos
		for (int i = 0; i < enemigo.Length; i++) {
			if(enemigo[i].isHitted){
				//Llamamos a la funcion para destruir el objeto de tipo Enemigo
				enemigo[i].destroyEnemigo();
			}
		}

	}
	/**
	 * Funcion: correctAnswer()
	 * Funcion que realiza las acciones al momento de contestar de manera correcta
	 **/
	public void incorrectAnswer(){
		//Desactivamos el panel de preguntas de la escena
		DisableTextBox ();
		//Marcamos las variables de control isHitted de los objetos Enemigos en la escena como FALSE
		for (int i = 0; i < enemigo.Length; i++)
			enemigo [i].isHitted = false;
		//Aumentamos la linea actual del arreglo de perguntas en 4, para llegar a las siguiente 
		currentLine += 4;
		//Leemos la pregunta y respuesta
		leerPreguntas();
	}

	/**
	 * Funcion: leerPreguntas()
	 * Funcion que lee la pregunta y respuestas escritos en el archivo de texto. Asi mismo, modifica el texto de los botones
	 * para que aparezcan las preguntas y respuestas en el panel
	 **/
	public void leerPreguntas(){
		//Si la linea actual es igual o mayor a el limite del texto - 1, actualizamos el valor a 0
		if (currentLine >= endAtLine - 1) {
			currentLine = 0;
		}
		//Conseguimos un numero random entre 1 y 3
		iNumRandom = Random.Range (1, 4);
		//Dependiendo del numero obtenido, es el boton en el cual sera asignado el texto de la respuesta correcta
		switch (iNumRandom) {
		case 1: 
			//Se asigna en el primer boton (izquierda)
			Button1.GetComponentInChildren<Text> ().text = textLines [currentLine + 1];
			break;
		case 2:
			//se asgina en el segundo boton (centro)
			Button2.GetComponentInChildren<Text> ().text = textLines [currentLine + 1];
			break;
		case 3:  
			//se asigna en el tercer boton (derecha)
			Button3.GetComponentInChildren<Text> ().text = textLines [currentLine + 1]; 
			break;
		}

		//Dependiendo de en que boton fue asignado el texto de la respuesta correcta, asignamos los otros dos botones
		if (iNumRandom == 1) {
			//Si fue en el primer boton, asignamos los demas textos en los botones 2 y 3
			Button2.GetComponentInChildren<Text> ().text = textLines [currentLine + 2];
			Button3.GetComponentInChildren<Text> ().text = textLines [currentLine + 3];
		} else if (iNumRandom == 2) {
			//Si fue en el segundo boton, asignamos los demas textos en los botones 1 y 3
			Button1.GetComponentInChildren<Text> ().text = textLines [currentLine + 2];
			Button3.GetComponentInChildren<Text> ().text = textLines [currentLine + 3]; 
		} else if (iNumRandom == 3) {
			//Si fue en el tercer boton, asignamos los demas textos en los botones 1 y 2
			Button1.GetComponentInChildren<Text> ().text = textLines [currentLine + 2];
			Button2.GetComponentInChildren<Text>().text = textLines [currentLine + 3];
		}
	}

	/**
	 * Funcion: boton1()
	 * Funcion que realiza las acciones al momento que el boton #1 (izquierda) es presionado
	 **/
	public void boton1(){
		//Obtenemos el texto que se encuentra en el boton actual
		texto1 = Button1.GetComponentInChildren<Text> ().text;
		//Si el texto en el boton es igual a la variable string de respuesta correcta
		if (texto1 == respuestaCorrecta) {
			//Realizamos las acciones de respuestas correcta
			correctAnswer ();
		}
		else
			//Realizamos la accion de respuesta incorrecta
			incorrectAnswer();

	}

	/**
	 * Funcion: boton2()
	 * Funcion que realiza las acciones al momento que el boton #1 (izquierda) es presionado
	 **/
	public void boton2(){
		//Obtenemos el texto que se encuentra en el boton actual
		texto2 = Button2.GetComponentInChildren<Text> ().text;
		//Si el texto en el boton es igual a la variable string de respuesta correcta
		if (texto2 == respuestaCorrecta) {
			//Realizamos las acciones de respuestas correcta
			correctAnswer ();
		} else
			//Realizamos la accion de respuesta incorrecta
			incorrectAnswer ();
	}
	/**
	 * Funcion: boton3()
	 * Funcion que realiza las acciones al momento que el boton #1 (izquierda) es presionado
	 **/
	public void boton3(){
		//Obtenemos el texto que se encuentra en el boton actual
		texto3 = Button3.GetComponentInChildren<Text> ().text;
		//Si el texto en el boton es igual a la variable string de respuesta correcta
		if (texto3 == respuestaCorrecta) {
			//Realizamos las acciones de respuestas correcta
			correctAnswer ();
		} else
			//Realizamos la accion de respuesta incorrecta
			incorrectAnswer ();
	}

}
