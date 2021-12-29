public class Weapon
{
    private int _damage;
    private int _bullets;

    public void Fire(Player player)
    {
        if (_bullets >= 1)
        {
            player.TakeDamage(_damage);
            _bullets -= 1;
        }
    }
}

public class Player
{
    private int _health;

    public void TakeDamage(float damage)
    {
        if (_health - damage > 0)
        {
            _health -= damage;
        }
        else
        {
            _health = 0;
        }
    }
}

public class Bot
{
    private Weapon _weapon;

    public void OnSeePlayer(Player player)
    {
        _weapon.Fire(player);
    }
}
