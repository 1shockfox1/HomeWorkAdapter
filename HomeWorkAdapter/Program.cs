using System;

interface IPayment
{
    void Pay(double amount);
}

class CashPayment : IPayment
{
    public void Pay(double amount) => Console.WriteLine($"Оплата наличными: {amount} рублей");
}

class CardPayment : IPayment
{
    public void Pay(double amount) => Console.WriteLine($"Оплата картой: {amount} рублей");
}


class OldPaymentSystem
{
    public void MakeTransaction(double money)
    {
        Console.WriteLine("Старая система обработала платёж: " + money);
    }
}

// Адаптер ВОООООООТ ОООООН
class OldPaymentAdapter : IPayment
{
    private readonly OldPaymentSystem _oldSystem;
    public OldPaymentAdapter(OldPaymentSystem oldSystem) => _oldSystem = oldSystem;
    public void Pay(double amount) => _oldSystem.MakeTransaction(amount);
}

class Program
{
    static void Main()
    {
        IPayment cash = new CashPayment();
        IPayment card = new CardPayment();
        IPayment adapter = new OldPaymentAdapter(new OldPaymentSystem());

        cash.Pay(150);
        card.Pay(1500);
        adapter.Pay(1500);
    }
}