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
		#region IContainer implementation

		public bool AddContent (int amount)
		{
			throw new NotImplementedException ();
		}

		public int CurrentAmount {
			get {
				throw new NotImplementedException ();
			}
		}

		public int MaxCapacity {
			get {
				throw new NotImplementedException ();
			}
		}

		public Vector2 Position {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		#endregion

		#region IDrawable implementation

		public void Draw (SpriteBatch spriteBatch)
		{
			throw new NotImplementedException ();
		}

		#endregion


	}

	public class OreContainer : IContainer
	{
		#region IContainer implementation

		public bool AddContent (int amount)
		{
			throw new NotImplementedException ();
		}

		public int CurrentAmount {
			get {
				throw new NotImplementedException ();
			}
		}

		public int MaxCapacity {
			get {
				throw new NotImplementedException ();
			}
		}

		public Vector2 Position {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		#endregion

		#region IDrawable implementation

		public void Draw (SpriteBatch spriteBatch)
		{
			throw new NotImplementedException ();
		}

		#endregion


	}
}
