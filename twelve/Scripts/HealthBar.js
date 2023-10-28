@script ExecuteInEditMode ()
var healthBarTexture : Texture2D;
private var position : Rect;
private var fraction : float;
    
function Start () {
    position = Rect (5+37, 
                         (Screen.height - healthBarTexture.height)-5-83, 
                         111, 29);
    fraction = 1.0f;
}

function OnGUI() {
    GUI.BeginGroup(Rect(position.x, position.y, fraction * position.width, position.height));
    GUI.DrawTexture (Rect(0, 0, fraction * position.width, position.height), healthBarTexture);
    GUI.EndGroup();
}


function UpdateHealth(frac : float) {
    fraction = frac;
}