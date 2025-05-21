public class PlayerStats : AbsStats
{
    int atk = 0;
    int def = 0;
    float staminaMinus = -0.2f;

    public PlayerStats(float playerMaxHp, float playerMaxStamina) : base(playerMaxHp, playerMaxStamina)
    {
        curHp = playerMaxHp; curStamina = playerMaxStamina;
    }

    //private void Start()
    //{

    //}

    //private void Update()
    //{
    //    StatsManager.Instance.ContinuousHeal(ref StatsManager.Instance.playerStats.curStamina, staminaMinus);        
    //}
}
