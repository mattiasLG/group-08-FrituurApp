using FrituurApp.Inventory.Domain.Enums;
using FrituurApp.Inventory.Domain.Exceptions;

namespace FrituurApp.Inventory.Domain.ValueObjects;

/// <summary>
/// Text with one value per language (e.g. item name in NL and EN).
/// Falls back to the default language when a translation is missing.
/// </summary>
public sealed record LocalizedText
{
    public const Language DefaultLanguage = Language.Nl;

    private readonly Dictionary<Language, string> _values;

    public IReadOnlyDictionary<Language, string> Values => _values;

    private LocalizedText(Dictionary<Language, string> values)
    {
        _values = values;
    }

    public static LocalizedText Create(IReadOnlyDictionary<Language, string> values)
    {
        var cleaned = values
            .Where(v => !string.IsNullOrWhiteSpace(v.Value))
            .ToDictionary(v => v.Key, v => v.Value.Trim());

        if (!cleaned.ContainsKey(DefaultLanguage))
            throw new InventoryDomainException($"A {DefaultLanguage} translation is required.");

        return new LocalizedText(cleaned);
    }

    public static LocalizedText Create(string nl, string? en = null)
    {
        var values = new Dictionary<Language, string> { [Language.Nl] = nl };
        if (!string.IsNullOrWhiteSpace(en))
            values[Language.En] = en;

        return Create(values);
    }

    public string Get(Language language) =>
        _values.TryGetValue(language, out var value) ? value : _values[DefaultLanguage];

    public bool Equals(LocalizedText? other) =>
        other is not null &&
        _values.Count == other._values.Count &&
        _values.All(kv => other._values.TryGetValue(kv.Key, out var v) && v == kv.Value);

    public override int GetHashCode() =>
        _values.OrderBy(kv => kv.Key).Aggregate(0, (h, kv) => HashCode.Combine(h, kv.Key, kv.Value));
}