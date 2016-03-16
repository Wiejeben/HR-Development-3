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
		#region ITruck implementation
		public void StartEngine ()
		{
			throw new NotImplementedException ();
		}
		public void AddContainer (IContainer container)
		{
			throw new NotImplementedException ();
		}
		public IContainer Container {
			get {
				throw new NotImplementedException ();
			}
		}
		public Vector2 Position {
			get {
				throw new NotImplementedException ();
			}
		}
		public Vector2 Velocity {
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
		public void Draw (SpriteBatch spriteBatch)
		{
			throw new NotImplementedException ();
		}
		#endregion
	
	}
}
