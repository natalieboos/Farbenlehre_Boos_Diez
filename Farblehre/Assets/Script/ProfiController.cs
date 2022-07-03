using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ProfiController : MonoBehaviour
{
	[SerializeField] Slider _red;
    [SerializeField] Slider _green;
    [SerializeField] Slider _blue;

    [SerializeField] Button _mix;

    [SerializeField] GameObject _colorObject;

    // Start is called before the first frame update
    void Start()
    {
	_mix.onClick.AddListener(delegate
        {
            _changeColor();
        });
        
    }

    private void _changeColor()
    {

        _colorObject.GetComponent<Renderer>().material.color = new Color(_colorConvert(_red.value), _colorConvert(_green.value), _colorConvert(_blue.value));
    }

    private float _colorConvert(float colorVal)
    {
        return (colorVal / 255.0f);
    }
}
