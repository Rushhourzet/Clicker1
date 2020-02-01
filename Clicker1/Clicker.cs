using Godot;
using System;

public class Clicker : Control
{
	// private double timeInSec = 0;
	// private double startTime;
	private double mana = 0;
	private double mps = 1.0;
	private double crystals = 1;
	private double crystalCost = 10;
	private double dmg = 1;
	private double manaCost = 1;
	private double maxMana = 10.0;
	private int monstersSlain = 0;
	private double monsterHealth = 10;
	private double monsterMaxHealth = 10;
	private double manaIncreaseForSlayingMonster = 0.1;
	private double dps = 0.5;
	private bool monsterDead = false;
	private Label manaLabel, maxManaLabel, crystalLabel, monsterSlainLabel;
	private Label monsterMaxHPLabel, crystalCostLabel;
	private ProgressBar monsterHPBar;
	public override void _Ready()
	{
		// startTime = DateTime.Now.Millisecond / 1000;
		manaLabel = (Label)GetNode("ManaDisplay");
		maxManaLabel = (Label)GetNode("MaxManaDisplay");
		crystalLabel = (Label)GetNode("CrystalDisplay");
		monsterSlainLabel = (Label)GetNode("MonstersSlain");
		monsterMaxHPLabel = (Label)GetNode("MonsterMaxHealth");
		crystalCostLabel = (Label)GetNode("CrystalCostDisplay");
		monsterHPBar = (ProgressBar)GetNode("MonsterHPBar");
		monsterHPBar.Step = 0.01;
	}

	public override void _Process(float delta){
		// timeInSec = DateTime.Now.Millisecond / 1000 - startTime;
		MPS_DPS(delta);
		RefreshValues();
		RefreshLabels();
	}

	private void MPS_DPS(float delta)
	{
		if(mana <= maxMana){
			mana += mps * delta;
		}
		monsterHealth -= dps * delta;
		if(monsterHealth <= 0){
			monsterDead = true;			
		}
	}

	private void _on_ClickButton_pressed()
	{
		if(mana >= manaCost){
			dps += dmg;
			//monsterHealth -= dmg;
			if(monsterHealth <= 0){
				monsterDead = true;			
			}
			mana -= manaCost;
		}
		RefreshValues();
		RefreshLabels();
	}
	private void _on_BuyCrystal_pressed()
	{
		if(mana >= crystalCost){
			crystals++;
			mana -= crystalCost;
		}
		RefreshValues();
		RefreshLabels();
	}
	private void _on_ClickButtonAll_pressed()
	{
		double times = mana / manaCost;
		if(times != 0){
			dps += dmg * times;
			//monsterHealth -= dmg;
			if(monsterHealth <= 0){
				monsterDead = true;			
			}
			mana -= manaCost * times;
		}
		RefreshValues();
		RefreshLabels();
	}


private void _on_BuyCrystalAll_pressed()
	{
		if(crystalCost != 0){
			double times = mana / crystalCost;
			if(times != 0){
				crystals += times;
				mana -= crystalCost * times;
			}
		} 
		else {
			while(crystalCost == 0){
				crystals++;
				crystalCost = 10 * Math.Pow(crystals,2) - Math.Pow(monstersSlain, 2);
				if(crystalCost < 0){
					crystalCost = 0;
				}
			}
		}
		RefreshValues();
		RefreshLabels();
	}

	private void RefreshValues(){
		if(monsterDead){
			monstersSlain++;
			monsterMaxHealth = crystals * 10 + monstersSlain;
			monsterHealth = monsterMaxHealth;	
			monsterDead = false;
		}
		crystalCost = 10 * Math.Pow(crystals,2) - Math.Pow(monstersSlain, 2); 
		if(crystalCost < 0){
			crystalCost = 0;
		}
		manaIncreaseForSlayingMonster = monsterMaxHealth * 0.01;
		dmg = crystals;
		manaCost = crystals * 10 / maxMana;
		mps = crystals * monstersSlain / maxMana + 1;
		maxMana = 100 + monstersSlain * manaIncreaseForSlayingMonster;	
		// dps = maxMana;	
	}
	private void RefreshLabels(){
		manaLabel.Text = Math.Round(mana,2) + " Mana";
		maxManaLabel.Text = Math.Round(maxMana) + " Max Mana";
		crystalLabel.Text = Math.Round(crystals) + " Crystals";
		monsterSlainLabel.Text = monstersSlain + " Monsters slain";
		monsterMaxHPLabel.Text = Math.Round(monsterMaxHealth) + " Monster Max HP";
		crystalCostLabel.Text = Math.Round(crystalCost) + " Crystal cost";
		monsterHPBar.Value = monsterHealth;
		monsterHPBar.MaxValue = monsterMaxHealth;
	}
	
	
}






