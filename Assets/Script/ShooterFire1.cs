public class ShooterFire1 : WeaponBase
{//вид оружия 1
    public ShooterFire1()
    {
        damage = 20;
        damageType = new FireDamage();
    }
}