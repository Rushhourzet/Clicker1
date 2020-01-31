using Godot;
using System;

public class Clicker : Control
{
	private int timeInSec = 0;
	private int startTime;
	private double mana = 0;
	private double MPS = 1.0;
	private double crystals = 1;
	private double dmg = 1;
	private double manaCost = 1;
	private double maxMana = 10.0;
	private int monstersSlain = 0;
	private int monsterHealth = 10;
	private double manaIncreaseForSlayingMonster = 0.1;
	private Label manaLabel, maxManaLabel, crystalLabel, monsterSlainLabel;
	public override void _Ready()
	{
		startTime = DateTime.Now.Second;
		manaLabel = (Label)GetNode("ManaDisplay");
		maxManaLabel = (Label)GetNode("MaxManaDisplay");
		crystalLabel = (Label)GetNode("CrystalDisplay");
		monsterSlainLabel = (Label)GetNode("MonstersSlain");
	}

	public override void _Process(float delta){
		timeInSec = DateTime.Now.Second - startTime;
		if(timeInSec>3){
			RefreshLabels();
		}
	}
	private void _on_ClickButton_pressed()
	{
		mana += crystals;
		RefreshLabels();
	}
	private void _on_BuyCrystal_pressed()
	{
		// Replace with function body.
	}

	private void RefreshLabels(){
		manaLabel.Text = mana + " Mana";
		maxManaLabel.Text = maxMana + " Max Mana";
		crystalLabel.Text = crystals + " Crystals";
		monsterSlainLabel.Text = monstersSlain + " Monsters slain";
	}
	
	
}



