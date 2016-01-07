using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;
using UnityEngine.UI;
using System.Threading.Tasks;

public class ParseLogInScript : MonoBehaviour
{
	public InputField userName;
	public InputField password;
	public string enteredUsername;
	public string enteredPassword;
	public bool logInProcess = true;
	bool logInSuccessful = false;
	public GameObject[] Modals;
	
	public void LogInUser ()
	{
		logInProcess = true;
		while (logInProcess) {
			if (userName.text == string.Empty) {
				print ("Please enter a username");
				Modals [0].SetActive (true);
				logInProcess = false;
				break;
			}
			if (password.text == string.Empty) {
				print ("Please enter a password");
				Modals [1].SetActive (true);
				logInProcess = false;
				break;
			}
			
			enteredUsername = userName.text;
			enteredPassword = password.text;

			ParseUser.LogInAsync (enteredUsername, enteredPassword).ContinueWith (t =>
			{
				if (t.IsFaulted || t.IsCanceled) {
					// The login failed. Check the error to see why.
				} else {
					// Login was successful.
					print ("Login Successful\n");
					print ("Username: " + enteredUsername + "\n");
					print ("Password: " + enteredPassword + "\n");
					logInProcess = false;
					logInSuccessful = true;
				}
			});
			break;
		}
		
		if (logInSuccessful) {
			print ("Load Log In Page");
			Modals [6].SetActive (true);
		}
	}

	void Update()
	{
		if (logInSuccessful == true)
		Application.LoadLevel("Main");
	}
}
