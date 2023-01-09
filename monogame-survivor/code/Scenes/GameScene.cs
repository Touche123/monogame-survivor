using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_survivor
{
    internal class GameScene : SceneComponent
    {
        private List<GameComponent> gameComponents;
        public GameScene()
        {
            gameComponents = new List<GameComponent>();
            gameComponents.Add(new Player());
            gameComponents.Add(new Map());
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            var SortedDrawList = gameComponents;
            SortedDrawList.Sort((x, y) => x.ZOrder.CompareTo(y.ZOrder));
            for (int i = 0; i < gameComponents.Count; i++)
            {
                SortedDrawList[i].Draw(spriteBatch);
            }
        }

        internal override void LoadContent(ContentManager Content)
        {
            for (int i = 0; i < gameComponents.Count; i++)
            {
                gameComponents[i].LoadContent(Content);
            }
        }
        internal override void Update(GameTime gameTime)
        {
            for (int i = 0; i < gameComponents.Count; i++)
            {
                gameComponents[i].Update(gameTime);
            }
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Escape))
                Data.CurrentState = Data.Scenes.Menu;
        }
    }
}