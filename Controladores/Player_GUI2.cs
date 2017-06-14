using UnityEngine;
using System.Collections.Generic;

public class Player_GUI2 : MonoBehaviour {

	public float currentHP = 100;
	public float maxHP = 100;
	public float currentbarlenght;
	public float maxbarlenght = 100;

	void Start () {
	SkillButtons.add(new Rect(Screen.width/2 + 50, Screen.height/2 + 333,55,55));
	SkillButtons.add(new Rect(Screen.width/2 + 105, Screen.height/2 + 333,55,55));
	SkillButtons.add(new Rect(Screen.width/2 + 160, Screen.height/2 + 333,55,55));
	ItenButtons.add(new Rect(Screen.width/2 - 160, Screen.height/2 + 333,55,55));
	ItenButtons.add(new Rect(Screen.width/2 - 105, Screen.height/2 + 333,55,55));
	ItenButtons.add(new Rect(Screen.width/2 - 50, Screen.height/2 + 333,55,55));
	}
	void OnGUI(){

		List<Rect> SkillButtons = new List<Rect>();
		List<Rect> ItenButtons = new List<Rect>();

		GUI.Button(SkillButtons[0], "Skill A");
		GUI.Button(SkillButtons[1], "Skill B");
		GUI.Button(SkillButtons[2], "Skill C");
		GUI.Button(ItenButtons[0], "Item A");
		GUI.Button(ItenButtons[1], "Item B");
		GUI.Button(ItenButtons[2], "Item C");

		currentbarlenght = currentHP*maxbarlenght / maxHP;
		GUI.Box(new Rect(Screen.width/2 -20, Screen.height/2 + 300, currentbarlenght, 25f), " ");
		
	}
}
