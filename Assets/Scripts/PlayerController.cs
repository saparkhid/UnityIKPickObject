using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cratePos;
    private Animator _animator;

    private Vector3 posLeftHandle;
    private Vector3 posRightHandle;
    private bool pickedUp = false;
    private bool drop = false;
    private Transform crate;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (layerIndex == 1 && pickedUp)
        {
            posRightHandle=crate.GetChild(1).position;
            posLeftHandle=crate.GetChild(2).position;
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand,1.0f);
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,1.0f);
            _animator.SetIKPosition(AvatarIKGoal.RightHand,posRightHandle);
            _animator.SetIKPosition(AvatarIKGoal.LeftHand,posLeftHandle);
        }
        if (layerIndex == 1 && drop)
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand,0.0f);
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,0.0f);
  
        }
    }

    public void StopWalking()
    {
       
        _animator.SetBool("stand",true);
        crate.parent = null;
        crate.gameObject.AddComponent<Rigidbody>();
        pickedUp = false;
        drop = true;
    }

    public void Pick(GameObject g)
    {
        g.transform.parent = cratePos;
        g.transform.localPosition = Vector3.zero;
        pickedUp = true;
        crate = g.transform;
       
    }
}
