using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Animator))]

public class Hand : MonoBehaviour
{
    //Animation
    public float animationSpeed;
    Animator animator;
    //SkinnedMeshRenderer mesh;
    private float _gripTarget;
    private float _triggerTarget;
    private float _gripCurrent;
    private float _triggerCurrent;
    private string _animatorGripParam = "Grip";
    private string _animatorTriggerParam = "Trigger";


    // Start is called before the first frame update
    void Start()
    {
        //Animation
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();

    }

    internal void SetGrip(float v)
    {
        _gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        _triggerTarget = v;
    }

    void AnimateHand()
    {
      if(_gripCurrent != _gripTarget)
        {
            _gripCurrent = Mathf.MoveTowards(_gripCurrent, _gripTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(_animatorGripParam, _gripCurrent);
        }

      if (_triggerCurrent != _triggerTarget)
          {
            _triggerCurrent = Mathf.MoveTowards(_triggerCurrent, _triggerTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(_animatorTriggerParam, _triggerCurrent);
          }
    }
}
