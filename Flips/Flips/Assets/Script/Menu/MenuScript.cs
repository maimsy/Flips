using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	Rect title;
	Rect firstButton;
	Rect secondButton;
	Rect thirdButton;
	Rect fourthButton;
	
	Rect copyBox;
	float boxOffsetWidth;
	float boxOffsetHeight;
	float titleBoxHeight;
	float boxPosWidth;
	float boxWidth;
	float boxHeight;
	float posIn;
	float posOut;
	float offset;
	public float ratio;
	public Font font;
	public GUIStyle style = new GUIStyle();
	public GUIStyle buttonStyle = new GUIStyle();
	GUIStyle footer = new GUIStyle();
	
	enum Menu{
		First,Second,Score,Credits,Rest
	}
	Menu current;
	bool firstMenu;
	void Start () {
		style.font = font;
		style.fontSize = Screen.width/6;
		style.alignment = TextAnchor.MiddleCenter;

		buttonStyle.font = font;
		buttonStyle.fontSize = Screen.width/10;
		buttonStyle.alignment = TextAnchor.MiddleCenter;
		
		footer.font = font;
		footer.fontSize = Screen.width/30;
		footer.alignment = TextAnchor.MiddleCenter;
		
		float titleBoxWidth = Screen.width / 3 * 2;		//All boxes width
		titleBoxHeight = Screen.height / 4;
		float titlePosWidth = Screen.width/2 - titleBoxWidth/2; 
		
		boxWidth = Screen.width/2;
		boxHeight = Screen.height/8;
		boxPosWidth = Screen.width/4;

		
		offset = Screen.height / 8;
		
		title = new Rect(titlePosWidth, offset, titleBoxWidth,titleBoxHeight);
		firstButton= 	new Rect(boxPosWidth,titleBoxHeight+offset,boxWidth,boxHeight);
		secondButton = 	new Rect(boxPosWidth,titleBoxHeight+boxHeight+offset,boxWidth,boxHeight);
		thirdButton = 	new Rect(boxPosWidth,titleBoxHeight+boxHeight*2+offset,boxWidth,boxHeight);
		fourthButton =	new Rect(boxPosWidth,titleBoxHeight+boxHeight*3+offset,boxWidth,boxHeight);
		copyBox = new Rect(boxPosWidth,Screen.height - boxHeight/2 ,boxWidth,boxHeight/3 );  
		current = Menu.Rest;
		posIn = boxPosWidth;
		posOut = boxPosWidth - Screen.width;
		firstMenu = true;
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.backgroundColor = Color.yellow;
		GUI.Box (title,"Flips",style); //position,content,style
		
		if((firstMenu&&current == Menu.Rest) ||current == Menu.First||current == Menu.Second  || current == Menu.Credits){
			firstButton= 	new Rect(boxPosWidth,titleBoxHeight+offset,boxWidth,boxHeight);
			secondButton = 	new Rect(boxPosWidth,titleBoxHeight+boxHeight+offset,boxWidth,boxHeight);
			thirdButton = 	new Rect(boxPosWidth,titleBoxHeight+boxHeight*2+offset,boxWidth,boxHeight);
			fourthButton = new Rect(boxPosWidth, titleBoxHeight+boxHeight*3+offset,boxWidth,boxHeight);
			GUI.backgroundColor = Color.magenta;
			
			if(GUI.Button (firstButton,"Play",buttonStyle))
			{
				current = Menu.Second;
			}
			if(GUI.Button (secondButton,"Score",buttonStyle))
			{
				print ("Score");
				current = Menu.Score;
			}
			if(GUI.Button (thirdButton,"Quit",buttonStyle))
			{
				Application.Quit ();
				
			}
			if(GUI.Button (fourthButton,"Credits",buttonStyle))
			{  
				print ("Credits");
				current = Menu.Credits;
			}
		}
		
		if((!firstMenu &&current == Menu.Rest)   ||current == Menu.Second  ){
			firstButton= 	new Rect(boxPosWidth + Screen.width,titleBoxHeight+offset,boxWidth,boxHeight);
			secondButton = 	new Rect(boxPosWidth + Screen.width,titleBoxHeight+boxHeight+offset,boxWidth,boxHeight);
			thirdButton = 	new Rect(boxPosWidth + Screen.width,titleBoxHeight+boxHeight*2+offset,boxWidth,boxHeight);
			fourthButton =	new Rect(boxPosWidth + Screen.width,titleBoxHeight+boxHeight*3+offset,boxWidth,boxHeight);
			
			GUI.backgroundColor = Color.magenta;
			if(GUI.Button (firstButton,"Easy",buttonStyle))
			{
				Application.LoadLevel(2);
			}
			if(GUI.Button (secondButton,"Medium",buttonStyle))
			{
				Application.LoadLevel(3);
			}
			if(GUI.Button (thirdButton,"Hard",buttonStyle))
			{
				Application.LoadLevel(4);
			}
			if(GUI.Button (fourthButton,"Back",buttonStyle))
			{
				current = Menu.First;
			}
			
			
			if(!firstMenu &&  current == Menu.Credits){
			
			 
			Rect creditRec1 = new Rect(boxPosWidth + Screen.width,titleBoxHeight+offset,boxWidth,boxHeight);
			Rect creditRec2 = new Rect(boxPosWidth + Screen.width,titleBoxHeight+boxHeight+offset,boxWidth,boxHeight);
			Rect creditRec3 = new Rect(boxPosWidth + Screen.width,titleBoxHeight+boxHeight*2+offset,boxWidth,boxHeight);
			Rect BackRec4 = new Rect(boxPosWidth + Screen.width,titleBoxHeight+boxHeight*3+offset,boxWidth,boxHeight);
		
			GUI.Box (creditRec1,"Lucas",buttonStyle);
			GUI.Box (creditRec2,"Maimuna",buttonStyle);	 
			GUI.Box (creditRec3," ",buttonStyle); 
				 
			if(GUI.Button (BackRec4,"Back",buttonStyle))
			{
				current = Menu.First;
			}
				Debug.Log("huzzah in wrong place ");
			 
				 
			}
				

			if(  current == Menu.Score){
			
			 
			Rect creditRec1 = new Rect(boxPosWidth + Screen.width,titleBoxHeight+offset,boxWidth,boxHeight);
			Rect creditRec2 = new Rect(boxPosWidth + Screen.width,titleBoxHeight+boxHeight+offset,boxWidth,boxHeight);
			Rect creditRec3 = new Rect(boxPosWidth + Screen.width,titleBoxHeight+boxHeight*2+offset,boxWidth,boxHeight);
			Rect BackRec4 = new Rect(boxPosWidth + Screen.width,titleBoxHeight+boxHeight*3+offset,boxWidth,boxHeight);
		
			GUI.Box (creditRec1,"hghjg",buttonStyle); Debug.Log("huzzah in right place");
//			GUI.Box (creditRec2,PlayerPrefs.GetInt("Player score").ToString("0.00"),buttonStyle);	 
//			GUI.Box (creditRec3,PlayerPrefs.GetInt("Player score").ToString("0.00"),buttonStyle); 			 
 		 		if(GUI.Button (BackRec4,"Back",buttonStyle))
			{
				current = Menu.First;
			}
		}
		
		
		
		

	
		
		
		GUI.Box (copyBox,"Metropolia Portal 2013",footer);
		
		
		if(current == Menu.First){
			ratio += Time.deltaTime;
			boxPosWidth = Mathf.Lerp(boxPosWidth ,posIn,ratio); //  transform.position, target.position(i wanna reach),Time.deltaTime * smooth);
			if(ratio >= 0.8f){
				ratio = Time.deltaTime;
				current = Menu.Rest;
				firstMenu = true;
			}
		}
		 if(current == Menu.Second){
			ratio += Time.deltaTime;
			boxPosWidth = Mathf.Lerp(boxPosWidth ,posOut,ratio);
			if(ratio >= 0.8f){
				ratio = Time.deltaTime;
				current = Menu.Rest;
				firstMenu = false;
			}
		}

		
		if(current == Menu.Score){
			ratio += Time.deltaTime;
			boxPosWidth = Mathf.Lerp(boxPosWidth ,posOut,ratio);
			if(ratio >= 0.8f){
				ratio = Time.deltaTime;
				current = Menu.Rest;
				firstMenu = false;
			}
		}
		
		else if(current == Menu.Credits){
			 
			ratio += Time.deltaTime;
			boxPosWidth = Mathf.Lerp(boxPosWidth ,posOut,ratio);
			if(ratio >= 0.8f){
				ratio = Time.deltaTime; 
				firstMenu = false;
			}
		}
	}
		
}}


