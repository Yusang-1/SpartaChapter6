public interface IInterfaceStats
{
    void ContinuousHeal(ref float energe, float healRate);

    float MomentaryHeal(float energe, float healRate);

    void LimitValue(ref float energe, float max);
}