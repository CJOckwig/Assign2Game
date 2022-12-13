using System;
using UnityEngine;
[Serializable]
public class Attack
{

    
    #region Animation Data
    // Start is called before the first frame update
    [field: SerializeField] public string AnimationName {get;private set;}
    [field: SerializeField] public float TransitionTime {get; private set;} = .1f;
    #endregion

    #region Combo Attack Data
    [field: SerializeField] public int ComboIndex {get;private set;} = -1;
    [field: SerializeField] public float ComboTime {get; private set;} = 0.0f;
    #endregion

    #region Force Data
    [field: SerializeField] public float Force {get;private set;} = 15.0f;
    [field: SerializeField] public float ForceTime {get; private set;} = .35f;
    [field:SerializeField] public float Knockback {get; private set; } = 10.0f;
    #endregion


    #region Attack Data
    [field: SerializeField] public int Damage {get; private set;} = -10;
    #endregion
}
