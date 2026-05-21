using CoreWCF;
using CoreWCF.Channels;
using CoreWCF.Configuration;
using CoreWCF.Description;
using WCF_Service_Application.Services.Contracts;
using WCF_Service_Application.Services.Implementations;

namespace WCF_Service_Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // MVC
            builder.Services.AddControllersWithViews();

            // CoreWCF
            builder.Services.AddServiceModelServices();

            // WSDL
            builder.Services.AddServiceModelMetadata();

            // Services
            builder.Services.AddSingleton<TruckService>();

            builder.Services.AddSingleton<ITruckService>(provider =>
                provider.GetRequiredService<TruckService>());

            var app = builder.Build();

            // HTTPS URL
            app.Urls.Add("https://localhost:7057");

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            // SOAP CONFIGURATION
            app.UseServiceModel(serviceBuilder =>
            {
                serviceBuilder.AddService<TruckService>();

                serviceBuilder.AddServiceEndpoint
                <TruckService, ITruckService>(
                    new BasicHttpBinding(BasicHttpSecurityMode.Transport),
                    "/TruckService.svc");
            });

            // ENABLE HTTPS WSDL
            var serviceMetadataBehavior =
                app.Services.GetRequiredService<ServiceMetadataBehavior>();

            serviceMetadataBehavior.HttpsGetEnabled = true;

            // MVC
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Truck}/{action=Index}/{id?}");

            app.Run();
        }
    }
}