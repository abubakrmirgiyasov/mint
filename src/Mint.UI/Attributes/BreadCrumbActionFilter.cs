using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Mint.UI.Attributes;

public class BreadCrumbActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.HttpContext.Request.Path.HasValue && context.HttpContext.Request.Path.Value.Contains("Api"))
        {
            base.OnActionExecuted(context);
            return;
        }

        var breadCrumbs = ConfigureBreadcrumb(context);
        var controller = context.Controller as Controller;
        controller!.ViewBag.BreadCrumbs = breadCrumbs;

        base.OnActionExecuted(context);
    }

    private List<BreadCrumb> ConfigureBreadcrumb(ActionExecutedContext context)
    {
        var breadCrumbList = new List<BreadCrumb>();
        var homePage = "Home";

        breadCrumbList.Add(new BreadCrumb()
        {
            Text = "Главная страница",
            Page = "Index",
            Active = true
        });

        if (context.HttpContext.Request.Path.HasValue)
        {
            var pathSplit = context.HttpContext.Request.Path.Value.Split('/');

            for (int i = 0; i < pathSplit.Length; i++)
            {
                if (string.IsNullOrEmpty(pathSplit[i]) || string.Compare(pathSplit[i], homePage, true) == 0)
                {
                    continue;
                }

                var controller = GetControllerType(pathSplit[i] + "Controller");

                if (controller != null)
                {
                    var indexMethod = controller.GetMethod("Index");

                    if (indexMethod != null)
                    {
                        breadCrumbList.Add(new BreadCrumb()
                        {
                            Text = CamelCaseSpacing(pathSplit[i]),
                            Page = "Index",
                            Active = true
                        });

                        if (i + 1 < pathSplit[i].Length && string.Compare(pathSplit[i + 1], "Index", true) == 0)
                        {
                            breadCrumbList.LastOrDefault()!.Active = false;
                            return breadCrumbList;
                        }
                    }
                }

                if (i - 1 > 0)
                {
                    var controllerName = pathSplit[i - 1] + "Controller";
                    var prevController = GetControllerType(controllerName);

                    if (prevController != null)
                    {
                        var method = prevController.GetMethod(pathSplit[i]);

                        if (method != null)
                        {
                            breadCrumbList.Add(new BreadCrumb()
                            {
                                Text = CamelCaseSpacing(pathSplit[i]),
                                Page = pathSplit[i - 1],
                            });
                        }
                    }
                }
            }
        }

        breadCrumbList.LastOrDefault()!.Active = false;
        return breadCrumbList;
    }

    private Type GetControllerType(string name)
    {
        Type controller = null!;

        try
        {
            controller = Assembly.GetCallingAssembly().GetType("WebApp.Web.Controllers." + name)!;
        }
        catch { }

        return controller;
    }

    private string CamelCaseSpacing(string name)
    {
        var str = new Regex(
            @"(?<=[A-Z])(?=[A-Z][a-z]) | 
            (?<=[^A-Z])(?=[A-Z]) |
            (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);
        return str.Replace(name, " ");
    }
}


public class BreadCrumb
{
    public string Text { get; set; } = "";

    public string Page { get; set; } = "";

    public bool Active { get; set; }

    public BreadCrumb() { }

    public BreadCrumb(string text, string page, bool active)
    {
        Text = text;
        Page = page;
        Active = active;
    }
}