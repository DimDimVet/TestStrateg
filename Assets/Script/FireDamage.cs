
public class FireDamage : IDoDamage
{//повреждение от пожара
    public void DoDomage(int damage)
    {
        PlayerStat.player.Healt-=damage;
    }
}

