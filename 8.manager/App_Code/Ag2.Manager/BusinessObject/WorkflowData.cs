using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WorkflowData
/// </summary>
public class WorkflowData
{
    public int WorkflowId { get; set; }
    public int FluxoId { get; set; }
    public String UserId { get; set; }
    public int StatusId { get; set; }
    public string Status { get; set; }
    public int ConteudoId { get; set; }
    public int ModuleId { get; set; }
    public String ModuleName { get; set; }

    public WorkflowData() { }
}
