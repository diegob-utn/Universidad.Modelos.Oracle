using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Universidad.Modelos;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Universidad.Modelos.Certificado> Certificados { get; set; } = default!;

    public DbSet<Universidad.Modelos.Evento> Eventos { get; set; } = default!;

    public DbSet<Universidad.Modelos.Inscripcion> Inscripciones { get; set; } = default!;

    public DbSet<Universidad.Modelos.Pago> Pagos { get; set; } = default!;

    public DbSet<Universidad.Modelos.Participante> Participantes { get; set; } = default!;

    public DbSet<Universidad.Modelos.Ponente> Ponentes { get; set; } = default!;

    public DbSet<Universidad.Modelos.Sesion> Sesiones { get; set; } = default!;
}
