#region Variables
int hour = 0, min = 0, euro = 0, cents = 0;
string input = "";
decimal coins = 0m;
bool stop = false;
#endregion

PrintWelcome();
EnterCoins();

if (hour <= 1 && min <= 30) { PrintParkingTime(); }
else PrintDonation();


void PrintWelcome()
{
    Console.WriteLine("Hello! Welcome to the Parking ticket machine!");
    Console.WriteLine("Parking ticket machine with a minimum parking time of 30 minutes and a maximum parking time of 1:30 hours");
    Console.WriteLine("You must insert valid coins (5 cents, 10 cents, 20 cents, 50 cents, 1 euro and 2 euros).");
    Console.WriteLine("Tariff per hour: 1 Euro ");
    Console.WriteLine();
}

void EnterCoins()
{
    Console.WriteLine("Print parking ticket with d or D");
    Console.WriteLine();

    while (input != "d" && input != "D" && !(stop))
    {
        Console.WriteLine($"Parking time so far: {hour}:{min} ");
        Console.Write("Your input: ");
        input = (Console.ReadLine()!).ToLower();

        while (hour == 0 && min == 0 && input == "d")
        {
            Console.WriteLine("Minimum insertion 50 cents, so far you have inserted 0 cents");
            Console.WriteLine($"Parking time so far: {hour}:{min} ");
            Console.Write("Your input: ");
            input = (Console.ReadLine()!).ToLower();
        }
        AddParkingTime();
    }
}

void AddParkingTime()
{
    if (input != "1" && input != "2")
    {
        switch (input)
        {
            case "5": min += 3; coins += 0.05m; break;
            case "10": min += 6; coins += 0.1m; break;
            case "20": min += 12; coins += 0.2m; break;
            case "50": min += 30; coins += 0.5m; break;
        }
    }
    else
    {
        if (input == "1")
        {
            hour += 1;
            coins += 1;
        }

        else if (input == "2" && !(stop))
        {
            hour += 2;
            Console.WriteLine("You may park for 1:30 hours");
            coins += 2;
            stop = true;
        }
    }
}

void PrintParkingTime()
{
    Console.WriteLine($"You may park for {hour}:{min} hours!");
}

void PrintDonation()
{
    coins -= 1.5m;

    euro = (int)coins / 1;
    coins -= euro;

    coins *= 100;
    cents = (int)coins;

    Console.Write($"Thank you for your donation of {euro} Euro and {cents} Cents !");
}