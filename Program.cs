// See https://aka.ms/new-console-template for more information
using DepozitApp;

using (DepozitContext db = new())
{



    Produ obj = new();
      db.Produs.Add(obj);
      db.SaveChanges(); 
}
// получение
using (DepozitContext db = new())
{
    // получаем объекты из бд и выводим на консоль
    var users = db.Produs.ToList();
    Console.WriteLine("Datele inregristrate: ");
    foreach (Produ u in users)
    {
        Console.WriteLine($"{u.Id} |||| {u.Name} |||| {u.Description} |||| {u.Owner}");



    }
}