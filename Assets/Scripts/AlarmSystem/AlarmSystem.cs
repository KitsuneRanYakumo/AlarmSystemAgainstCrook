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
        _zone.CrookCome += ChangeAlarm;
        _zone.CrookGone += ChangeAlarm;
    }

    private void OnDisable()
    {
        _zone.CrookCome -= ChangeAlarm;
        _zone.CrookGone -= ChangeAlarm;
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

    private void ChangeAlarm(bool isIncreasing)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ChangeVolume(isIncreasing));
    }

    private IEnumerator ChangeVolume(bool isIncreasing)
    {
        float targetValue = Utils.GetTargetValue(isIncreasing, _maxVolume, _minVolume);

        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        for (float i = Utils.GetSingOfNumber(isIncreasing) * _audioSource.volume; i < targetValue; i += _speedIncreaseVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetValue, _speedIncreaseVolume);
            yield return _wait;
        }

        if (_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }
    }
}