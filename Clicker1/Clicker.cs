using Godot;
using System;

public class Clicker : Control
{
	private double value = 0.0;
	private double power = 1.0;
	private Label valueLabel;
	public override void _Ready()
	{
		valueLabel = (Label)GetNode("ValueDisplay");
	}

	private void _on_ClickButton_pressed()
	{
		value += power;
		RefreshLabel();
	}
	
	private void RefreshLabel(){
		valueLabel.Text = value + " Mana";
	}
}
