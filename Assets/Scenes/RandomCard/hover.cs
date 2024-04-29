using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour
{
    private bool mosueOver;
    private Animator animator;
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    private void OnMouseOver() {
         //Debug.Log("1");
    }
    private void Update() {
        if (mosueOver) {
            OnMouseOver();
           
        } else {
           // Debug.Log("2");
        }
    }
}
