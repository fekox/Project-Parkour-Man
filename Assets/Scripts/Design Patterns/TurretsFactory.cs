using UnityEngine;

/// <summary>
/// Class to create enemy, check targets and destroy enemies.
/// </summary>
public class Enemy 
{
    private Transform target;
    private Transform turret;

    private float range;

    private SoundsPlayer soundsPlayer;

    private string playerTag;
    private string coinSFX;

    /// <summary>
    /// Enemy Builder.
    /// </summary>
    public Enemy(Transform target, Transform turret, float range, SoundsPlayer soundsPlayer, string playerTag, string coinSFX)
    {
        this.target = target;
        this.turret = turret;

        this.range = range;

        this.soundsPlayer = soundsPlayer;

        this.playerTag = playerTag;
        this.coinSFX = coinSFX;
    }
}

/// <summary>
/// Creates the turret and return it.
/// </summary>
public class TurretsFactory
{
    public Enemy CreateTurret(Transform target, Transform turret, float range, SoundsPlayer soundsPlayer, string playerTag, string coinSFX) 
    {
        return new Enemy(target, turret, range, soundsPlayer, playerTag, coinSFX);
    }
}