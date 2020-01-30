using Godot;
using System;

public class Clicker : Control
{
	private double value = 0.0;
	private double power = 1.0;
	public override void _Ready()
	{
		
	}

	private void _on_ClickButton_pressed()
	{
		value += power;
	}
}
