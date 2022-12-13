using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action DamageEvent;
    public event Action DeathEvent;

    #region Health Data

    [SerializeField] int _healthMaximum = 100;
    int _healthCurrent = 0;
    #endregion

    public bool IsDead() => _healthCurrent == 0;
    // Start is called before the first frame update
    void Start()
    {
        HealthReset();
        if(gameObject.CompareTag("Player"))
        {
            UIController.Instance._healthSlider.maxValue = _healthMaximum;
            UIUpdate();
        }
    }

    // Update is called once per frame
    public void HealthUpdate(int update)
    {
        if(_healthCurrent == 0)
        {
            return;// U R DEAD
        }
        if(update > 0)
        {
            _healthCurrent = Mathf.Min(_healthCurrent + update, _healthMaximum);
            //Do not overdo health at max health
        }else if(update < 0)
        {
            _healthCurrent = Mathf.Max(_healthCurrent + update, 0);
            // do not go below zero
            DamageEvent?.Invoke();
            if(IsDead())
            {
                DeathEvent?.Invoke();
            }
        }
        if(gameObject.CompareTag("Player"))
        {
            UIUpdate();
        }

    }
    public void HealthReset()
    {
        _healthCurrent = _healthMaximum;
    }
    public void UIUpdate()
    {
        UIController.Instance._healthText.text = _healthCurrent.ToString();
        UIController.Instance._healthSlider.value = _healthCurrent;
    }
}
