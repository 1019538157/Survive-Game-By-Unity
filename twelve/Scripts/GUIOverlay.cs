using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GUIOverlay : MonoBehaviour {
    
    public Texture2D guiOverlayTexture;
    private Rect position;
    
    // Use this for initialization
    void Start () {
        position = new Rect (5, (Screen.height - guiOverlayTexture.height)-5, guiOverlayTexture.width, guiOverlayTexture.height);
    }

    void OnGUI() {
        GUI.DrawTexture (position, guiOverlayTexture);
    }
}