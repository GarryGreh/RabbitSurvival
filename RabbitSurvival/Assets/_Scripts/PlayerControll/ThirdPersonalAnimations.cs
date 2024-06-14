using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonalAnimations : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    //public void IdleWalk(bool _isIdle)
    //{
    //    animator.SetBool("isIdle", _isIdle);
    //}
    public void Dead(bool _isDead)
    {
        animator.SetBool("isDead", _isDead);
    }
    public void WalkIdleAnim(float _dir)
    {
        animator.SetFloat("dir", _dir);
    }
    //public void WalkRunAnim(float _speed)
    //{
    //    animator.SetFloat("speed", _speed);
    //}
    //public void Attack(int _index)
    //{
    //    animator.SetInteger("type", _index);
    //}
    //public void StopAttack()
    //{
    //    animator.SetInteger("type", 0);
    //}
}
