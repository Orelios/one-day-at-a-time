using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Breathing : MonoBehaviour
{
    [SerializeField] private GameObject grows, ui;
    private float BeatManagerStep = 0.5f;
    [SerializeField]
    private float breathCount = 4, _leewayCount = 2;
    private float _breathDuration, _leewayDuration, _inhaleLeewayTimer, _holdLeewayTimer;
    private bool _inhaling, _exhaling, _holding, _inhaleFull, _holdFull;
    private Vector2 _startScale = new Vector2(1, 1), _endScale = new Vector2(5, 5);
    private float inhalePercentageCompleted, exhalePercentageCompleted, inhaleCount, exhaleCount, holdCount;
    private Coroutine exhaleCo, inhaleCo, holdCo, inhaleLeewayCo, holdLeewayCo;
    private bool upPressed, downPressed;
    [SerializeField] private Sprite[] _instructionArrowSprites;
    [SerializeField] private Sprite[] _correctArrowSprites;
    [SerializeField] private Sprite[] _incorrectArrowSprites;

    void Start()
    {
        _breathDuration = (60f / (BeatManager.Instance.GetBPM() * BeatManagerStep)) * breathCount;
        _leewayDuration = (60f / (BeatManager.Instance.GetBPM() * BeatManagerStep)) * _leewayCount;
        //inhaleCo = Inhale();
        //exhaleCo = Exhale();
        //SetHoldUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upPressed = true;
            if (!downPressed)
            {
                CheckInhale();
            }
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            upPressed = false;
            StopInhale();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            downPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            downPressed = false;
            _holdFull = false;
            StopHold();
            StopExhale();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && upPressed) // Down arrow pressed whil Up arrow is STILL pressed
        {
            if (!_inhaleFull) // Down arrow is pressed too early
            {
                StopInhale();
                return;
            }
            CheckHold();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && downPressed)
        {
            upPressed = false;
            CheckExhale();
        }
    }

    private void StopInhale()
    {
        grows.transform.localScale = _startScale;
        _inhaling = false;
        _inhaleFull = false;
        if (inhaleCo != null) { StopCoroutine(inhaleCo);}
    }

    private void StopExhale()
    {
        grows.transform.localScale = _startScale;
        _exhaling = false;
        if (exhaleCo != null) { StopCoroutine(exhaleCo);}
    }

    private void StopHold()
    {
        _holding = false;
        if (holdCo != null) { StopCoroutine(holdCo);}
        //_holdFull = false;
        //transform.localScale = _startScale;
    }

    private void CheckInhale()
    {
        if (!_inhaling)
        {
            _inhaling = true;
            inhaleCo = StartCoroutine(Inhale());
        }
    }

    private void CheckExhale()
    {
        if (!_exhaling && _holdFull)
        {
            _holding = false;
            _holdFull = false;
            _exhaling = true;
            exhaleCo = StartCoroutine(Exhale());
        }
        else // exhaled too early
        {
            ResetState();
        }
    }

    private void CheckHold()
    {
        if (!_holding && _inhaleFull)
        {
            _inhaleFull = false;
            _holding = true;
            holdCo = StartCoroutine(Hold());
        }
    }

    private void ResetState()
    {
        grows.transform.localScale = _startScale;
        if (inhaleCo != null) { StopCoroutine(inhaleCo);}
        _inhaling = false;
        _inhaleFull = false;

        if (holdCo != null) { StopCoroutine(holdCo);}
        _holding = false;
        _holdFull = false;

        if (exhaleCo != null) { StopCoroutine(exhaleCo);}
        _exhaling = false;
    }

    private IEnumerator Inhale()
    {
        inhaleCount = 0;
        while (inhaleCount < _breathDuration)
        {
            inhaleCount += Time.deltaTime;
            inhalePercentageCompleted = inhaleCount / _breathDuration;
            grows.transform.localScale = Vector3.Lerp(_startScale, _endScale, inhalePercentageCompleted);
            if (inhalePercentageCompleted >= 1.0f)
            {
                _inhaling = false;
                _inhaleFull = true;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                //upPressed = false;
                StopInhale();
            }
            yield return null;
        }
        SetHoldUI();
        if ((inhaleCount >= _breathDuration) && !downPressed)
        {
            inhaleLeewayCo = StartCoroutine(InhaleLeewayTimer());
        }
    }

    private IEnumerator Exhale()
    {
        exhaleCount = 0;
        while (exhaleCount < _breathDuration)
        {
            exhaleCount += Time.deltaTime;
            exhalePercentageCompleted = exhaleCount / _breathDuration;
            grows.transform.localScale = Vector3.Lerp(_endScale, _startScale, exhalePercentageCompleted);
            if (exhalePercentageCompleted >= 1.0f)
            {
                _exhaling = false;
                _holdFull = false;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                StopExhale();
            }
            yield return null;
        }
        SetInhaleUI();
    }

    private IEnumerator Hold()
    {
        holdCount = 0;
        while (holdCount < _breathDuration)
        {
            holdCount += Time.deltaTime;
            if (holdCount >= _breathDuration)
            {
                _holdFull = true;
            }
            // if Up/Down arrow is released WHILE still holding (i.e holdCount < _breathDuration), reset
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                //downPressed = false;
                ResetState();
            }
            yield return null;
        }
        SetExhaleUI();
        if ((holdCount >= _breathDuration) && upPressed)
        {
            holdLeewayCo = StartCoroutine(HoldLeewayTimer());
        }
    }

    private IEnumerator InhaleLeewayTimer()
    {
        _inhaleLeewayTimer = 0;
        while (_inhaleLeewayTimer < _leewayDuration)
        {
            _inhaleLeewayTimer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                StopCoroutine(inhaleLeewayCo);
            }
            yield return null;
        }
        if ((_inhaleLeewayTimer >= _leewayDuration) && !downPressed)
        {
            ResetState();
        }
    }

    private IEnumerator HoldLeewayTimer()
    {
        _holdLeewayTimer = 0;
        while (_holdLeewayTimer < _leewayDuration)
        {
            _holdLeewayTimer += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                StopCoroutine(holdLeewayCo);
            }
            yield return null;
        }
        if ((_holdLeewayTimer >= _leewayDuration) && upPressed)
        {
            ResetState();
        }
    }

    private void SetInhaleUI()
    {
        ui.transform.GetChild(1).GetComponent<Image>().sprite = _instructionArrowSprites[0];
        ui.transform.GetChild(2).GetComponent<Image>().sprite = _instructionArrowSprites[2];
        ui.transform.GetChild(3).GetComponent<Image>().sprite = _instructionArrowSprites[2];
        ui.transform.GetChild(4).GetComponent<Image>().sprite = _instructionArrowSprites[0];
        ui.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = "Inhale";
    }

    private void SetExhaleUI()
    {
        ui.transform.GetChild(1).GetComponent<Image>().sprite = _instructionArrowSprites[1];
        ui.transform.GetChild(2).GetComponent<Image>().sprite = _instructionArrowSprites[2];
        ui.transform.GetChild(3).GetComponent<Image>().sprite = _instructionArrowSprites[2];
        ui.transform.GetChild(4).GetComponent<Image>().sprite = _instructionArrowSprites[1];
        ui.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = "Exhale";
    }

    private void SetHoldUI()
    {
        ui.transform.GetChild(1).GetComponent<Image>().sprite = _instructionArrowSprites[2];
        ui.transform.GetChild(2).GetComponent<Image>().sprite = _instructionArrowSprites[2];
        ui.transform.GetChild(3).GetComponent<Image>().sprite = _instructionArrowSprites[2];
        ui.transform.GetChild(4).GetComponent<Image>().sprite = _instructionArrowSprites[2];
        ui.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = "Hold";
    }
}
