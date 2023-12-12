using UnityEngine;

public interface EnemyInterface 
{
    void DestroyEnemy();
}

public class Enemy : EnemyInterface 
{
    private Transform target;

    private float range;
    private float fireRate;
    private float fireCountDown;

    private SoundsPlayer soundsPlayer;
    private string coinSFX;

    public Enemy(Transform target, float range, float fireRate, float fireCountDown, SoundsPlayer soundsPlayer, string coinSFX)
    {
        this.target = target;

        this.range = range;
        this.fireRate = fireRate;
        this.fireCountDown = fireCountDown;

        this.soundsPlayer = soundsPlayer;
        this.coinSFX = coinSFX;
    }

    public void DestroyEnemy() 
    {
        soundsPlayer.PlaySFX(coinSFX);
    }
}

public class TurretsFactory
{
    public EnemyInterface CreateTurret(Transform target, float range, float fireRate, float fireCountDown, SoundsPlayer soundsPlayer, string coinSFX) 
    {
        return new Enemy(target, range, fireRate, fireCountDown, soundsPlayer, coinSFX);
    }
}