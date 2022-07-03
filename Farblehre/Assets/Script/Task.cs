using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Task : MonoBehaviour
{
	[SerializeField] ErrorCanvas error;
	[SerializeField] Button _errorButton;
	[SerializeField] ControlPanel control;
	[SerializeField] Button _mischen;
	[SerializeField] Canvas _brushSize;
	
	
	private bool _aufgabe1 = false;
	private bool _aufgabe2 = false;
	private bool _aufgabe3 = false;
	private bool _cmyk = false;
	private bool _aufgabe4 = false;
	private bool _aufgabe5 = false;
	private bool _aufgabe6 = false;
	
	private bool _counter = false;
	private bool _finish = false;
	private bool _drawing = false;
	
	

    // Start is called before the first frame update
    void Start()
    {
		control.stopInteraction();
		error.setError("Vor dir siehst du das Controll Panel. Du kannst die Slider verschieben, um so verschiedene Farben zu mischen. Wenn du den Button Mischen drückst, erhält der Farbfleck neben dem Panel die Farbe.", "Hallo");
		_errorButton.onClick.AddListener(delegate
        {	
			error.closeError();
			showTask();
			
		});
		_mischen.onClick.AddListener(delegate{
			isTaskCorrect();
			control.changeColor();
		});
		_brushSize.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void showTask(){
		if(_counter == false)
		{
			if(_aufgabe1 == false) //erste Aufgabe unerledigt ist
			{
				error.setError("Rot, Grün und Blau sind Primärfarben sie bestehen zu 100% aus der jeweiligen Farbe. Für das Farbsystem RGB heißt das, die Farbe hat einen Wert von 255.", "Mische Rot");
				_counter = true;
			}else if(_aufgabe2 == false)//zweite Aufgabe unerledigt ist
			{
				error.setError("Genauso wie du Rot gemischt hast, kannst du jetzt auch Grün als Primärfarbe mischen.", "Mische Grün");
				_counter = true;
			}
			else if(_aufgabe3 == false)//dritte Aufgabe unerledigt ist
			{
				error.setError("Um die drei Primärfarben des RGB Farbsystems vollständig zu haben, fehlt dir nur noch Blau.", "Mische Blau");
				_counter = true;
			}
			else if(_cmyk == false)//CMYK erklaeren
			{
				error.setError("Neben dem Farbsystem RGB gibt es das Farbsystem CMYK mit den Primärfarben Cyan, Magenta und Yellow. K ist die Keyfarbe schwarz, um alle Farbwerte abbilden zu können. Die Primärfarben des einen Systems sind die Sekundärfarben des anderen Systems.", "CMYK");
				_cmyk = true;
			}
			else if(_aufgabe4 == false)//vierte Aufgabe unerledigt ist
			{
				error.setError("Um die Sekundärfarben zu erhalten mischt du jeweils zwei Farben 1:1.", "Mische Cyan");
				_counter = true;
			}
			else if(_aufgabe5 == false)//fuenfte Aufgabe unerledigt ist
			{
				error.setError("Genauso wie du eben Cyan gemischt hast, gehst du jetzt bei Magenta vor.", "Mische Magenta");
				_counter = true;
			}
			else if(_aufgabe6 == false)//sechste Aufgabe unerledigt ist
			{
				error.setError("Dir fehlt nur noch eine Farbe: Yellow. Das schaffst du.", "Mische Yellow");
				_counter = true;
			}
			else{
				if(_finish == false){
					error.setError("Du hast alles Wissen, um los zu legen und kreativ zu werden.", "Glückwunsch");
					_finish = true;
				} else if (_finish == true && _drawing == false){
					error.setError("Falls du es nicht schon ausprobiert hast: Du kannst an der Leinwand links neben dem Tisch malen. In dem du den Stift in die Farbe fallen lässt nimmst du sie auf, danach kannst du mit dem Stift einfach an der Wand malen. Unten am Tisch befindet sich ein Panel, an dem du die Strichdicke einstellen kannst.", "Freies Malen");
					_drawing = true;
					_brushSize.gameObject.SetActive(true);
				} else{
				control.startInteraction();
				return;
				}
			}
		
		} else{
			control.startInteraction();
			return;
		}
	}
	
	private void isTaskCorrect(){
		
		if(_aufgabe1 == false) //erste Aufgabe unerledigt ist
		{
			if(control.getRed() == 255 && control.getGreen() == 0 && control.getBlue() == 0)
			{
				_aufgabe1 = true;
				_counter = false;
				error.setError("Du hast Rot korrekt gemischt.", "Prima");
				control.stopInteraction();
			} else{
				_counter = false;
				error.setError("Das war leider kein Rot als Primärfarbe.", "Leider falsch.");
				control.stopInteraction();
			}
		} 
		else if(_aufgabe2 == false) //zweite  Aufgabe unerledigt ist
		{
			if(control.getRed() == 0 && control.getGreen() == 255 && control.getBlue() == 0)
			{
				_aufgabe2 = true;
				_counter = false;
				error.setError("Du hast Grün korrekt gemischt.", "Prima");
				control.stopInteraction();
			} else{
				_counter = false;
				error.setError("Das war leider kein Grün als Primärfarbe.", "Leider falsch.");
				control.stopInteraction();
			}
		}
		else if(_aufgabe3 == false) //dritte  Aufgabe unerledigt ist
		{
			if(control.getRed() == 0 && control.getGreen() == 0 && control.getBlue() == 255)
			{
				_aufgabe3 = true;
				_counter = false;
				error.setError("Du hast Blau korrekt gemischt.", "Prima");
				control.stopInteraction();
			} else{
				_counter = false;
				error.setError("Das war leider kein Blau als Primärfarbe.", "Leider falsch.");
				control.stopInteraction();
			}
		}
		else if(_aufgabe4 == false) //vierte  Aufgabe unerledigt ist
		{
			if(control.getRed() == 0 && control.getGreen() == 255 && control.getBlue() == 255)
			{
				_aufgabe4 = true;
				_counter = false;
				error.setError("Du hast Cyan korrekt gemischt.", "Prima");
				control.stopInteraction();
			} else{
				_counter = false;
				error.setError("Das war leider kein Cyan. Tipp: Cyan ist Blau-Grün", "Leider falsch.");
				control.stopInteraction();
			}
		}
		else if(_aufgabe5 == false) //fuenfte  Aufgabe unerledigt ist
		{
			if(control.getRed() == 255 && control.getGreen() == 0 && control.getBlue() == 255)
			{
				_aufgabe5 = true;
				_counter = false;
				error.setError("Du hast Magenta korrekt gemischt.", "Prima");
				control.stopInteraction();
			} else{
				_counter = false;
				error.setError("Das war leider kein Magenta. Tipp: Magenta ist der Farbton der Telekom.", ":(");
				control.stopInteraction();
			}
		}
		else if(_aufgabe6 == false) //sechste  Aufgabe unerledigt ist
		{
			if(control.getRed() == 255 && control.getGreen() == 255 && control.getBlue() == 0)
			{
				_aufgabe6 = true;
				_counter = false;
				error.setError("Du hast Yellow korrekt gemischt.", "Prima");
				control.stopInteraction();
			} else{
				_counter = false;
				error.setError("Nicht auf den letzten Metern scheitern.", "Leider falsch.");
				control.stopInteraction();
			}
		}
		else{
			error.setError("Du hast bereits alle Aufgaben geschafft.", "Tob dich aus");
			
		}
	}
}
