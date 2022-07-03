using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ControlPanel : MonoBehaviour
{

    [SerializeField] Slider Red;
    [SerializeField] Slider Green;
    [SerializeField] Slider Blue;

    [SerializeField] Button mix;

    [SerializeField] GameObject colorObject;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void changeColor()
    {

        colorObject.GetComponent<Renderer>().material.color = new Color(colorConvert(Red.value), colorConvert(Green.value), colorConvert(Blue.value));
    }

    private float colorConvert(float colorVal)
    {
        return (colorVal / 255.0f);
    }
	
	public void startInteraction(){
		mix.interactable = true;
		Red.interactable = true;
		Green.interactable = true;
		Blue.interactable = true;
	}
	
	public void stopInteraction(){
		mix.interactable = false;
		Red.interactable = false;
		Green.interactable = false;
		Blue.interactable = false;
	}
	
	public float getRed()
	{
		return Red.value;
	}
	
	public float getGreen()
	{
		return Green.value;
	}
	
	public float getBlue()
	{
		return Blue.value;
	}
	
}
