using UnityEngine;

[CreateAssetMenu(fileName = "PricePercents", menuName = "Config/PricePercents", order = 0)]
public class PricePercents : ScriptableObject
{
    [Range(0, 4)] [SerializeField] private float _buyCommission;
    [Range(0, 4)] [SerializeField] private float _sellCommission;
    [Range(10, 50)] [SerializeField] private float _sellBenefits;

    public float BuyCommissionCoefficient => _buyCommission / 100;
    public float SellCommissionCoefficient => _sellCommission / 100;
    public float SellBenefitsCommission => _sellBenefits / 100;

}