using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AfternoonGame.View;

namespace AfternoonGame
{
	public class Cat
	{

		// Animation representing the enemy
		public Animation CatAnimation;

		// The position of the enemy ship relative to the top left corner of thescreen
		public Vector2 Position;

		// The state of the Enemy Ship
		public bool Active;

		Viewport viewport;

		// The amount of damage the enemy inflicts on the player ship
		public int Damage;
	
		// Get the width of the enemy ship
		public int Width
		{
			get { return CatAnimation.FrameWidth; } 
		}

		// Get the height of the enemy ship
		public int Height
		{
			get { return CatAnimation.FrameHeight; } 
		}

		float catMoveSpeed;

		public void Initialize(Viewport viewPort, Animation animation,Vector2 position)
		{
			// Load the enemy ship texture
			CatAnimation = animation;

			this.viewport = viewPort;

			// Set the position of the enemy
			Position = position;

			// We initialize the enemy to be active so it will be update in the game
			Active = true;

			// Set the amount of damage the enemy can do
			Damage = 75;

			// Set how fast the enemy moves
			catMoveSpeed = 6f;
		}



		public void Update(GameTime gameTime)
		{
			// Projectiles always move to the right
			Position.X += catMoveSpeed;

			// Update the position of the Animation
			CatAnimation.Position = Position;

			// Update Animation
			CatAnimation.Update(gameTime);


			// Deactivate the bullet if it goes out of screen
			if (Position.X + Width / 2 > viewport.Width)
				Active = false;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			// Draw the animation
			CatAnimation.Draw(spriteBatch);
		}

	}
}

