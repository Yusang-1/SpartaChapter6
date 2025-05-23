using UnityEngine;
public class PlayerStats : AbsStats
{    
    //public PlayerStats(float playerMaxHp, float playerMaxStamina) // : base(playerMaxHp, playerMaxStamina)
    //{
    //    MaxHp = playerMaxHp; MaxStamina = playerMaxStamina;
    //    curHp = MaxHp; curStamina = MaxStamina;
    //}

    private void Start()
    {
        changeStats = GameObject.Find("GameManager").GetComponent<ChangeStats>();
        MaxHp = 100; MaxStamina = 100;
        curHp = MaxHp; curStamina = MaxStamina;
    }

    void Update()
    {
        DefaultStaminaDown();
    }

    void DefaultStaminaDown()
    {
        float fValue = changeStats.ChangeStat(StatsManager.Instance.playerStats.curStamina, -0.1f);
        fValue = changeStats.LimitValue(fValue, 0, StatsManager.Instance.playerStats.MaxStamina);
        StatsManager.Instance.playerStats.curStamina = fValue;
    }

    
}
