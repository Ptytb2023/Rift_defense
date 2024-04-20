using System;
using UnityEngine;

[Serializable]
public class DataAnimator 
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public string Idel { get; private set; }
    [field: SerializeField] public  string ModeSearch { get; private set; }
    [field: SerializeField] public  string Dead { get; private set; }
    [field: SerializeField] public  float DelayDespawn { get; private set; }
    [field: SerializeField] public  float SpeedRotation { get; private set; }
    [field: SerializeField] public  Transform AnimationModel { get; private set; }
    [field: SerializeField] public  Transform Head { get; private set; }
}
