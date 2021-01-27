using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Charecter", menuName = "DailougeSystem/Charecter")]
[System.Serializable]
public class Charecter : ScriptableObject
{
    // Start is called before the first frame update
	public Sprite Sad;
	public Sprite Neutral;
	public Sprite Smile;
	public Sprite Annoyed;
	public string Name;
	public AudioClip VoiceBeep;
}
