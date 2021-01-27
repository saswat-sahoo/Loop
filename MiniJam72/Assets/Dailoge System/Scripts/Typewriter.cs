using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour
{
    public float Letterdelay = 0.1f;
	private string currenttext = "";	// the text which will be printed at an instance
	public string sentence1;
	public AudioSource Beeper;
	public AudioClip Beep;
	// Start is called before the first frame update
    void Start()
    {
        sentence1 = this.GetComponentInChildren<Text>().text;
		StartCoroutine(ShowText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	IEnumerator ShowText()
	{
		//Beeper.SetActive(true);
		for(int i = 0; i <= sentence1.Length; i++)
		{
			currenttext = sentence1.Substring(0,i);		//used to select current letter by dividing the whole string into multiple small substrings (each containg a single letter)
			this.GetComponentInChildren<Text>().text = currenttext;	//acceses the text component of the UI element it is attached to
			Beeper.PlayOneShot(Beep, .2f);

			//Instantiate(Beep,transform.position,transform.rotation);	
			/*if(currenttext == "")
			{
				yield return new WaitForSeconds(pausetime);
				continue;
			}*/
			yield return new WaitForSeconds(Letterdelay);
			if(i == sentence1.Length)
			{
				//yield return new WaitForSeconds(Sentencedelay);
				
			}
			
		}
	}
}
