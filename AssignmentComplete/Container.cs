using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AssignmentComplete
{
	public class ProductContainer : IContainer
	{
		private Texture2D _texture;
		private Vector2 _position;
		private int _currentAmount;

		public ProductContainer (int amount, Texture2D texture)
		{
			this.AddContent (amount);
			this._texture = texture;
		}

		public bool AddContent (int amount)
		{
			if (this._currentAmount + amount > this.MaxCapacity) {
				Console.WriteLine ("Too many products!");
				return false;
			}

			this._currentAmount += amount;
			return true;
		}

		public int CurrentAmount {
			get {
				return this._currentAmount;
			}
		}

		public int MaxCapacity {
			get {
				return 1000;
			}
		}

		public Vector2 Position {
			get {
				return this._position;
			}
			set {
				this._position = value;
			}
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			spriteBatch.Draw (this._texture, this._position, null, Color.White, 0f, Vector2.Zero, new Vector2(0.1f, 0.1f), SpriteEffects.None, 0f);
		}


	}

	public class OreContainer : IContainer
	{
		private Texture2D _texture;
		private Vector2 _position;
		private int _currentAmount;

		public OreContainer (int amount, Texture2D texture)
		{
			this.AddContent (amount);
			this._texture = texture;
		}

		public bool AddContent (int amount)
		{
			if (this._currentAmount + amount > this.MaxCapacity) {
				Console.WriteLine ("Too many products!");
				return false;
			}

			this._currentAmount += amount;
			return true;
		}

		public int CurrentAmount {
			get {
				return this._currentAmount;
			}
		}

		public int MaxCapacity {
			get {
				return 1000;
			}
		}

		public Vector2 Position {
			get {
				return this._position;
			}
			set {
				this._position = value;
			}
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			spriteBatch.Draw (this._texture, this._position, null, Color.White, 0f, Vector2.Zero, new Vector2(0.1f, 0.1f), SpriteEffects.None, 0f);
		}


	}
}
