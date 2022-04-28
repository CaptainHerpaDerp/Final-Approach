using GXPEngine;

public class Player : AnimationSprite
{
    HitBox hitBox;
    private bool left, right, up, down;
    public int directionX, directionY, movementSpeed = 3;
    public bool lockX, lockY;
    public string movementMethod;

    public Vec2 position, velocity, previousVelocity;

    public Player(int x, int y, string MovementMethod) : base("barry.png" , 7, 1)
    {
        SetFrame(1);
        hitBox = new HitBox(this);
        AddChild(hitBox);
        position.x = x;
        position.y = y;
        movementMethod = MovementMethod;

    }

    void UpdateScreenPosition()
    {
        x = position.x;
        y = position.y;
    }


    void Update()
    {

        UpdateScreenPosition();

        if (movementMethod == "wasd")
        {
            left = Input.GetKey(Key.A);
            right = Input.GetKey(Key.D);
            up = Input.GetKey(Key.W);
            down = Input.GetKey(Key.S);
        }
        else
        {
            left = Input.GetKey(Key.LEFT);
            right = Input.GetKey(Key.RIGHT);
            up = Input.GetKey(Key.UP);
            down = Input.GetKey(Key.DOWN);
        }


        if (left) { directionX = -1; }
        else if (right) { directionX = 1; }
        else { directionX = 0; }
  
        if (up) { directionY = -1; }
        else if (down) { directionY = 1; }
        else { directionY = 0; }

        velocity.x = directionX * movementSpeed;
        velocity.y = directionY * movementSpeed;

        var percentCurrent = velocity * 0.01f;

        var percentPrevious = previousVelocity * 0.99f;

        velocity = percentCurrent + percentPrevious;

        if (!lockX)
        {
            position.x += velocity.x;

        }

        if (lockX)
        {
            velocity.x = 0;
        }

        if (!lockY)
        {
            position.y += velocity.y;
        }

        previousVelocity = velocity;

    }
}