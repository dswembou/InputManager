using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	[SerializeField] Transform menuPanel;
	Event keyEvent;
	Text buttonText;
	KeyCode newKey;

	bool waitingForKey;


	void Start ()
	{
		//Controleren dat panel niet actief is bij starten
		menuPanel.gameObject.SetActive(false);
		waitingForKey = false;

		/*Controleert van elke child van de panel
		 * de namen. De gekoppelde keycode wordt
		 * vervolgens opgeslagen.
		 */
		for(int i = 0; i < menuPanel.childCount; i++)
		{
			if(menuPanel.GetChild(i).name == "ForwardKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.instance.forward.ToString();
			else if(menuPanel.GetChild(i).name == "BackwardKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.instance.backward.ToString();
			else if(menuPanel.GetChild(i).name == "LeftKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.instance.left.ToString();
			else if(menuPanel.GetChild(i).name == "RightKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.instance.right.ToString();
			else if(menuPanel.GetChild(i).name == "JumpKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.instance.jump.ToString();
		}
	}


	void Update ()
	{
		//Escape knop opent en sluit het menu
		if(Input.GetKeyDown(KeyCode.Escape) && !menuPanel.gameObject.activeSelf)
			menuPanel.gameObject.SetActive(true);
		else if(Input.GetKeyDown(KeyCode.Escape) && menuPanel.gameObject.activeSelf)
			menuPanel.gameObject.SetActive(false);
	}

	void OnGUI()
	{
		/*keyEvent controleert of de speler
		 * op een knop drukt.
		 */
		keyEvent = Event.current;
		
		if(keyEvent.isKey && waitingForKey)
		{
			newKey = keyEvent.keyCode; //koppelt de nieuwe knop die de speler  indrukt
			waitingForKey = false;
		}
	}

	/*Buttons kunnen niet  Coroutines via OnClick() starten.
	 * Daarom maken gebruiken wij in de plaats daarvan deze functie
	 * die vervolgens de Coroutine binnen in dit script aanroept
	 */
	public void StartAssignment(string keyName)
	{
		if(!waitingForKey)
			StartCoroutine(AssignKey(keyName));
	}

	//Tekst koppelen aan de knop
	public void SendText(Text text)
	{
		buttonText = text;
	}

	//Wordt gebruikt voor afwachten van een ingedrukte toets
	IEnumerator WaitForKey()
	{
		while(!keyEvent.isKey)
			yield return null;
	}

	/*AssignKey neemt een keyName als een parameter. De
	 * keyName wordt gecontroleerd met een switch statement. 
	 */
	public IEnumerator AssignKey(string keyName)
	{
		waitingForKey = true;

		yield return WaitForKey(); //Wordt continu uitgevoerd als de speler niks indrukt

		switch(keyName)
		{
		case "forward":
			GameManager.instance.forward = newKey; //Zet forward op de nieuwe keycode
			buttonText.text = GameManager.instance.forward.ToString(); //Tekst van de knop aanpassen
			PlayerPrefs.SetString("forwardKey", GameManager.instance.forward.ToString()); //save new key to PlayerPrefs
			break;
		case "backward":
			GameManager.instance.backward = newKey; //Zet backwards op de  nieuwe keycode
			buttonText.text = GameManager.instance.backward.ToString(); //Tekst van de knop aanpassen
			PlayerPrefs.SetString("backwardKey", GameManager.instance.backward.ToString()); //Opslaan in PlayerPrefs
			break;
		case "left":
			GameManager.instance.left = newKey; //Zet left op de  nieuwe keycode
			buttonText.text = GameManager.instance.left.ToString(); //Tekst van de knop aanpassen
			PlayerPrefs.SetString("leftKey", GameManager.instance.left.ToString()); //Opslaan in PlayerPrefs
			break;
		case "right":
			GameManager.instance.right = newKey; //Zet right op de  nieuwe keycode
			buttonText.text = GameManager.instance.right.ToString(); //Tekst van de knop aanpassen
			PlayerPrefs.SetString("rightKey", GameManager.instance.right.ToString()); //Opslaan in PlayerPrefs
			break;
		case "jump":
			GameManager.instance.jump = newKey; //Zet jump op de  nieuwe keycode
			buttonText.text = GameManager.instance.jump.ToString(); //Tekst van de knop aanpassen
			PlayerPrefs.SetString("jumpKey", GameManager.instance.jump.ToString()); //Opslaan in PlayerPrefs
			break;
		}

		yield return null;
	}
}
