using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ErrorCanvas : MonoBehaviour
{
    public Text errorText;
    public Button okay;
    public Text Header;

    // Start is called before the first frame update
    void Start()
    { 
		okay.onClick.AddListener(delegate
        {
            //closeError();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeError()
    {
        this.gameObject.SetActive(false);
        
    }

    public void setError(string tex, string header = "Fehler")
    {
        this.gameObject.SetActive(true);
        errorText.text = tex;
        Header.text = header;
    }

}
