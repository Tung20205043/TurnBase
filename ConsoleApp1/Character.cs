namespace KeThua {
    public class Character {
        protected string charName;
        protected float health;
        protected float atk;
        protected float spell;
        protected float atksp;

        public float baseHealth;
        public float baseAtk;
        public float baseSpell;
        public float baseAtksp;

        public bool Alive => health > 0;
        public string CharName => charName;
        public float Health => health;
        public float Atk => atk;    
        public float Spell => spell;
        public float Atksp => atksp;


        public Character(string characterName) {
            health = GameHealper.GetRandomNumber(100, 120);
            atk = GameHealper.GetRandomNumber(20, 30);
            spell = GameHealper.GetRandomNumber(20, 30);
            atksp = GameHealper.GetRandomNumber(1, 3);

            baseHealth = health;
            baseAtk = atk;
            baseSpell = spell;
            baseAtksp = atksp;
            this.charName = characterName;
        }
        public void Attack(Character target) {
            if (!target.Alive) {
                return;
            }
            target.TakeDamage(atk);
        }
        public void TakeDamage(float damage) {
            if (!Alive)
                return;
            health -= damage;
        }
        public float RandomEquip() {
            float a = GameHealper.GetRandomNumber(0, 3);
            GetEquip(a);
            return a;
        }
        public void GetEquip(float i) {
            switch (i) { 
                case 0: 
                    atksp = Equipment.Arrow(atksp);
                    break;
                case 1:
                    atk = Equipment.Sword(atk);
                    break;
                case 2:
                    spell = Equipment.Caduceus(spell);
                    break;
                case 3:
                    health = Equipment.Shield(health);
                    break;
            }
        }
    }
}
