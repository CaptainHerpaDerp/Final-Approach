using GXPEngine;

public class SolidHitBox : EasyDraw
{
    private Player _player;
	public int facing;
	public int restrictX, restrictY;
	public string Axis;
	
	public SolidHitBox(Player player, string Axis) : base(25, 25, true)
	{
		this.Axis = Axis;
        _player = player;
		Draw(0, 0, 255, 100);
	}

	void Draw(byte red, byte green, byte blue, byte transparency)
	{
		Fill(0, 0, 255, 55);
		Rect(_player.x, _player.y, 450, 570);
	}

	void OnCollision(GameObject other)
	{
		if (other is CollisionTile)
		{
			if (restrictX == -1 || restrictX == 1)
			{
				_player.directionX = 0;
			}

			if (restrictY == -1 || restrictY == 1)
			{
                _player.directionY = 0;
			}
		}
	}

	void Update()
	{
		if (Axis == "Horizontal")
		{
			switch (_player.directionX)
			{
				case 1:
					restrictX = 1;
					x = 30;
					break;

				case -1:
					restrictX = -1;
					x = -5;
					break;

				case 0:
					restrictX = 0;
					x = 17.5f;
					break;
			}
		}

		if (Axis == "Vertical")
		{
			switch (_player.directionY)
			{
				case 1:
					restrictY = 1;
					y = 30;
					break;

				case -1:
					restrictY = -1;
					y = -5;
					break;

				case 0:
					restrictY = 0;
					y = 17.5f;
					break;
			}
		}
	}
}


public class HitBox : EasyDraw
{
	public SolidHitBox solidHitBoxX, solidHitBoxY;
    private Player _player;
	public bool flip;
	public float lastX, lastY;

	public HitBox(Player player) : base(50, 50, true)
	{
        _player = player;
		solidHitBoxX = new SolidHitBox(_player, "Horizontal");
		solidHitBoxY = new SolidHitBox(_player, "Vertical");
        AddChild(solidHitBoxX);
		AddChild(solidHitBoxY);
		Draw(150, 0, 255, 100);

	}
	void Draw(byte red, byte green, byte blue, byte transparency)
	{
		Fill(0, 255, 0, 55);
		Rect(_player.x, _player.y, 450, 570);

	}

	void Update()
	{
		lastX = _player.x;
		lastY = _player.y;
    }

}