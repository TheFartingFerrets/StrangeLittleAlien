using UnityEngine;
using System.Collections;

public class MyMenuManager : MonoBehaviour 
{
	public Font f;
	//public Font fontColor;
	public GUIStyle titleFont;
	
	public enum Menu 
	{
		MainMenu,
		NewGame,
		Continue
	}
	
	public Menu currentMenu;
	
	void OnGUI () 
	{
		if (!f) 
		{
			Debug.Log ("No font found, please assign one in the inspector");
			return;
		}
		
		GUILayout.BeginArea(new Rect(0,0,Screen.width, Screen.height));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.BeginVertical();
		GUILayout.FlexibleSpace();
		
		if(currentMenu == Menu.MainMenu) 
		{
			GUI.skin.font = f;
			GUI.color = Color.white;
			GUILayout.Label("Planet Breakout", titleFont);
			GUILayout.Space(15);
			
			if(GUILayout.Button("New Game", titleFont)) 
			{
				//Game.current = new Game();
				currentMenu = Menu.NewGame;
			}
			
			if(GUILayout.Button("Continue", titleFont)) 
			{
				//SaveLoad.Load();
				currentMenu = Menu.Continue;
			}
			
			if(GUILayout.Button("Quit", titleFont)) 
			{
				Application.Quit();
			}
		}
		
		else if (currentMenu == Menu.NewGame) 
		{
			// DISPLAYS THE DIFFERENT LEVELS BUTTONS FOR THE "NEWGAME" MENU
			if(GUILayout.Button("Level 1", titleFont))			// Displays the button for the "Peril Island" level
			{
				Application.LoadLevel(1);	// Load level no.1 as listed in the build settings
			}
			GUILayout.Space(4);
			
			if(GUILayout.Button("Level 2", titleFont))// Displays the button for the "Bodies in the Street" Level
			{
				Application.LoadLevel(2);	// Load level no.2 as listed in the build settings
			}
			GUILayout.Space(4);
			
			if(GUILayout.Button("Level 3", titleFont))// Displays the button for the "Sandswept" level --> Pass in the titleFont variable of type GUIStyle
			{
				Application.LoadLevel(3);	// Load level no.3 as listed in the build settings
			}
			GUILayout.Space(4);
			
//			if(GUILayout.Button("Tropical", titleFont))
//			{
//				Application.LoadLevel(4);	// Load level no.4 as listed in the build settings
//			}
//			GUILayout.Space(4);
			
			if(GUILayout.Button("Save", titleFont)) 
			{
				//Save the current Game as a new saved Game
				//SaveLoad.Save();
				
				//Move on to game...
				Application.LoadLevel(1);
			}
			GUILayout.Space(10);
			
			if(GUILayout.Button("Back", titleFont)) 
			{
				currentMenu = Menu.MainMenu;
			}
		}
		
		else if (currentMenu == Menu.Continue) 
		{
			GUILayout.Box("Select Save File", titleFont);
			GUILayout.Space(10);
			
			//foreach(Game g in SaveLoad.savedGames) 
			//{
			//if(GUILayout.Button(g.knight.name + " - " + g.rogue.name + " - " + g.wizard.name, titleFont)) 
			//{
			//Game.current = g;
			
			//Move on to game...
			//Application.LoadLevel(1);
			//}
			//}
			GUILayout.Space(10);
			
			if(GUILayout.Button("Back", titleFont)) 
			{
				currentMenu = Menu.MainMenu;
			}
		}
		
		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
}