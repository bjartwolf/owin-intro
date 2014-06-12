<Query Kind="Program">
  <NuGetReference>Microsoft.Owin.SelfHost</NuGetReference>
  <Namespace>Microsoft.Owin</Namespace>
  <Namespace>Microsoft.Owin.Hosting</Namespace>
  <Namespace>Owin</Namespace>
  <Namespace>System</Namespace>
</Query>

static void Main(string[] args)
{
	var url = "http://localhost:8081";
    WebApp.Start(url, builder => builder.Run(async ctx => {
			ctx.Response.ContentType = "text/plain";
	   	 	await ctx.Response.WriteAsync("Hello world"); 
	}));
    Console.WriteLine("Listening at " + url);
    Console.ReadLine();
}
