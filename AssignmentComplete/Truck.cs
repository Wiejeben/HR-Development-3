using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AssignmentComplete
{
	public class VolvoTruck : ITruck
	{
		private IContainer _container;
		private Texture2D _texture, _container_texture;
		private Vector2 _position, _velocity;
		public Boolean reverse;

		public VolvoTruck(Vector2 position, Vector2 velocity, Texture2D texture, Texture2D container_texture, Boolean reverse = false)
		{
			this._position = position;
			this._velocity = velocity;
			this._texture = texture;
			this._container_texture = container_texture;
			this.reverse = reverse;
		}

		// Define velocity
		public void StartEngine ()
		{
			this._velocity = new Vector2 (10, 0);
		}
			
		// Define container
		public void AddContainer (IContainer container)
		{
			this._container = container;
		}

		public IContainer Container {
			get {
				return this._container;
			}
		}

		// Set and get position of truck
		public Vector2 Position {
			get {
				return this._position;	
			}
			set {
				this._position = value;
			}
		}

		// Set and get position of truck
		public Vector2 Velocity {
			get {
				return this._velocity;	
			}
			set {
				this._velocity = value;
			}
		}

		public void Update (float dt)
		{
			// Update vehicle position
			if (this._container != null) {
				if (this.reverse) {
					this._position.X = this._position.X - this._velocity.X * dt;	
				} else {
					this._position.X = this._position.X + this._velocity.X * dt;
				}
			}
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			SpriteEffects spriteEffect = SpriteEffects.None;

			// Reverse sprite
			if (this.reverse) {
				spriteEffect = SpriteEffects.FlipHorizontally;
			}

			spriteBatch.Draw (this._texture, this._position, null, Color.White, 0f, Vector2.Zero, new Vector2(0.2f, 0.2f), spriteEffect, 0f);

			if (this._container != null) {
				Vector2 offset = new Vector2 (this._position.X, this._position.Y - 6);

				if (this.reverse) {
					offset = new Vector2 (this._position.X + 40, this._position.Y - 15);
				}

				spriteBatch.Draw (this._container_texture, offset, null, Color.White, 0f, Vector2.Zero, new Vector2(0.2f, 0.2f), spriteEffect, 0f);
			}
		}
	}

	public class AddTruckFromFactory : IAction
	{
		IFactory factory;
		List<ITruck> trucks;

		public AddTruckFromFactory(IFactory factory, List<ITruck> trucks)
		{
			this.factory = factory;
			this.trucks = trucks;
		}

		// Spawn new truck and start the engines
		public void Run ()
		{
			var truck = this.factory.GetReadyTruck();
			if (truck != null)
			{
				truck.StartEngine();
				trucks.Add(truck);
			}
		}
	}
}