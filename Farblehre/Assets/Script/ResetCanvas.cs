using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetCanvas : MonoBehaviour
{
	public Button resetMenue;
	[SerializeField] Canvas resetCanvas;
	
	void Start()
	{
		resetCanvas.gameObject.SetActive(false);
	}
	
	public void openMenue(){
		resetCanvas.gameObject.SetActive(true);
	}
	
	public void resetScene(){
		SceneManager.LoadScene("Start");
	}
	
	public void goOn(){
		resetCanvas.gameObject.SetActive(false);
	}
}
