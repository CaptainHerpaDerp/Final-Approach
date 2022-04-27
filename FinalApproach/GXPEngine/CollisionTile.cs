using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Drawing;

class CollisionTile : EasyDraw
{

    float width, height;

    public CollisionTile(float width, float height) : base(Mathf.Round(width), Mathf.Round(height), true)
    {
        this.width = width;
        this.height = height;
        Draw();
    }

    void Draw()
    {
        Fill(55, 0, 0, 55);
        Stroke(0, 0, 0, 0);
        Rect(0, 0, width, height);
    }

}