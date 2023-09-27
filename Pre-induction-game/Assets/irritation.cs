using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microlight.MicroBar;
using System;

public class irritation : MonoBehaviour
{
    [SerializeField] MicroBar _irrBar;

    readonly float _maxIrr = 50;

    float _irr = 0f;

    int childCount;

    private void Awake()
    {
        _irrBar.Initialize(_irr);
    }

    private void Start()
    {

    }
    void Update()
    {
        childCount = transform.childCount;
        
        _irr = 10f * childCount;
        Debug.Log(_irr);

        if (_irr > _maxIrr)
        {
            _irr = _maxIrr;
        } else if (_irr >= 0)
        {
            _irrBar.UpdateHealthBar(_irr, true);
        }
    }
}
