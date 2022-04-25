using System;									
using GXPEngine;                               
using System.Drawing;							

public class MyGame : Game
{
    private Player player1, player2;

	public MyGame() : base(1920, 1080, false, pVSync : true)		
	{

        player1 = new Player();
		player2 = new Player();

		AddChild(player1);

	}

    void Update()
	{
		
	}

	static void Main()							
	{
		new MyGame().Start();					
	}
}