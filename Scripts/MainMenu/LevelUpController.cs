using UnityEngine;
using YG;

public class LevelUpController : MonoBehaviour
{
    public PlayerInfoController PlayerInfoController;
    public Player Player;

    private void Start()
    {
        YandexGame.RewardVideoEvent += AddExp;
    }
    void Update()
    {
        Player = PlayerInfoController.Player;
    }

    public void DmgUp()
    {
        if (Player.Exp <= 0) return;
        Player.Dmg *= 1.15f;
        Player.Exp--;
        Player.Level++;
        PlayerInfoController.ResetInfo();
        Player.SaveData();
    }

    public void AttackSpeedUp()
    {
        if (Player.Exp <= 0) return;
        Player.AttackSpeed *= 1.1f;
        Player.Exp--;
        Player.Level++;
        PlayerInfoController.ResetInfo();
        Player.SaveData();
    }

    public void HpUp()
    {
        if (Player.Exp <= 0) return;
        Player.MaxHp *= 1.2f;
        Player.Hp = Player.MaxHp;
        Player.Exp--;
        Player.Level++;
        PlayerInfoController.ResetInfo();
        Player.SaveData();
    }

    public void ExpUp()
    {
        YandexGame.RewVideoShow(0);
    }

    public void AddExp(int i)
    {
        Player.Exp++;
        PlayerInfoController.ResetInfo();
        Player.SaveData();
    }
}
