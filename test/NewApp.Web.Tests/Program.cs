using Microsoft.AspNetCore.Builder;
using NewApp;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("NewApp.Web.csproj"); 
await builder.RunAbpModuleAsync<NewAppWebTestModule>(applicationName: "NewApp.Web");

public partial class Program
{
}
