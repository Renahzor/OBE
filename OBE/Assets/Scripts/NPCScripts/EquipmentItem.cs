using System.Collections;
using System.Collections.Generic;

public enum EquipmentType { Weapon, Armor, Consumable }

public class EquipmentItem{

    public EquipmentType equipmentType { get; private set; }

    int minDamage;
    int maxDamage;
    int armorClass;

    int rarity;


}
