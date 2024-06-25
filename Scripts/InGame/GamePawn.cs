using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GamePawn : MonoBehaviour
{
    public float Hp = 10;
    public float MaxHp = 10;

    public float Dmg = 1;

    public float AttackSpeed = 0.5f;


    [SerializeField]
    private GamePawn _target;

    public GamePawn Target
    {
        get { return _target;}
        set 
        {
            OnChangeTarget?.Invoke();
            _target = value;
        }
    }

    public delegate void ChangeTargetHandler();
    public event ChangeTargetHandler OnChangeTarget;

    public delegate void AttackHandler();
    public event AttackHandler OnAttack;

    public delegate void GetDamageHandler();
    public event GetDamageHandler OnGetDamage;

    public delegate void DeathHandler();
    public event DeathHandler OnDeath;

    public delegate void RestoreHpHandler();
    public event RestoreHpHandler OnRestoreHp;


    public virtual void SetFromData(GamePawnData gamePawnData)
    {
        SetBaseData(gamePawnData);
    }

    public virtual void SetBaseData(GamePawnData gamePawnData)
    {
        MaxHp = gamePawnData.MaxHp;
        Dmg = gamePawnData.Dmg;
        AttackSpeed = gamePawnData.AttackSpeed;
    }

    public void StartCoroutines()
    {
        StartCoroutine(AttackSender());
        StartCoroutine(EverySecond());
    }

    public virtual void GetDamage(float dmg)
    {
        Hp -= dmg;
        OnGetDamage?.Invoke();
        if (Hp < 0) OnDeath?.Invoke();
    }

    public virtual void RestoreHp(float RestHp)
    {
        OnRestoreHp?.Invoke();
        if (Hp + RestHp < MaxHp) Hp += RestHp;
        else Hp = MaxHp;
    }

    public virtual IEnumerator AttackSender()
    {
        while (true)
        {
            if (Target != null)
            {
                Target.GetDamage(Dmg);
                OnAttack?.Invoke();
            }
            yield return new WaitForSeconds(1 / AttackSpeed);
        }
    }

    public virtual IEnumerator EverySecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
        }
    }
}
