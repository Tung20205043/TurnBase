namespace KeThua {
    public static class GameHealper {
        public static readonly Random random = new Random();
        public static float GetRandomNumber(int a, int b) { 
            return random.Next(a, b+1 );
        }
    }
}
