using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using Parse;
using UnityEngine.UI;


public class ParseIntroScript : MonoBehaviour
{
	public Button logIn;
	public Button signUp;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine ("IntroSequence");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	IEnumerator IntroSequence()
	{
		yield return new WaitForSeconds (3);
		if (ParseUser.CurrentUser != null)
		{
			// do stuff with the user
			Application.LoadLevel("Main");
		}
		else
		{
			// show the signup or login screen
			logIn.gameObject.SetActive(true);
			signUp.gameObject.SetActive(true);
		}
	}

	public void LoadSignUp()
	{
		Application.LoadLevel ("SignUp");
	}

	public void LoadLogIn()
	{
		Application.LoadLevel ("LogIn");
	}
}
