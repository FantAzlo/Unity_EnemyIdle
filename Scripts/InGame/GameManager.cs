using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerData playerData;
    public Player Player;
    public Location Location;
    private Enemy _currentEnemy;

    public GameObject EnemyGameObject;
    public EnemyController enemyController;
    public PlayerInfoController playerInfoController;


    public Enemy CurrentEnemy
    {
        get { return _currentEnemy; }
        set
        {
            _currentEnemy = value;
            Player.Target = _currentEnemy;
            _currentEnemy.Target = Player;
            _currentEnemy.StartCoroutines();
            _currentEnemy.OnDeath += NextEnemy;
        }
    }

    public int lvl;

    private void Awake()
    {
        Player = transform.AddComponent<Player>();
        Player.LoadData();
        Player.OnDeath += ExitToMenu;
        Player.StartCoroutines();
        playerInfoController.Player = Player;
    }

    void Start()
    {
        lvl = GlobalData.Instance.Level;
        Location = GlobalData.Instance.CurrentLocation;
        NextEnemy();
    }

    public void NextEnemy()
    {
        if (EnemyGameObject != null) Destroy(EnemyGameObject);
        EnemyGameObject = Instantiate(new GameObject("Enemy"));
        CurrentEnemy = EnemyGameObject.transform.AddComponent<Enemy>();
        EnemyData enemyData = Location.GetNextEnemy();

        if (enemyData != null)
        {
            CurrentEnemy.SetFromData(enemyData);
            Debug.Log("Enemy");
            enemyController.InitEnemy(CurrentEnemy);
        }
        else {
            Player.Exp++;
            ExitToMenu();
        }
    }

    public void ExitToMenu()
    {
        GlobalData.Instance.IsWin = false;
        SceneManager.LoadScene("MainMenuScene");
    }
}
