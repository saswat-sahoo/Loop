using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Emotion
{
	Sad,
	Neutral,
	Smile,
	Annoyed
}


[CreateAssetMenu(fileName = "New Dailouge", menuName = "DailougeSystem/Dailouge")]
[System.Serializable]
public class Dailouge : ScriptableObject
{	
	public Charecter Speaker;
	public int Textsize = 25;
	public float TextSpeed = 0.1f;
	public float Sentencespeed = 0.2f;
	[TextArea(3,10)]
	public string[] sentences;
	public Emotion SpeakerEmotion = Emotion.Neutral;

	
	/*public Dailouge(string Name, Sprite P1, Sprite P2, string[] sent)
	{
		Name = Speaker.Name; 
		P1 = Speaker.Potrait_b;
		P2 = Speaker.Potrait_d;
		sent = sentences;
	}*/
}

