using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace monogame_survivor
{
    internal partial class GameStateManager : SceneComponent
    {
        private MenuScene menuScene = new MenuScene();
        private GameScene gameScene = new GameScene();
        private SettingsScene settingsScene = new SettingsScene();
        internal override void LoadContent(ContentManager Content)
        {
            menuScene.LoadContent(Content);
            gameScene.LoadContent(Content);
            settingsScene.LoadContent(Content);
        }
        internal override void Update(GameTime gameTime)
        {
            switch (Data.CurrentState)
            {
                case Data.Scenes.Menu:
                    menuScene.Update(gameTime);
                    break;
                case Data.Scenes.Game:
                    gameScene.Update(gameTime);
                    break;
                case Data.Scenes.Settings:
                    settingsScene.Update(gameTime);
                    break;
            }
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            switch (Data.CurrentState)
            {
                case Data.Scenes.Menu:
                    menuScene.Draw(spriteBatch);
                    break;
                case Data.Scenes.Game:
                    gameScene.Draw(spriteBatch);
                    break;
                case Data.Scenes.Settings:
                    settingsScene.Draw(spriteBatch);
                    break;
            }
        }
    }
}