using System;

namespace factory_pattern_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number of wheels between 1 and 12 to build a vehicle and press enter");

            var serviceType = Console.ReadLine();
            var service = ServiceFactory.Build(Convert.ToInt32(serviceType));
            Console.WriteLine($" You built a {service.GetType().Name}");
        }
    }

    public class ServiceFactory
    {
        public static IService Build(string serviceType)
        {
            switch (serviceType)
            {
                case "Uber":
                    return new UberService();
            }
        }
    }
}
