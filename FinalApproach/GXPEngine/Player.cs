using GXPEngine;
using System;

public class Player : AnimationSprite
{
    public bool up, left, right, hasJumped;

    private HitBox hitBox;

    public Vec2 previousVelocity;

    public int directionX, directionY;

    protected Vec2 position;

    protected Vec2 velocity;

    public float speed;


    public Player() : base("barry.png", 7, 1)
    {
        hasJumped = true;
        currentFrame = 1;
        position.x = 500;
        position.y = 500;

        hitBox = new HitBox(this);
        AddChild(hitBox);
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
            velocity.y = -10f;
            hasJumped = true;
        }

        if (hasJumped)
        {
            velocity.y += 0.50f;
        }

        if (!hasJumped)
        {
            velocity.y = 0;
        }

        GameObject[] contactObjects = game.FindObjectsOfType<CollisionTile>();

        if (contactObjects != null)
        {
            foreach (CollisionTile tile in contactObjects)
            {
                if ((HitTest(tile)))
                { 
                    hasJumped = false;
                }

                
            }
        }

        /*
        var percentCurrent = velocity * 0.1f;

        var percentPrevious = previousVelocity * 0.9f;

        velocity = percentCurrent + percentPrevious;
    */

        position += velocity;

        previousVelocity = velocity;
    }
}
