namespace monogame_survivor
{
    public static class Data
    {
        public static int ScreenW { get; set; } = 1600;
        public static int ScreenH { get; set; } = 900;
        public static bool Exit { get; set; } = false;
        public enum Scenes { Menu, Game, Settings }
        public static Scenes CurrentState { get; set; } = Scenes.Menu;

        public static Game1 GameRef;
    }
}