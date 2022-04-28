using System;									
using GXPEngine;                               
using System.Drawing;							

public class MyGame : Game
{
    private Player player1, player2;

    private Level level;

    public MyGame() : base(1920, 1080, false, pVSync : true)		
	{

        player1 = new Player(500, 500, "wasd");
		player2 = new Player(600, 600, "arrow");

        level = new Level("untitled.tmx");

        AddChild(level);

		AddChild(player1);
		AddChild(player2);

	}

    void Update()
	{
		
	}

	static void Main()							
	{
		new MyGame().Start();					
	}
}