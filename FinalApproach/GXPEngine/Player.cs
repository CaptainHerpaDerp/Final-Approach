using GXPEngine;
using System;

public class Player : AnimationSprite
{
    public bool up, left, right, down, hasJumped;

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


    public void Update()
    {
        down = Input.GetKey(Key.S);
        up = Input.GetKey(Key.W);
        left = Input.GetKey(Key.A);
        right = Input.GetKey(Key.D);

        if (left)
        {
            _mirrorX = true;
            directionX = -1;
        }

        else if (right)
        {
            _mirrorX = false;
            directionX = 1;
        }

        else
        {
            directionX = 0;
        }

        if (down)
        {
            y += 5;
        }


        /*  if (up && !hasJumped)
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
        */
          
           
               x += directionX * 5;
               y += directionY * 5;
           

         /*

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
        */

    }
}
