using System;

namespace Praktychna7;

public readonly struct Money : IEquatable<Money>
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    private static void CheckCurrency(Money a, Money b)
    {
        if (a.Currency != b.Currency)
            throw new InvalidOperationException("Не можна виконувати операції з різними валютами.");
    }

    public static Money operator +(Money a, Money b)
    {
        CheckCurrency(a, b);
        return new Money(a.Amount + b.Amount, a.Currency);
    }

    public static Money operator -(Money a, Money b)
    {
        CheckCurrency(a, b);
        return new Money(a.Amount - b.Amount, a.Currency);
    }

    public static Money operator *(Money a, decimal factor)
        => new Money(a.Amount * factor, a.Currency);

    public static bool operator >(Money a, Money b)
    {
        CheckCurrency(a, b);
        return a.Amount > b.Amount;
    }

    public static bool operator <(Money a, Money b)
    {
        CheckCurrency(a, b);
        return a.Amount < b.Amount;
    }

    public bool Equals(Money other) => Amount == other.Amount && Currency == other.Currency;

    public override bool Equals(object? obj) => obj is Money m && Equals(m);

    public override int GetHashCode() => HashCode.Combine(Amount, Currency);

    public static bool operator ==(Money a, Money b) => a.Equals(b);

    public static bool operator !=(Money a, Money b) => !a.Equals(b);

    public override string ToString() => $"{Amount:F2} {Currency}";

    public void Deconstruct(out decimal amount, out string currency)
    {
        amount = Amount;
        currency = Currency;
    }
}
