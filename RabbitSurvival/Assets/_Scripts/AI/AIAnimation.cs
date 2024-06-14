using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void IdleWalk(float _dir)
    {
        animator.SetFloat("dir", _dir);
    }
}
