using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DailougeDisplayer : MonoBehaviour
{
	public GameObject LeftPanel;
	public Image PotraitLeft;
	public Text NameTextLeft;
	
	
	public GameObject RightPanel;
	public Image PotraitRight;
	public Text NameTextRight;
	
	
	public Text DailougeText;
	public Dailouge Guest;
    public Queue<string> sentences;
	public float Letterdelay = 0.5f;	//delay between each letters
	public float Sentencedelay = 0.5f;	//delay between sentences
	public string Fulltext;				//text which will be displayed
	private string currenttext = "";	// the text which will be printed at an instance
	string sentence1;
	public Animator anim;
	public float pausetime = 0.5f;
	private Sprite AdjustedSprite;
	public dailougeScript Hell;
	private DilougeControls TempDailougeControl;
	public Queue<DilougeControls> List;
	public AudioSource Beeper;
	private AudioClip Beep;
	private bool Cutscene;
	//public bool Isplaying;
	//private DilougeControls[] List;

	// Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
		List = new Queue<DilougeControls>();
		
		//StartDailougeScript(Hell);
    }

	public void StartDailougeScript(dailougeScript DailougeScript)
	{
		Cutscene = DailougeScript.IsCutscene;
		foreach(DilougeControls Sad in DailougeScript.DailougeList)
		{
			//StartDailouge(sentence.Dailouge);
			List.Enqueue(Sad);
		}
		DisplayNextDailouge();
	}

	public void DisplayNextDailouge()
	{
		if (List.Count == 0)
		{
			EndDailougeScript();
			return;
		}
		//sentence1 = sentences.Dequeue();
		//DailougeText.text = sentence1;
		TempDailougeControl = List.Dequeue();
		StartDailouge(TempDailougeControl.Dailouge, TempDailougeControl.Side);

	}

	
	public void StartDailouge(Dailouge dailouge, Position Pos)
	{
		//Potrait1.sprite = AdjustedSprite
		Beep = dailouge.Speaker.VoiceBeep;
		anim.SetBool("Dailoge_display",true);
		AdjustSprite(dailouge);
		if(Pos == Position.Left)
		{
			LeftPanel.SetActive(true);
			RightPanel.SetActive(false);
			PotraitLeft.sprite = AdjustedSprite;
			NameTextLeft.text = dailouge.Speaker.Name;
		}
		else if(Pos == Position.Right)
		{
			LeftPanel.SetActive(false);
			RightPanel.SetActive(true);
			PotraitRight.sprite = AdjustedSprite;
			NameTextRight.text = dailouge.Speaker.Name;
		}
		
		
		//NameText.text = dailouge.Speaker.Name;
		//Potrait1.sprite = dailouge.Speaker.Sad;
		Letterdelay = dailouge.TextSpeed;
		Sentencedelay = dailouge.Sentencespeed;
		DailougeText.fontSize = dailouge.Textsize;
		sentences.Clear();
		foreach (string sentence in dailouge.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		

		if (sentences.Count == 0)
		{
			EndDailouge();
			return;
		}
		sentence1 = sentences.Dequeue();
		DailougeText.text = sentence1;
		StopAllCoroutines();
		StartCoroutine(ShowText());
		

	}

	public void EndDailouge()
	{
		DisplayNextDailouge();
		//Isplaying = false;
		//anim.SetBool("Dailoge_display",false);
	}

	private void AdjustSprite(Dailouge S)
	{
		if(S.SpeakerEmotion == Emotion.Sad)
		{
			AdjustedSprite = S.Speaker.Sad;
		
		}else if(S.SpeakerEmotion == Emotion.Neutral)
		{
			AdjustedSprite = S.Speaker.Neutral;
		
		}else if(S.SpeakerEmotion == Emotion.Smile)
		{
			AdjustedSprite = S.Speaker.Smile;
			Debug.Log("Its sad");
		}else if(S.SpeakerEmotion == Emotion.Annoyed)
		{
			AdjustedSprite = S.Speaker.Annoyed;
		}
		
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
			yield return null;
			if(i == sentence1.Length)
			{
				yield return null;
				//Beeper.SetActive(true);
				if(Cutscene == true)
				{DisplayNextSentence();}
				break;
			}
			
		}
	}

	 void EndDailougeScript()
	{
		anim.SetBool("Dailoge_display",false);
	}

	void Update()
	{
		if(Input.anyKeyDown == true && Cutscene == false)
		{
			DisplayNextSentence();
		}
	}
	
}
