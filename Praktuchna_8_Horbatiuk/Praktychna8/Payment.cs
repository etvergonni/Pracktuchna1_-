using System;

namespace Praktychna8;

public abstract class Payment : IPrintable
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    protected Payment(decimal amount)
    {
        Amount = amount;
        Date = DateTime.Now;
    }

    public abstract decimal CalculateFee();

    public abstract string GetPaymentType();

    public virtual decimal GetTotal() => Amount + CalculateFee();

    public virtual string GetPrintInfo()
    {
        return $"{GetPaymentType()}: сума {Amount:F2}, комісія {CalculateFee():F2}, разом {GetTotal():F2} грн";
    }
}

public class CardPayment : Payment
{
    public string CardNumber { get; set; }

    public CardPayment(decimal amount, string cardNumber) : base(amount)
    {
        CardNumber = cardNumber;
    }

    public override decimal CalculateFee() => Math.Round(Amount * 0.015m, 2);

    public override string GetPaymentType() => "Оплата карткою";

    public override string GetPrintInfo()
    {
        string masked = CardNumber.Length >= 4
            ? "****" + CardNumber.Substring(CardNumber.Length - 4)
            : CardNumber;
        return base.GetPrintInfo() + $", картка {masked}";
    }
}

public class CashPayment : Payment
{
    public CashPayment(decimal amount) : base(amount)
    {
    }

    public override decimal CalculateFee() => 0m;

    public override string GetPaymentType() => "Готівка";
}

public class CryptoPayment : Payment
{
    public string Currency { get; set; }

    public CryptoPayment(decimal amount, string currency) : base(amount)
    {
        Currency = currency;
    }

    public override decimal CalculateFee() => Math.Round(Amount * 0.005m, 2);

    public override string GetPaymentType() => $"Криптовалюта ({Currency})";
}
