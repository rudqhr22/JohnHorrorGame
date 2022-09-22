using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float FadeDuration = 1f;    
    public float DisplayImageDuration = 1f;
    public GameObject Player;
    public CanvasGroup ExitBackgroundImageCanvasGroup;

    bool _isPlayerAtExit = false;
    float _timer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            _isPlayerAtExit = true;
        }
    }

    private void Update()
    {
        if (_isPlayerAtExit)
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        _timer += Time.deltaTime;

        ExitBackgroundImageCanvasGroup.alpha = _timer / FadeDuration;

        if (_timer > FadeDuration + DisplayImageDuration)
        {
            Application.Quit();
        }
    }
}
