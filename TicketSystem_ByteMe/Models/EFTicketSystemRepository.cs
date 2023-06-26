using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.EntityFrameworkCore;

namespace TicketSystem_ByteMe.Models
{
  public class EFTicketSystemRepository : ITicketSystemRepository
  {
    private TicketSystemDBContext ctx;

    public EFTicketSystemRepository(TicketSystemDBContext ctx)
    {
      this.ctx = ctx;
    }

    public IQueryable<Project> Projects => ctx.Projects;
    public IQueryable<Employee> Employees => ctx.Employees;
    public IQueryable<Ticket> Tickets => ctx.Tickets;

    public void AddTicket(Ticket ticket)
    {
      ctx.Tickets.Add(ticket);
      ctx.SaveChanges();
    }

    public void EditTicket(Ticket ticket)
    {
      Ticket oldTicket = ctx.Tickets.FirstOrDefault(t => t.TicketID == ticket.TicketID);
      oldTicket.Description = ticket.Description;
      oldTicket.AssignedTo = ticket.AssignedTo;
      ctx.Update(oldTicket);
      ctx.SaveChanges();
    }

    public void SolvedTicket(int id)
    {
      Ticket oldTicket = ctx.Tickets.FirstOrDefault(t => t.TicketID == id);
      oldTicket.SolvedAt = DateTime.Now;
      ctx.Update(oldTicket);
      ctx.SaveChanges();
    }

    public void AddEmployee(Employee employee)
    {
      ctx.Employees.Add(employee);
      ctx.SaveChanges();
    }
    public void AddProject(Project project)
    {
      ctx.Projects.Add(project);
      ctx.SaveChanges();
    }
    public void EditProject(Project project)
    { 
      Project oldProject = ctx.Projects.FirstOrDefault(p => p.ProjectID == project.ProjectID);
      oldProject.Start = project.Start;
      oldProject.Title = project.Title;
      oldProject.Description = project.Description; 
      ctx.Projects.Update(oldProject);
      ctx.SaveChanges();
    }
    public void EndProject(int id)
    {
      Project oldProject = ctx.Projects.FirstOrDefault(p => p.ProjectID == id);
      oldProject.End = DateTime.Now;
      ctx.Projects.Update(oldProject);
      ctx.SaveChanges();
    }
    public void RemoveProject(Project project)
    {
      ctx.Remove(project);
      ctx.SaveChanges();
    }
  }
}

