using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Brush : MonoBehaviour
{
	[SerializeField] private Transform _brush;
	[SerializeField] private int _brushSize = 5;
	[SerializeField] private Slider _sliderSize;
	[SerializeField] private Button _ButtonSize;

	public Color myColor;

	private Renderer _renderer;
	private Color[] _colors;
	private float _brushHeight;

	private RaycastHit _touch;
	private Canvas _canvas;
	private Vector2 _touchPos, _lastTouchPos;
	private bool _touchedLastFrame;
	private Quaternion _lastTouchRot;


	// Start is called before the first frame update
	void Start()
	{
		_renderer = _brush.GetComponent<Renderer>();
		_renderer.material.color = myColor;
		//Array mit der Farbe c auf b * h viele Pixel
		_colors = Enumerable.Repeat(_renderer.material.color, _brushSize * _brushSize).ToArray();
		_brushHeight = _brush.localScale.y;
	}

	// Update is called once per frame
	void Update()
	{
		//Teste, ob Canvas beruehrt wird
		Draw();

	}

	private void Draw()
	{

		//.Raycast(origin, direction,...)
		if (Physics.Raycast(_brush.position, transform.up, out _touch, _brushHeight))
		{

			//wird Canvas beruehrt?
			if (_touch.transform.CompareTag("Canvas"))
			{
				//Kontrolle, ob es das Canvas ist
				if (_canvas == null)
				{
					_canvas = _touch.transform.GetComponent<Canvas>();
				}

				//Punkt, wo Marker das Canvas beruehrt
				_touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

				//umwandeln von Koordinaten zu x,y Pixeln
				var x = (int)(_touchPos.x * _canvas.textureSize.x - (_brushSize / 2));
				var y = (int)(_touchPos.y * _canvas.textureSize.y - (_brushSize / 2));

				//draw verlassen, wenn außerhalb des Boards
				if (y < 0 || y > _canvas.textureSize.y || x < 0 || x > _canvas.textureSize.x) return;


				if (_touchedLastFrame)
				{
					_canvas.texture.SetPixels(x, y, _brushSize, _brushSize, _colors);

					//Interpolation von 0.01% bis 1.00f => 100% von letzten Punkt, zum aktuellen
					for (float f = 0.01f; f < 1.00f; f += 0.01f)
					{
						var lerpX = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
						var lerpY = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
						_canvas.texture.SetPixels(lerpX, lerpY, _brushSize, _brushSize, _colors);
					}

					//verhindern, dass der Pinsel sich dreht beim Beruehren
					transform.rotation = _lastTouchRot;

					_canvas.texture.Apply();
				}

				//wenns beruehrt wird
				_lastTouchPos = new Vector2(x, y);
				_lastTouchRot = transform.rotation;
				_touchedLastFrame = true;
				return;
			}
		}

		_canvas = null;
		_touchedLastFrame = false;
	}

	void OnCollisionEnter(Collision col)
	{
			//wird Canvas beruehrt?
			if (col.gameObject.tag == "Color")
			{
			myColor = col.gameObject.GetComponent<Renderer>().material.color;
			_renderer.material.color = myColor;
			_colors = Enumerable.Repeat(myColor, _brushSize * _brushSize).ToArray();
		}
	}
	
	public void changeSize(){
		_brushSize = (int)_sliderSize.value;
		_colors = Enumerable.Repeat(_renderer.material.color, _brushSize * _brushSize).ToArray();
	}
	
}
