using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading;

public static class ServiceService
{
    static List<Service> Services { get; }
    static int nextId = 3;
    static ServiceService()
    {
        Services = new List<Service>
            {
                new Service { Id = 1, Name = "LackService", ServiceName="Prevas MES Printing Service", Status = StatusEnum.RUNNING },
                new Service { Id = 2, Name = "Multiflöde", ServiceName="Prevas.PLS_Multiflow", Status = StatusEnum.RUNNING }
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

        //Services[index] = Service;

        var existingService = Get(Service.Id);

        RestartService(existingService.ServiceName);
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    public static void RestartService(string serviceName)
    {
        /* Använder:
       https://docs.microsoft.com/en-us/dotnet/api/system.serviceprocess.servicecontroller?redirectedfrom=MSDN&view=dotnet-plat-ext-5.0
       */

        ServiceController sc = new ServiceController(serviceName);

        if (sc.Status == ServiceControllerStatus.Stopped)
        {
            sc.Start();
            while (sc.Status == ServiceControllerStatus.Stopped)
            {
                Thread.Sleep(1000);
                sc.Refresh();
            }
        }

        if (sc.Status == ServiceControllerStatus.Running)
        {
            sc.Stop();
            while (sc.Status == ServiceControllerStatus.Running)
            {
                Thread.Sleep(1000);
                sc.Refresh();
            }
        }
    }
}
