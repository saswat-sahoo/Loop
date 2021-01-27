using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dailouge Script", menuName = "DailougeSystem/Dailouge Script")]

public class dailougeScript : ScriptableObject
{
	public DilougeControls[] DailougeList;
	public bool IsCutscene = false;
}



public enum Position
{
		Left,
		Right
}

//[CreateAssetMenu(fileName = "New Dailouge Control", menuName = "DailougeSystem/Dailouge Control")]
[System.Serializable]
public class DilougeControls
{
	public Dailouge Dailouge;
	public Position Side = Position.Left;
}
	



