using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Typewriter : MonoBehaviour {


	private Text textField;
    public bool isFinished;

	[TextArea(6, 30)]
	public string myTxtArea;

	[Header("Letter Wait Time")]
	[Tooltip("1 second equals 1000 milliseconds")]
	public float inMilliseconds;


	void Start () {

		textField = GetComponent<Text>();
		textField.text = "";

		StartCoroutine(TypeWritedText());
	}

	IEnumerator TypeWritedText()
	{
		foreach (var letter in myTxtArea.ToCharArray())
		{
			textField.text += letter;
			yield return new WaitForSeconds(inMilliseconds/1000f);
		}
        isFinished = true;
    }
}
