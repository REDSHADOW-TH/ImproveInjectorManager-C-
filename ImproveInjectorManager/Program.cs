using System;
using ImproveInjectorManager.System;

namespace ImproveInjectorManager
{
    public class Service1
    {
        private string text = "hi i'm service 1 instance";
        public Service1()
        {
            Console.WriteLine("service 1 is created !");
        }
        public void Say()
        {
            Console.WriteLine(text);
        }
        public void SetText(string text)
        {
            this.text = text;
        }
    }
    public class Service2
    {
        Service1 service1 = (Service1)Injector.InjectorManager.GetInstance("service1");
        public Service2()
        {
            Console.WriteLine("service 2 is created !");
            service1.SetText("service 1 is running from service 2");
            service1.Say();
            service1.SetText("is text from service 2");
        }
        public void Say()
        {
            Console.WriteLine("hi i'm service 2 instance");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Injector.InjectorManager.RegisterSingleton<Service1>("service1");

            Service1 s1 = (Service1)Injector.InjectorManager.GetInstance("service1");
            Service1 s2 = (Service1)Injector.InjectorManager.GetInstance("service1");
            s1.Say();
            new Service2();
            s2.Say();

            Injector.InjectorManager.RegisterScoped<Service1>("scoped1");
            Injector.InjectorManager.RegisterScoped<Service1>("scoped2");

            Service1 scoped1 = (Service1)Injector.InjectorManager.GetInstance("scoped1");
            Service1 scoped2 = (Service1)Injector.InjectorManager.GetInstance("scoped2");

            scoped1.SetText("this scoped 1");
            scoped2.SetText("this scoped 2");

            scoped1.Say();
            scoped2.Say();


            Console.WriteLine("End of program");

            Console.ReadKey();
        }
    }
}
