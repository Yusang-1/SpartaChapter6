using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public AbsStats playerStats;

#region ½Ì±ÛÅæ ±¸Çö
    private static StatsManager instance = null;
    
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
#endregion

    
}
