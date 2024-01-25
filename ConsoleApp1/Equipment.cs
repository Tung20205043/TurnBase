namespace KeThua {
    public static class Equipment {
        public static readonly Random random = new Random();
        public static float Arrow(float atksp) {
            atksp = atksp + atksp * 20 / 100;
            return atksp;
        }
        public static float Sword(float atk) {
            atk = atk + atk * 15 / 100;
            return atk;
        }
        public static float Caduceus (float spell) {
            spell = spell + spell * 10 / 100;
            return spell;
        }
        public static float Shield(float health) { 
            health = health + health * 20 / 100;
            return health;
        }


    }

    
}
