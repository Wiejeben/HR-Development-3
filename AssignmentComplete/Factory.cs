using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AssignmentComplete
{
	public class AddProductToIKEA : IAction
	{
		private IkeaFactory _factory;

		public AddProductToIKEA(IkeaFactory factory)
		{
			this._factory = factory;
		}

		// Create product
		public void Run ()
		{
			this._factory.ProductsToShip.Add (this.CreateProductBox(this._factory.Position + new Vector2(40 + -20 * this._factory.ProductsToShip.Count, 0)));
		}

		ProductContainer CreateProductBox(Vector2 position)
		{
			var box = new ProductContainer (100, this._factory.box);
			box.Position = position;

			return box;
		}
	}

	public class AddOreToMine : IAction
	{
		private MiningFactory _factory;

		public AddOreToMine(MiningFactory factory)
		{
			this._factory = factory;
		}

		// Create product
		public void Run ()
		{
			this._factory.ProductsToShip.Add (this.CreateProductBox(this._factory.Position + new Vector2(40 + 20 * this._factory.ProductsToShip.Count, 0)));
		}

		OreContainer CreateProductBox(Vector2 position)
		{
			var box = new OreContainer (250, this._factory.box);
			box.Position = position;

			return box;
		}
	}

	public class IkeaFactory : IFactory
	{
		private Vector2 _position;
		private ITruck _waitingTruck;

		private List<IStateMachine> _processes = new List<IStateMachine>();
		private List<IContainer> _products = new List<IContainer>();

		private Texture2D _building, _truck, _container;
		public Texture2D box;

		// Construct
		public IkeaFactory(Vector2 position, Texture2D truck, Texture2D building, Texture2D box, Texture2D container)
		{
			this._position = position;

			// Textures
			this._truck = truck;
			this._building = building;
			this.box = box;
			this._container = container;

			this._processes.Add(new Repeat(new Seq(new Timer(1.0f), new Call(new AddProductToIKEA(this)))));
		}

		// Spawn new truck
		public ITruck GetReadyTruck ()
		{
			// Send truck on its way
			if (this.ProductsToShip.Count == 10) {
				ITruck departing = this._waitingTruck;
				IContainer container = this.ProductsToShip.First ();

				// Fill container to the limit
				container.AddContent(container.MaxCapacity - container.CurrentAmount);

				// Reset factory variables
				this._products = new List<IContainer>();
				this._waitingTruck = null;

				// Add container and send away
				departing.AddContainer (container);
				return departing;
			}

			// Create a new truck
			if (this._waitingTruck == null) {
				this._waitingTruck = new VolvoTruck(new Vector2(this._position.X - 125, this._position.Y + 20), Vector2.Zero, this._truck, this._container, true);
			}

			// Send nothing back
			return null;
		}

		// Factory position
		public Vector2 Position {
			get {
				return this._position;
			}
		}

		// List of products
		public List<IContainer> ProductsToShip {
			get {
				return this._products;
			}
		}

		// Update production
		public void Update (float dt)
		{
			foreach (var process in this._processes) {
				process.Update (dt);
			}
		}

		// Assets
		public void Draw (SpriteBatch spriteBatch)
		{
			// Draw waiting truck
			if (this._waitingTruck != null) {
				this._waitingTruck.Draw (spriteBatch);
			}

			// Draw factory
			spriteBatch.Draw (this._building, this._position, null, Color.White, 0f, Vector2.Zero, new Vector2(0.5f, 0.5f), SpriteEffects.None, 0f);

			// Draw products
			foreach (var product in this._products) {
				product.Draw (spriteBatch);
			}
		}
		
	}

	public class MiningFactory : IFactory
	{
		private Vector2 _position;
		private ITruck _waitingTruck;

		private List<IStateMachine> _processes = new List<IStateMachine>();
		private List<IContainer> _products = new List<IContainer>();

		private Texture2D _building, _truck, _container;
		public Texture2D box;

		// Construct
		public MiningFactory(Vector2 position, Texture2D truck, Texture2D building, Texture2D box, Texture2D container)
		{
			this._position = position;

			// Textures
			this._truck = truck;
			this._building = building;
			this.box = box;
			this._container = container;

			this._processes.Add(new Repeat(new Seq(new Timer(1.0f), new Call(new AddOreToMine(this)))));
		}

		// Spawn new truck
		public ITruck GetReadyTruck ()
		{
			// Send truck on its way
			if (this.ProductsToShip.Count == 10) {
				ITruck departing = this._waitingTruck;
				IContainer container = this.ProductsToShip.First ();

				// Fill container to the limit
				container.AddContent(container.MaxCapacity - container.CurrentAmount);

				// Reset factory variables
				this._products = new List<IContainer>();
				this._waitingTruck = null;

				// Add container and send away
				departing.AddContainer (container);
				return departing;
			}

			// Create a new truck
			if (this._waitingTruck == null) {
				this._waitingTruck = new VolvoTruck(new Vector2(this._position.X + 160, this._position.Y + 20), Vector2.Zero, this._truck, this._container);
			}

			// Send nothing back
			return null;
		}

		// Factory position
		public Vector2 Position {
			get {
				return this._position;
			}
		}

		// List of products
		public List<IContainer> ProductsToShip {
			get {
				return this._products;
			}
		}

		// Update production
		public void Update (float dt)
		{
			foreach (var process in this._processes) {
				process.Update (dt);
			}
		}

		// Assets
		public void Draw (SpriteBatch spriteBatch)
		{
			// Draw waiting truck
			if (this._waitingTruck != null) {
				this._waitingTruck.Draw (spriteBatch);
			}

			// Draw factory
			spriteBatch.Draw (this._building, this._position, null, Color.White, 0f, Vector2.Zero, new Vector2(0.5f, 0.5f), SpriteEffects.None, 0f);

			// Draw products
			foreach (var product in this._products) {
				product.Draw (spriteBatch);
			}
		}

	}
}

