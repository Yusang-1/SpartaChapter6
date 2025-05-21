using UnityEngine;

public class StatsManager : MonoBehaviour, InterfaceStats
{
    private static StatsManager instance = null;
    public AbsStats playerStats;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static StatsManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    public void Start()
    {
        playerStats = new PlayerStats(100, 100);
        Debug.Log(playerStats.MaxHp);
        Debug.Log(playerStats.curHp);
        Debug.Log(playerStats.curStamina);
    }
    void Update()
    {
        ContinuousHeal(ref StatsManager.Instance.playerStats.curStamina, -0.1f);
    }
    public void ContinuousHeal(ref float energe, float healRate)
    {
        energe += healRate;
    }

    public void MomentaryHeal(float energe, float healRate)
    {
        
    }
}
