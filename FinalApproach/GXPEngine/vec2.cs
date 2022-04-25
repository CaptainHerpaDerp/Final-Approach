using System;
using GXPEngine; // Allows using Mathf functions

public struct Vec2
{
    public float x;
    public float y;

    public Vec2(float pX = 0, float pY = 0)
    {
        x = pX;
        y = pY;
    }

    // TODO: Implement Length, Normalize, Normalized, SetXY methods (see Assignment 1)

    // TODO: Implement subtract, scale operators

    public static Vec2 operator +(Vec2 left, Vec2 right)
    {
        return new Vec2(left.x + right.x, left.y + right.y);
    }

    public static Vec2 operator -(Vec2 left, Vec2 right)
    {
        return new Vec2(left.x - right.x, left.y - right.y);
    }
    public static Vec2 operator *(Vec2 left, Vec2 right)
    {
        return new Vec2(left.x * right.x, left.y * right.y);
    }

    public static Vec2 operator *(Vec2 left, float right)
    {
        return new Vec2(left.x * right, left.y * right);
    }


    public override string ToString()
    {
        return $"({x},{y})";
    }

    public float Length()
    {
        return Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
    }

    public void Normalize()
    {
        var length = Length();

        if (length == 0) return;
        x = x / length;
        y = y / length;

    }

    public Vec2 Normalized()
    {
        var length = Length();

        if (length != 0)
        {
            return new Vec2(x / length, y / length);
        }

        return new Vec2(0, 0);

    }

    public void SetXy(float x, float y)
    {
        this.x = x; this.y = y;
    }

    public void SetXy(Vec2 vec)
    {
        SetXy(vec.x, vec.y);
    }

    public void SetLength(float length)
    {
        Normalize();

        x *= length;
        y *= length;
    }

}