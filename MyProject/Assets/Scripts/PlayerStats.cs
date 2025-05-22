public class PlayerStats : AbsStats
{

    public PlayerStats(float playerMaxHp, float playerMaxStamina) : base(playerMaxHp, playerMaxStamina)
    {
        curHp = playerMaxHp; curStamina = playerMaxStamina;
    }
}
