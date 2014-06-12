<Query Kind="Program">
  <NuGetReference>Microsoft.AspNet.WebApi.OwinSelfHost</NuGetReference>
  <NuGetReference>Microsoft.Owin</NuGetReference>
  <Namespace>Microsoft.Owin</Namespace>
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
   public void Configuration(IAppBuilder app) 
   { 
	   app.Use<SomeMiddleware>();
	   app.Run(async ctx => {
	   	 	await ctx.Response.WriteAsync("<h1>HEY </h1>");
	   });
   } 
}

public class SomeMiddleware {
	
	Func<IDictionary<string, object>, Task> next;
	
	public SomeMiddleware(Func<IDictionary<string, object>, Task> next)
	{
		this.next = next;
	}
	
	public async Task Invoke(IDictionary<string, object> env)
	{
		var res = (Stream)env["owin.ResponseBody"];
		var writer = new StreamWriter(res);
		await writer.WriteAsync("<html><h2> before </h2>");
		writer.Flush();
		await next(env);
	}
}