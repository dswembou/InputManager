using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Gebruikt voor singleton
	public static GameManager instance;

	//Keycodes aanmaken die worden gekoppeld aan de speleracties.
	//Deze kunnen door andere scripts worden uitgelezen.
	public KeyCode jump {get; set;}
	public KeyCode forward {get; set;}
	public KeyCode backward {get; set;}
	public KeyCode left {get; set;}
	public KeyCode right {get; set;}



	void Awake()
	{
		//Singleton pattern
		if(instance == null)
		{
			DontDestroyOnLoad(gameObject);
			instance = this;
		}	
		else if(instance != this)
		{
			Destroy(gameObject);
		}

		/*Koppelt elke keycode als de game start
		 * Laad data van PlayerPrefs zodat als de speler afsluit, 
		 * dat de instellingen worden bewaard voor de volgende keer.
		 * Instellingen worden als een string opgeslagen via de tweede parameter
		 * van de GetString() functie
		 */
		jump = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
		forward = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey", "W"));
		backward = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKey", "S"));
		left = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
		right = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));

	}

	void Start () 
	{
	
	}

	void Update () 
	{
	
	}
}
