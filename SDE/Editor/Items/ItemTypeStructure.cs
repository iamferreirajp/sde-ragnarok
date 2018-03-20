using System.Collections.Generic;

namespace SDE.Editor.Items {
	public sealed class ItemTypeStructure {
		public static List<ItemTypeStructure> AllTypes = new List<ItemTypeStructure>();

		public static readonly ItemTypeStructure NotSpecified = new ItemTypeStructure("Não Especificado", new HashSet<string>());

		public static readonly ItemTypeStructure Weapon = new ItemTypeStructure("Arma", new HashSet<string> {
			"Arma",
			"Shuriken Huuma de 2 Mãos",
			"Machado",
			"Livro",
			"Arco",
			"Garra",
			"Adaga",
			"Metralhadora",
			"Lançador de Granadas",
			"Shuriken Huuma",
			"Katar",
			"Maça",
			"Instrumento Musical",
			"Machado de 1 Mão",
			"Cajado de 1 Mão",
			"Espada de 1 Mão",
			"Revólver",
			"Rifle",
			"Cajado",
			"Escopeta",
			"Lança",
			"Bastão",
			"Espada",
			"Machado de 2 Mãos",
			"Bastão de 2 Mãos",
			"Espada de 2 Mãos",
			"Chicote"
		});

		public static readonly ItemTypeStructure Card = new ItemTypeStructure("Carta", new HashSet<string>());
		public static readonly ItemTypeStructure Headgear = new ItemTypeStructure("Equipamento para a cabeça", new HashSet<string>());
		public static readonly ItemTypeStructure MonsterEgg = new ItemTypeStructure("Ovo de Monstro", new HashSet<string>());

		public static readonly ItemTypeStructure Armor = new ItemTypeStructure("Armadura", new HashSet<string> {
			"Armadura",
			"Acessório",
			"Calçado",
			"Manto",
			"Escudo",
			"Calçado",
		});

		public static readonly ItemTypeStructure PetArmor = new ItemTypeStructure("Armadura de Pet", new HashSet<string>());

		public static readonly ItemTypeStructure Ammunation = new ItemTypeStructure("Munição", new HashSet<string> {
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