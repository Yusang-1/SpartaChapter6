public interface IInterfaceStats
{
    void ContinuousHeal(ref float energe, float healRate);

    void MomentaryHeal(ref float energe, float healRate);

    void LimitValue(ref float energe, float max);
}