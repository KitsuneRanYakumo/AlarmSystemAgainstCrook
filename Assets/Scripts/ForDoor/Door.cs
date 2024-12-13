using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    private readonly int _openTrigger = Animator.StringToHash("Open");
    private readonly int _closeTrigger = Animator.StringToHash("Close");

    private Animator _animator;

    public bool IsOpened { get; private set; } = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        IsOpened = true;
        _animator.SetTrigger(_openTrigger);
    }

    public void Close()
    {
        IsOpened = false;
        _animator.SetTrigger(_closeTrigger);
    }
}