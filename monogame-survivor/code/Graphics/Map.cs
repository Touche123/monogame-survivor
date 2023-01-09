using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace monogame_survivor
{
    internal class Map : SceneComponent
    {
        private readonly Point MAP_SIZE = new(6, 4);
        private Point TILE_SIZE;
        private readonly Vector2 MAP_OFFSET = new(2.5f, 2);
        private readonly Tile[,] tiles;
        private Tile lastMouseSelected;

        public Map()
        {
            tiles = new Tile[MAP_SIZE.X, MAP_SIZE.Y];

        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < MAP_SIZE.Y; y++)
            {
                for (int x = 0; x < MAP_SIZE.X; x++)
                {
                    tiles[x, y].Draw(spriteBatch);
                }
            }
        }

        internal override void LoadContent(ContentManager Content)
        {
            Texture2D[] textures =
            {
                Content.Load<Texture2D>("Tiles/tile0"),
                Content.Load<Texture2D>("Tiles/tile1"),
                Content.Load<Texture2D>("Tiles/tile2"),
                Content.Load<Texture2D>("Tiles/tile3"),
                Content.Load<Texture2D>("Tiles/tile4"),
            };

            TILE_SIZE.X = textures[0].Width;
            TILE_SIZE.Y = textures[0].Height / 2;

            Random random = new();

            for (int y = 0; y < MAP_SIZE.Y; y++)
            {
                for (int x = 0; x < MAP_SIZE.X; x++)
                {
                    int r = random.Next(0, textures.Length);
                    tiles[x, y] = new(textures[r], MapToScreen(x, y));
                }
            }
        }

        private Vector2 MapToScreen(int mapX, int mapY)
        {
            var screenX = ((mapX - mapY) * TILE_SIZE.X / 2) + (MAP_OFFSET.X * TILE_SIZE.X);
            var screenY = ((mapY + mapX) * TILE_SIZE.Y / 2) + (MAP_OFFSET.Y * TILE_SIZE.Y);

            return new(screenX, screenY);
        }

        private Point ScreenToMap(Point mousePos)
        {
            Point cursor = new Point(mousePos.X - (int)(MAP_OFFSET.X * TILE_SIZE.X), mousePos.Y - (int)(MAP_OFFSET.Y * TILE_SIZE.Y));
            var mapX = (cursor.X + (2 * cursor.Y) - (TILE_SIZE.X / 2)) / TILE_SIZE.X;
            var mapY = (-cursor.X + (2 * cursor.Y) + (TILE_SIZE.X / 2)) / TILE_SIZE.X;
            return new(mapX, mapY);
        }
        internal override void Update(GameTime gameTime)
        {
            lastMouseSelected?.MouseDeselect();

            var map = ScreenToMap(InputManager.MousePosition);

            if (map.X >= 0 && map.Y >= 0 && map.X < MAP_SIZE.X && map.Y < MAP_SIZE.Y)
            {
                lastMouseSelected = tiles[map.X, map.Y];
                lastMouseSelected.MouseSelect();
            }
        }
    }
}