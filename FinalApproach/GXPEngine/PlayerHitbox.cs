using System;
using GXPEngine;

public class HitBox : EasyDraw
{
    SolidHitBox horzontal, vertical;
    Player player;

    public HitBox(Player player) : base(50, 50, true)
    {
        this.player = player;

        Fill(255, 255, 0, 150);
        Rect(player.x, player.y, 450, 570);
        horzontal = new SolidHitBox(player, 1);
        vertical = new SolidHitBox(player, 2);
        AddChild(horzontal);
        AddChild(vertical);
    }

    void Update()
    {

    }
}

public class SolidHitBox : EasyDraw
{
    Player player;
    private int _axis, _restrictX, _restrictY;
    
    //ss
    public SolidHitBox(Player player, int Axis) : base(50, 50, true)
    {
        this.player = player;
        _axis = Axis;
        Fill(255, 0, 0, 150);
        Rect(player.x, player.y, 450, 570);
    }

    void OnCollision(GameObject other)
    {
        if (other is CollisionTile)
        {
            if (_restrictX == 1 || _restrictX == -1)
            {
                player.lockX = true;
            }

            if (_restrictY == 1 || _restrictY == -1)
            {
                player.lockY = true;
            }
        }

    }


    void Update()
    {
        if (_axis == 1)
        {
            if (player.velocity.x > 0)
            {
                _restrictX = 1;
                x = 5;
            }


            if (player.velocity.x < 0)
            {
                _restrictX = -1;
                x = -5;
            }

            if (player.velocity.x < 0.01 && player.velocity.x > -0.01)
            {
                _restrictX = 0;
                x = 0;
            }

        }

        if (_axis == 2)
        {
            if (player.velocity.y > 0)
            {
                _restrictY = 1;
                y = 5;
            }

            if (player.velocity.y < 0)
            {
                _restrictY = -1;
                y = -5;
            }

            if (player.velocity.y < 0.01 && player.velocity.y > -0.01)
            {
                _restrictY = 0;
                y = 0;
            }
        }

        player.lockX = false;
        player.lockY = false;

    }


}