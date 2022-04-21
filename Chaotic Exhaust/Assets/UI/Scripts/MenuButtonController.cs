using System;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PointerEnterAnimation()
    {
        _animator.SetBool("selected", true);
    }
    public void PointerExitAnimation()
    {
        _animator.SetBool("selected", false);
    }
    public void PointerClickAnimation()
    {
        _animator.SetBool("click", true);
    }
}
