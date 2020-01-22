using System;

namespace DatabaseCRUD_EF
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = DataAccessor.getInstance().GetPersonsByOrderDate(new DateTime(2020, 1, 1));

            persons.ForEach(p =>
            {
                Console.WriteLine(p.ToString());
            });

            Console.ReadLine();
        }


    }
}
