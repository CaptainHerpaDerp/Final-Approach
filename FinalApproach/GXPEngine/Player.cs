using GXPEngine;
using System;

public class Player : AnimationSprite
{
    public bool up, left, right, hasJumped;

    public Vec2 previousVelocity;

    public int directionX, directionY;

    protected Vec2 position;

    protected Vec2 velocity;

    public float speed;


    public Player() : base("barry.png", 7, 1)
    {
        hasJumped = true;
        currentFrame = 1;
       
    }


    void UpdateScreenPosition()
    {
        x = position.x;
        y = position.y;
    }


    public void Update()
    {

        UpdateScreenPosition();

        up = Input.GetKey(Key.W);
        left = Input.GetKey(Key.A);
        right = Input.GetKey(Key.D);

        if (left)
        {
            velocity.x = -3;
        }

        else if (right)
        {
            velocity.x = 3;
        }

        else
        {
            velocity.x = 0;
        }

        if (up && !hasJumped)
        {
            position.y -= 6.5f;
            velocity.y = -40f;
            hasJumped = true;
        }

        if (hasJumped)
        {
            velocity.y += 0.50f;
        }

        if (position.y > 500)
        {
            position.y = 500;
            hasJumped = false;
        }


        if (!hasJumped)
        {
            velocity.y = 0;
        }

        var percentCurrent = velocity * 0.1f;

        var percentPrevious = previousVelocity * 0.9f;

        velocity = percentCurrent + percentPrevious;
    

        position += velocity;

        previousVelocity = velocity;


    }

}
