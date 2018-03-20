using System.Collections.Generic;

namespace SDE.Editor.Items {
	public sealed class ItemTypeStructure {
		public static List<ItemTypeStructure> AllTypes = new List<ItemTypeStructure>();

		public static readonly ItemTypeStructure NotSpecified = new ItemTypeStructure("N�o Especificado", new HashSet<string>());

		public static readonly ItemTypeStructure Weapon = new ItemTypeStructure("Arma", new HashSet<string> {
			"Arma",
			"Shuriken Huuma de 2 M�os",
			"Machado",
			"Livro",
			"Arco",
			"Garra",
			"Adaga",
			"Metralhadora",
			"Lan�ador de Granadas",
			"Shuriken Huuma",
			"Katar",
			"Ma�a",
			"Instrumento Musical",
			"Machado de 1 M�o",
			"Cajado de 1 M�o",
			"Espada de 1 M�o",
			"Rev�lver",
			"Rifle",
			"Cajado",
			"Escopeta",
			"Lan�a",
			"Bast�o",
			"Espada",
			"Machado de 2 M�os",
			"Bast�o de 2 M�os",
			"Espada de 2 M�os",
			"Chicote"
		});

		public static readonly ItemTypeStructure Card = new ItemTypeStructure("Carta", new HashSet<string>());
		public static readonly ItemTypeStructure Headgear = new ItemTypeStructure("Equipamento para a cabe�a", new HashSet<string>());
		public static readonly ItemTypeStructure MonsterEgg = new ItemTypeStructure("Ovo de Monstro", new HashSet<string>());

		public static readonly ItemTypeStructure Armor = new ItemTypeStructure("Armadura", new HashSet<string> {
			"Armadura",
			"Acess�rio",
			"Cal�ado",
			"Manto",
			"Escudo",
			"Cal�ado",
		});

		public static readonly ItemTypeStructure PetArmor = new ItemTypeStructure("Armadura de Pet", new HashSet<string>());

		public static readonly ItemTypeStructure Ammunation = new ItemTypeStructure("Muni��o", new HashSet<string> {
			"Flecha",
			"Bala",
			"Shell",
			"Adaga de Arremesso",
			"Arma de Arremesso",
		});

		public static readonly ItemTypeStructure TamingItem = new ItemTypeStructure("Item de Domesticar", new HashSet<string>());

		public HashSet<string> SubItems = new HashSet<string>();
		public string Type { get; set; }

		private ItemTypeStructure(string type, HashSet<string> subItems) {
			SubItems = subItems;
			Type = type;

			AllTypes.Add(this);
		}

		public override string ToString() {
			return Type;
		}
	}
}