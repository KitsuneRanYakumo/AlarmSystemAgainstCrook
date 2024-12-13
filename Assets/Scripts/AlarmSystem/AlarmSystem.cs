using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _speedIncreaseVolume = 0.05f;
    [SerializeField] private int _delayBetweenChangeVolume = 1;

    private AudioSource _audioSource;
    private ProtectedZone _zone;
    private WaitForSecondsRealtime _wait;
    private Coroutine _currentCoroutine;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private void OnEnable()
    {
        _zone.CrookCome += OnAlarm;
        _zone.CrookGone += OffAlarm;
    }

    private void OnDisable()
    {
        _zone.CrookCome -= OnAlarm;
        _zone.CrookGone -= OffAlarm;
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _zone = GetComponentInChildren<ProtectedZone>();
    }

    private void Start()
    {
        _audioSource.volume = 0;
        _wait = new WaitForSecondsRealtime(_delayBetweenChangeVolume);
    }

    private void OnAlarm()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(IncreaseVolume());
    }

    private void OffAlarm()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(DecreaseVolume());
    }

    private IEnumerator IncreaseVolume()
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        for (float i = _minVolume; i < _maxVolume; i += _speedIncreaseVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _speedIncreaseVolume);
            yield return _wait;
        }
    }

    private IEnumerator DecreaseVolume()
    {
        for (float i = _maxVolume; i > _minVolume; i -= _speedIncreaseVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _speedIncreaseVolume);
            yield return _wait;
        }

        if (_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }
    }
}