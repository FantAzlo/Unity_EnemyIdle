using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoController : MonoBehaviour
{
    public TextMeshProUGUI HpField;
    public TextMeshProUGUI AttackSpeedField;
    public TextMeshProUGUI LevelField;
    public TextMeshProUGUI DmgField;
    public TextMeshProUGUI ExpField;
    public Image HpBar;
    public Image AdditiveHpBar;


    private Player _player;
    public Player Player
    {
        get { return _player; }
        set
        {
            _player = value;
            ResetInfo();
            _player.OnGetDamage += ResetInfo;
        }
    }

    private void Start()
    {
        if (Player == null)
        {
            Player = gameObject.AddComponent<Player>();
            Player.LoadData();
            ResetInfo();
        }
    }

    private void Update()
    {
        if (AdditiveHpBar == null) return;
        AdditiveHpBar.fillAmount = Mathf.Lerp(AdditiveHpBar.fillAmount, HpBar.fillAmount, 0.1f);
    }

    public void ResetInfo()
    {
        HpField.text = $"Hp: {_player.Hp}/{_player.MaxHp}";
        AttackSpeedField.text = $"AttackSpeed: {_player.AttackSpeed}";
        LevelField.text = $"Lvl: {_player.Level}";
        DmgField.text = $"Dmg: {_player.Dmg}";
        ExpField.text = $"Exp: {_player.Exp}";
        StartCoroutine(GetDamageShow());
        SetHpBars();
    }

    public IEnumerator GetDamageShow()
    {
        GetComponent<Image>().color = new Color(Mathf.Lerp(0,1,0.3f),0,0);
        yield return new WaitForSeconds(0.2f);
        GetComponent<Image>().color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.1f);
    }

    public void SetHpBars()
    {
        if (HpBar == null) return;
        HpBar.fillAmount = Player.Hp / Player.MaxHp;
    }
}
