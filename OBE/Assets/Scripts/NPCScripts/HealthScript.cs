using System;
using System.Collections.Generic;

public class HealthScript
{
    public int maxHP { get; private set; }
    public int currentHP { get; private set; }

    //constructor for starting HP
    public HealthScript(int toughness, int heroLevel, Professions profession)
    {
        if (profession == Professions.Villager)
        {
            maxHP = 5 + ( (toughness / 2) - 5);
            currentHP = maxHP;
        }
    }

    public void Hurt(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
            return; //kill
    }

    public void Heal(int healthGained)
    {
        currentHP += healthGained;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }
}
