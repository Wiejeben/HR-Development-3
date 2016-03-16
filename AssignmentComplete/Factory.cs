using System;

namespace AssignmentComplete
{
	public class IkeaFactory : IFactory
	{
		#region IFactory implementation
		public ITruck GetReadyTruck ()
		{
			throw new NotImplementedException ();
		}
		public Microsoft.Xna.Framework.Vector2 Position {
			get {
				throw new NotImplementedException ();
			}
		}
		public System.Collections.Generic.List<IContainer> ProductsToShip {
			get {
				throw new NotImplementedException ();
			}
		}
		#endregion
		#region IUpdateable implementation
		public void Update (float dt)
		{
			throw new NotImplementedException ();
		}
		#endregion
		#region IDrawable implementation
		public void Draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{
			throw new NotImplementedException ();
		}
		#endregion
		
	}

	public class MiningFactory : IFactory
	{
		#region IFactory implementation
		public ITruck GetReadyTruck ()
		{
			throw new NotImplementedException ();
		}
		public Microsoft.Xna.Framework.Vector2 Position {
			get {
				throw new NotImplementedException ();
			}
		}
		public System.Collections.Generic.List<IContainer> ProductsToShip {
			get {
				throw new NotImplementedException ();
			}
		}
		#endregion
		#region IUpdateable implementation
		public void Update (float dt)
		{
			throw new NotImplementedException ();
		}
		#endregion
		#region IDrawable implementation
		public void Draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{
			throw new NotImplementedException ();
		}
		#endregion

	}
}

