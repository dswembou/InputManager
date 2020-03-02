using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	void Start ()
	{
	
	}

	void FixedUpdate () 
	{
		/* Basis input logic. GetKey haalt de
		 * keycodes op die zijn gemaakt bij GameManager
		 */
		if (Input.GetKey(GameManager.instance.forward))
		{
			Debug.Log("Naar voren!");
			transform.Translate(Vector3.forward / 20);
		}
			
		if (Input.GetKey(GameManager.instance.backward))
		{
			Debug.Log("Naar achteren!");
			transform.Translate(Vector3.back / 20);
		}
		
		if (Input.GetKey(GameManager.instance.left))
		{
			Debug.Log("Naar links!");
			transform.Rotate(0,-1f,0);
		}

		if (Input.GetKey(GameManager.instance.right))
		{
			Debug.Log("Naar rechts!");
			transform.Rotate(0,1f,0);
		}

		if (Input.GetKeyDown(GameManager.instance.jump))
		{
			Debug.Log("Spring!");
			GetComponent<Rigidbody>().AddForce(Vector3.up * 3f, ForceMode.Impulse);
		}
			
	}
}
