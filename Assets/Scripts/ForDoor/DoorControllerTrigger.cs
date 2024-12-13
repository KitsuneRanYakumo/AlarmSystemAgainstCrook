using UnityEngine;

public class DoorControllerTrigger : MonoBehaviour
{
    [SerializeField] private KeyCode _interactionButton = KeyCode.E;

    private Door _door;
    private bool _hasOpener = false;

    private void Awake()
    {
        _door = GetComponentInChildren<Door>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Key>())
            _hasOpener = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Key>())
            _hasOpener = false;
    }

    private void Update()
    {
        if (_hasOpener == false)
            return;

        if (_door.IsOpened == false && Input.GetKeyDown(_interactionButton))
        {
            _door.Open();
        }
        else if (_door.IsOpened && Input.GetKeyDown(_interactionButton))
        {
            _door.Close();
        }
    }
}