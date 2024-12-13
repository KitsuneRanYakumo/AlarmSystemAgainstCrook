using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    private Animator _animator;

    private readonly int OpenTrigger = Animator.StringToHash("Open");
    private readonly int CloseTrigger = Animator.StringToHash("Close");

    public bool IsOpened { get; private set; } = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        IsOpened = true;
        _animator.SetTrigger(OpenTrigger);
    }

    public void Close()
    {
        IsOpened = false;
        _animator.SetTrigger(CloseTrigger);
    }
}