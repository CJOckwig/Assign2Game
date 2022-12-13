using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wealth : MonoBehaviour
{
    [SerializeField] int _wealthStarting = 0;
    int _wealthCurrent = 0;
    public bool IsBroke => _wealthCurrent == 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WealthUpdate(int update )
    {
        _wealthCurrent = Mathf.Max(_wealthCurrent + update, 0);
    }
    public void WealthReset()
    {
        _wealthCurrent = _wealthStarting;
    }
}
