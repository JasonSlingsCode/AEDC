using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;
using UnityEngine.UI;
using System.Threading.Tasks;

public class ParseSignUpScript : MonoBehaviour
{
	public InputField userName;
	public InputField password_01;
	public InputField password_02;
	public InputField emailAddress;
	public string newUsername;
	public string newPassword;
	public string newEmailAddress;
	public bool signUpProcess = true;
	bool signUpComplete = false;

	public GameObject[] Modals;

	public void SignUpNewUser ()
	{
		signUpProcess = true;
		while (signUpProcess) {
			if (userName.text == string.Empty) {
				print ("Please enter a username");
				Modals[0].SetActive(true);
				signUpProcess = false;
				break;
			}
			if (password_01.text == string.Empty) {
				print ("Please enter a password");
				Modals[1].SetActive(true);
				signUpProcess = false;
				break;
			}
			if (password_02.text == string.Empty) {
				print ("Please retype your password");
				Modals[2].SetActive(true);
				signUpProcess = false;
				break;
			}
			if (password_01.text != password_02.text) {
				print ("Password verification does not match.");
				Modals[3].SetActive(true);
				signUpProcess = false;
				break;
			}
			if (emailAddress.text == string.Empty) {
				print ("Please enter your email address");
				Modals[4].SetActive(true);
				signUpProcess = false;
				break;
			}
			if (!emailAddress.text.Contains ("@") || !emailAddress.text.Contains (".")) {
				print ("Invalid email address.");
				Modals[5].SetActive(true);
				signUpProcess = false;
				break;
			}

			newUsername = userName.text;
			newPassword = password_01.text;
			newEmailAddress = emailAddress.text;

			var user = new ParseUser ()
		{
				Username = newUsername,
				Password = newPassword,
				Email = newEmailAddress
		};

			Task signUpTask = user.SignUpAsync ();

			print ("Signup Complete\n");
			print ("Username: " + newUsername + "\n");
			print ("Password: " + newPassword + "\n");
			print ("Email: " + newEmailAddress + "\n");
			signUpProcess = false;
			signUpComplete = true;
			break;
		}

		if (signUpComplete)
		{
			print ("Load Verify Email Modal");
			Modals[6].SetActive(true);
		}
	}

	public void LoadLogIn()
	{
		Application.LoadLevel("LogIn");
	}
}
