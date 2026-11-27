namespace FrituurApp.Inventory.Domain.Enums;

/// <summary>
/// The 14 allergens that must be declared in the EU (Regulation 1169/2011).
/// Display names live in the i18n layer, keyed by the enum name.
/// </summary>
public enum Allergen
{
    Gluten = 1,
    Crustaceans = 2,
    Eggs = 3,
    Fish = 4,
    Peanuts = 5,
    Soybeans = 6,
    Milk = 7,
    Nuts = 8,
    Celery = 9,
    Mustard = 10,
    Sesame = 11,
    Sulphites = 12,
    Lupin = 13,
    Molluscs = 14
}