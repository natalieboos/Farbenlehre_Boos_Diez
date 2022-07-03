using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    //[SerializeField] public Vector2 textureSize;
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(2048, 2048); //resolution
	private Texture2D _resetTexture;
	[SerializeField] private Button _reset;
	

    // Start is called before the first frame update
    void Start()
    {
        var r = GetComponent<Renderer>(); //Renderer
        //texture = new Texture2D((int)(2048 * textureSize.x), (int)(2048* textureSize.y));
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
		_resetTexture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        r.material.mainTexture = texture;
		
		_reset.onClick.AddListener(delegate
        {	
			resetTexture();
		});
    }
	
	public void resetTexture(){
		var r = GetComponent<Renderer>();
		texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
		r.material.mainTexture = texture;
	}
	
}
