<Query Kind="Program">
  <NuGetReference>Microsoft.AspNet.WebApi.OwinSelfHost</NuGetReference>
  <Namespace>Microsoft.Owin.Hosting</Namespace>
  <Namespace>Owin</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Web.Http</Namespace>
</Query>

// En OWIN
async void Main()
{
	using (var webapp = WebApp.Start<Startup>("http://localhost:8090/"))
	{
		Console.WriteLine("Press Enter to quit.");
        Console.ReadLine();
	}
}
	
public class Startup 
{ 
   public void Configuration(IAppBuilder appBuilder) 
   { 
	   appBuilder.Run(async ctx => {
	   		ctx.Response.ContentType = "text/plain";
	   	 	await ctx.Response.WriteAsync("Hello world\n");
	   });
   } 
}