using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public TextMeshProUGUI HpText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DescText;
    public RawImage Image;
    public Image HpBar;
    public Image AdditiveHpBar;
    private Enemy _enemy;
    public string Name;
    public Animator Animator;
    public Enemy Enemy
    {
        get { return _enemy; }
        set 
        { 
            _enemy = value;
            _enemy.OnGetDamage += UpdateHp;
            DescText.text = _enemy.Desc;
            NameText.text = _enemy.Name;
            Image.texture = _enemy.Sprite;
            Name = _enemy.Name;
            UpdateHp();
        }
    }

    private void Update()
    {
        AdditiveHpBar.fillAmount = Mathf.Lerp(AdditiveHpBar.fillAmount, HpBar.fillAmount, 0.1f);
    }

    public void InitEnemy(Enemy enemy)
    {
        Enemy = enemy;
    }

    public void UpdateHp()
    {
        HpText.text = $"{Enemy.Hp}/{Enemy.MaxHp}";
        SetHpBars();
        Animator.SetTrigger("Attack");
    }

    public void SetHpBars()
    {
        HpBar.fillAmount = Enemy.Hp / Enemy.MaxHp;
    }
}
