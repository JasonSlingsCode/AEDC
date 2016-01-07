using UnityEngine;
using System.Collections;

public class ModalCloseScript : MonoBehaviour {

	public GameObject thisModal;

	public void CloseModal()
	{
		thisModal.SetActive (false);
	}
}
