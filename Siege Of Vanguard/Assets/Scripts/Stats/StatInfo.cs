using UnityEngine;

public enum Stat
{
    Health,
    Attack,
    Defense,
    Speed,
    AttackSpeed,
}

public class StatInfo
{
    public Stat statType;
    public float statValue;
}
