public interface IInterfaceStats
{
    float ChangeStat(float energe, float healRate);

    float LimitValue(float energe, float min, float max);
}