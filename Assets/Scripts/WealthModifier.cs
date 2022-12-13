using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WealthModifier : MonoBehaviour
{
    [SerializeField] int _wealthValue = 0;
    [SerializeField] float _destroyTime = 0.0f;

    private void OnTriggerEnter(Collider other) {
        if(!other.gameObject.CompareTag("Player")){return;}

        if(other.TryGetComponent<Wealth>(out Wealth wealth))
        {
            wealth.WealthUpdate(_wealthValue);
        }
        if(!gameObject.CompareTag("Pickup")){return;}
        Destroy(gameObject, _destroyTime);
    }
}
