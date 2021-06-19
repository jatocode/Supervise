using System.Collections.Generic;
using System.Linq;

public static class ServiceService
{
    static List<Service> Services { get; }
    static int nextId = 3;
    static ServiceService()
    {
        Services = new List<Service>
            {
                new Service { Id = 1, Name = "LackService", Status = StatusEnum.RUNNING },
                new Service { Id = 2, Name = "Multiflöde", Status = StatusEnum.RUNNING }
            };
    }

    public static List<Service> GetAll() => Services;

    public static Service Get(int id) => Services.FirstOrDefault(p => p.Id == id);

    public static void Add(Service Service)
    {
        Service.Id = nextId++;
        Services.Add(Service);
    }

    public static void Delete(int id)
    {
        var Service = Get(id);
        if (Service is null)
            return;

        Services.Remove(Service);
    }

    public static void Update(Service Service)
    {
        var index = Services.FindIndex(p => p.Id == Service.Id);
        if (index == -1)
            return;

        Services[index] = Service;
    }
}
