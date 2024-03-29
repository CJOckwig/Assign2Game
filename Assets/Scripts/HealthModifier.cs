using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModifier : MonoBehaviour
{

    [SerializeField] int _healthValue = 0;
    [SerializeField] float _destroyTime = 0.0f;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if(!other.gameObject.CompareTag("Player")){return;}

        if(other.TryGetComponent<Health>(out Health health))
        {
            health.HealthUpdate(_healthValue);
        }
        if(!gameObject.CompareTag("Pickup")) {return;}
        Destroy(gameObject, _destroyTime);
    }
}
