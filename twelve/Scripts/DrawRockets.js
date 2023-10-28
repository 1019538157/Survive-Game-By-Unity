@script ExecuteInEditMode ()
var rocketTexture : Texture2D;
var posX : float = 0;
var posY : float = 68;
var rocketWidth : float = 12;

private var maxRockets : int = 0;
private var rocketCount : int = 20;



function Start()
{
	maxRockets = rocketTexture.width / rocketWidth;	
}
function OnGUI()
{
	GUI.BeginGroup(Rect(posX,Screen.height - posY,rocketTexture.width - ((maxRockets - rocketCount) * rocketWidth), rocketTexture.height));
		GUI.DrawTexture(Rect(0,0,rocketTexture.width, rocketTexture.height), rocketTexture);
	GUI.EndGroup();
			
}

function UpdateRockets(input : int)
{
	rocketCount = input;
}