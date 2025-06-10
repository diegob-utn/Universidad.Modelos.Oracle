using System;
using Universidad.API.Consumer;
using Universidad.Modelos;

namespace Universidad.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Crud<Evento>.EndPoint = "https://localhost:7270/api/Eventos";
            Crud<Certificado>.EndPoint = "https://localhost:7270/api/Certificados";
            Crud<Inscripcion>.EndPoint = "https://localhost:7270/api/Inscripciones";
            Crud<Pago>.EndPoint = "https://localhost:7270/api/Pagos";
            Crud<Participante>.EndPoint = "https://localhost:7270/api/Participantes";
            Crud<Ponente>.EndPoint = "https://localhost:7270/api/Ponentes";
            Crud<Sesion>.EndPoint = "https://localhost:7270/api/Sesiones";



            // Agregar datos a todas las tablas
            AgregarDatosATodas();

            Console.WriteLine("probando evento");
            ProbarEventos("Evento 1");
            /*ProbarEventos("Evento 2");
            ProbarEventos("Evento 3");
            ProbarEventos("Evento 4");
            */
            Console.WriteLine("probando certificados");
            ProbarCertificados("Certificado 1");
            /*ProbarCertificados("Certificado 2");
            ProbarCertificados("Certificado 3");
            ProbarCertificados("Certificado 4");
            */
            Console.WriteLine("Probando inscripciones");
            ProbarInscripcion("Inscripcion 1");
            /*ProbarInscripcion("Inscripcion 2");
            ProbarInscripcion("Inscripcion 3");
            ProbarInscripcion("Inscripcion 4");
            */
            Console.WriteLine("probando pagos");
            ProbarPagos("Pago 1");
            /*ProbarPagos("Pago 2");
            ProbarPagos("Pago 3");
            ProbarPagos("Pago 4");
            */
            Console.WriteLine("Probando participantes");
            ProbarParticipantes("Participante 1");
            /*ProbarParticipantes("Participante 2");
            ProbarParticipantes("Participante 3");
            ProbarParticipantes("Participante 4");
            */
            Console.WriteLine("probando ponentes");
            ProbarPonentes("Ponente 1");
            /*ProbarPonentes("Ponente 2");
            ProbarPonentes("Ponente 3");
            ProbarPonentes("Ponente 4");    
            */
            Console.WriteLine("probando sesiones");
            ProbarSesiones("Sesion 1");
            /*ProbarSesiones("Sesion 2");
            ProbarSesiones("Sesion 3");
            ProbarSesiones("Sesion 4");
            */Console.WriteLine();

            Console.ReadLine();
        }




        private static void ProbarEventos(string nombre)
        {
            Crud<Evento>.EndPoint = "https://localhost:7270/api/Eventos";

            // Crear un nuevo evento
            var evento = Crud<Evento>.Create(new Evento
            {
                Id = 0,
                Nombre = "Evento " + nombre,
                Fecha = DateTime.Now.AddDays(1),
                Lugar = "Lugar del evento " + nombre,
                Tipo = "Tipo de evento " + nombre
            });

            // Actualizar evento
            evento.Nombre = "Evento actualizado " + nombre;
            Crud<Evento>.Update(evento.Id, evento);

            // Obtener todos los eventos
            var eventos = Crud<Evento>.GetAll();

            foreach(var e in eventos)
            {
                Console.WriteLine($"Evento: {e.Nombre}, Fecha: {e.Fecha}, Lugar: {e.Lugar}, Tipo: {e.Tipo}");
            }

            // Eliminar evento
            Crud<Evento>.Delete(evento.Id);
        }


        private static void ProbarCertificados(string nombre)
        {
            Crud<Certificado>.EndPoint = "https://localhost:7270/api/Certificados";

            // Crear un nuevo certificado
            var certificado = Crud<Certificado>.Create(new Certificado
            {
                Id = 0,
                Nombre = "Certificado " + nombre,
                FechaEmision = DateTime.Now,
                ParticipanteId = 1, // Asumiendo que existe un Participante con Id 1
                EventoId = 1        // Asumiendo que existe un Evento con Id 1
            });

            // Actualizar certificado
            certificado.Nombre = "Certificado actualizado " + nombre;
            Crud<Certificado>.Update(certificado.Id, certificado);

            // Obtener todos los certificados
            var certificados = Crud<Certificado>.GetAll();

            foreach(var c in certificados)
            {
                Console.WriteLine($"Certificado: {c.Nombre}, Emisión: {c.FechaEmision}, ParticipanteId: {c.ParticipanteId}, EventoId: {c.EventoId}");
            }

            // Eliminar certificado
            Crud<Certificado>.Delete(certificado.Id);
        }

        private static void ProbarInscripcion(string estado)
        {
            Crud<Inscripcion>.EndPoint = "https://localhost:7270/api/Inscripciones";

            // Crear una nueva inscripción
            var inscripcion = Crud<Inscripcion>.Create(new Inscripcion
            {
                Id = 0,
                Fecha = DateTime.Now,
                Estado = "Estado " + estado,
                ParticipanteId = 1, // Asumiendo que existe un Participante con Id 1
                EventoId = 1        // Asumiendo que existe un Evento con Id 1
            });

            // Actualizar inscripción
            inscripcion.Estado = "Estado actualizado " + estado;
            Crud<Inscripcion>.Update(inscripcion.Id, inscripcion);

            // Obtener todas las inscripciones
            var inscripciones = Crud<Inscripcion>.GetAll();

            foreach(var i in inscripciones)
            {
                Console.WriteLine($"Inscripción: ID: {i.Id}, Fecha: {i.Fecha}, Estado: {i.Estado}, ParticipanteId: {i.ParticipanteId}, EventoId: {i.EventoId}");
            }

            // Eliminar inscripción
            Crud<Inscripcion>.Delete(inscripcion.Id);
        }

        private static void ProbarPagos(string medio)
        {
            Crud<Pago>.EndPoint = "https://localhost:7270/api/Pagos";

            // Crear un nuevo pago
            var pago = Crud<Pago>.Create(new Pago
            {
                Id = 0,
                Fecha = DateTime.Now,
                Medio = "Medio de pago " + medio,
                InscripcionId = 1  // Asumiendo que existe una Inscripcion con Id 1
            });

            // Actualizar pago
            pago.Medio = "Medio actualizado " + medio;
            Crud<Pago>.Update(pago.Id, pago);

            // Obtener todos los pagos
            var pagos = Crud<Pago>.GetAll();

            foreach(var p in pagos)
            {
                Console.WriteLine($"Pago: ID: {p.Id}, Fecha: {p.Fecha}, Medio: {p.Medio}, InscripcionId: {p.InscripcionId}");
            }

            // Eliminar pago
            Crud<Pago>.Delete(pago.Id);
        }

        private static void ProbarParticipantes(string nombre)
        {
            Crud<Participante>.EndPoint = "https://localhost:7270/api/Participantes";

            // Crear un nuevo participante
            var participante = Crud<Participante>.Create(new Participante
            {
                Id = 0,
                Nombre = "Participante " + nombre,
                Apellido = "Apellido " + nombre,
                Telefono = "555-" + nombre,
                EventoId = 1,      // Asumiendo que existe un Evento con Id 1
                SesionId = 1       // Asumiendo que existe una Sesion con Id 1
            });

            // Actualizar participante
            participante.Nombre = "Participante actualizado " + nombre;
            Crud<Participante>.Update(participante.Id, participante);

            // Obtener todos los participantes
            var participantes = Crud<Participante>.GetAll();

            foreach(var p in participantes)
            {
                Console.WriteLine($"Participante: {p.Nombre} {p.Apellido}, Teléfono: {p.Telefono}, EventoId: {p.EventoId}, SesionId: {p.SesionId}");
            }

            // Eliminar participante
            Crud<Participante>.Delete(participante.Id);
        }

        private static void ProbarPonentes(string nombre)
        {
            Crud<Ponente>.EndPoint = "https://localhost:7270/api/Ponentes";

            // Crear un nuevo ponente
            var ponente = Crud<Ponente>.Create(new Ponente
            {
                Id = 0,
                Nombre = "Ponente " + nombre,
                Apellido = "Apellido " + nombre,
                EventoId = 1       // Asumiendo que existe un Evento con Id 1
            });

            // Actualizar ponente
            ponente.Nombre = "Ponente actualizado " + nombre;
            Crud<Ponente>.Update(ponente.Id, ponente);

            // Obtener todos los ponentes
            var ponentes = Crud<Ponente>.GetAll();

            foreach(var p in ponentes)
            {
                Console.WriteLine($"Ponente: {p.Nombre} {p.Apellido}, EventoId: {p.EventoId}");
            }

            // Eliminar ponente
            Crud<Ponente>.Delete(ponente.Id);
        }

        private static void ProbarSesiones(string lugar)
        {
            Crud<Sesion>.EndPoint = "https://localhost:7270/api/Sesiones";

            // Crear una nueva sesión
            var sesion = Crud<Sesion>.Create(new Sesion
            {
                Id = 0,
                HoraInicio = DateTime.Now,
                HoraFin = DateTime.Now.AddHours(2),
                Lugar = "Lugar " + lugar,
                EventoId = 1       // Asumiendo que existe un Evento con Id 1
            });

            // Actualizar sesión
            sesion.Lugar = "Lugar actualizado " + lugar;
            Crud<Sesion>.Update(sesion.Id, sesion);

            // Obtener todas las sesiones
            var sesiones = Crud<Sesion>.GetAll();

            foreach(var s in sesiones)
            {
                Console.WriteLine($"Sesión: ID: {s.Id}, Inicio: {s.HoraInicio}, Fin: {s.HoraFin}, Lugar: {s.Lugar}, EventoId: {s.EventoId}");
            }

            // Eliminar sesión
            Crud<Sesion>.Delete(sesion.Id);
        }

        private static void AgregarDatosATodas()
        {
            Console.WriteLine("=== AGREGANDO DATOS A TODAS LAS TABLAS ===");

            // 1. Crear Eventos (entidad independiente)
            Console.WriteLine("Agregando eventos...");
            var evento1 = CrearEvento("Conferencia Anual");
            var evento2 = CrearEvento("Taller de Programación");
            var evento3 = CrearEvento("Seminario de Bases de Datos");

            // 2. Crear Sesiones (depende de Evento)
            Console.WriteLine("Agregando sesiones...");
            var sesion1 = CrearSesion("Sala Principal", evento1.Id);
            var sesion2 = CrearSesion("Laboratorio A", evento2.Id);
            var sesion3 = CrearSesion("Auditorio", evento3.Id);

            // 3. Crear Ponentes (depende de Evento)
            Console.WriteLine("Agregando ponentes...");
            var ponente1 = CrearPonente("Juan", evento1.Id);
            var ponente2 = CrearPonente("Ana", evento2.Id);
            var ponente3 = CrearPonente("Carlos", evento3.Id);

            // 4. Crear Participantes (depende de Evento y Sesión)
            Console.WriteLine("Agregando participantes...");
            var participante1 = CrearParticipante("Pedro", evento1.Id, sesion1.Id);
            var participante2 = CrearParticipante("María", evento2.Id, sesion2.Id);
            var participante3 = CrearParticipante("Luis", evento3.Id, sesion3.Id);

            // 5. Crear Inscripciones (depende de Participante y Evento)
            Console.WriteLine("Agregando inscripciones...");
            var inscripcion1 = CrearInscripcion("Confirmada", participante1.Id, evento1.Id);
            var inscripcion2 = CrearInscripcion("Pendiente", participante2.Id, evento2.Id);
            var inscripcion3 = CrearInscripcion("Confirmada", participante3.Id, evento3.Id);

            // 6. Crear Pagos (depende de Inscripción)
            Console.WriteLine("Agregando pagos...");
            var pago1 = CrearPago("Tarjeta", inscripcion1.Id);
            var pago2 = CrearPago("Transferencia", inscripcion2.Id);
            var pago3 = CrearPago("Efectivo", inscripcion3.Id);

            // 7. Crear Certificados (depende de Participante y Evento)
            Console.WriteLine("Agregando certificados...");
            var certificado1 = CrearCertificado("Asistencia", participante1.Id, evento1.Id);
            var certificado2 = CrearCertificado("Participación", participante2.Id, evento2.Id);
            var certificado3 = CrearCertificado("Completado", participante3.Id, evento3.Id);

            Console.WriteLine("=== DATOS AGREGADOS EXITOSAMENTE ===");

        }

        // Métodos auxiliares para crear cada tipo de entidad sin eliminarla

        private static Evento CrearEvento(string nombre)
        {
            Crud<Evento>.EndPoint = "https://localhost:7270/api/Eventos";

            var evento = Crud<Evento>.Create(new Evento
            {
                Id = 0,
                Nombre = nombre,
                Fecha = DateTime.Now.AddDays(new Random().Next(1, 30)),
                Lugar = $"Lugar para {nombre}",
                Tipo = $"Tipo para {nombre}"
            });

            Console.WriteLine($"  Evento creado: ID={evento.Id}, Nombre={evento.Nombre}");
            return evento;
        }

        private static Sesion CrearSesion(string lugar, int eventoId)
        {
            Crud<Sesion>.EndPoint = "https://localhost:7270/api/Sesiones";

            var horaInicio = DateTime.Now.AddDays(1).AddHours(9); // 9:00 AM mañana

            var sesion = Crud<Sesion>.Create(new Sesion
            {
                Id = 0,
                HoraInicio = horaInicio,
                HoraFin = horaInicio.AddHours(2),
                Lugar = lugar,
                EventoId = eventoId
            });

            Console.WriteLine($"  Sesión creada: ID={sesion.Id}, Lugar={sesion.Lugar}, EventoId={sesion.EventoId}");
            return sesion;
        }

        private static Ponente CrearPonente(string nombre, int eventoId)
        {
            Crud<Ponente>.EndPoint = "https://localhost:7270/api/Ponentes";

            var ponente = Crud<Ponente>.Create(new Ponente
            {
                Id = 0,
                Nombre = nombre,
                Apellido = $"Apellido de {nombre}",
                EventoId = eventoId
            });

            Console.WriteLine($"  Ponente creado: ID={ponente.Id}, Nombre={ponente.Nombre} {ponente.Apellido}, EventoId={ponente.EventoId}");
            return ponente;
        }

        private static Participante CrearParticipante(string nombre, int eventoId, int sesionId)
        {
            Crud<Participante>.EndPoint = "https://localhost:7270/api/Participantes";

            var participante = Crud<Participante>.Create(new Participante
            {
                Id = 0,
                Nombre = nombre,
                Apellido = $"Apellido de {nombre}",
                Telefono = $"555-{new Random().Next(1000, 9999)}",
                EventoId = eventoId,
                SesionId = sesionId
            });

            Console.WriteLine($"  Participante creado: ID={participante.Id}, Nombre={participante.Nombre} {participante.Apellido}, EventoId={participante.EventoId}, SesionId={participante.SesionId}");
            return participante;
        }

        private static Inscripcion CrearInscripcion(string estado, int participanteId, int eventoId)
        {
            Crud<Inscripcion>.EndPoint = "https://localhost:7270/api/Inscripciones";

            var inscripcion = Crud<Inscripcion>.Create(new Inscripcion
            {
                Id = 0,
                Fecha = DateTime.Now,
                Estado = estado,
                ParticipanteId = participanteId,
                EventoId = eventoId
            });

            Console.WriteLine($"  Inscripción creada: ID={inscripcion.Id}, Estado={inscripcion.Estado}, ParticipanteId={inscripcion.ParticipanteId}, EventoId={inscripcion.EventoId}");
            return inscripcion;
        }

        private static Pago CrearPago(string medio, int inscripcionId)
        {
            Crud<Pago>.EndPoint = "https://localhost:7270/api/Pagos";

            var pago = Crud<Pago>.Create(new Pago
            {
                Id = 0,
                Fecha = DateTime.Now,
                Medio = medio,
                InscripcionId = inscripcionId
            });

            Console.WriteLine($"  Pago creado: ID={pago.Id}, Medio={pago.Medio}, InscripcionId={pago.InscripcionId}");
            return pago;
        }

        private static Certificado CrearCertificado(string nombre, int participanteId, int eventoId)
        {
            Crud<Certificado>.EndPoint = "https://localhost:7270/api/Certificados";

            var certificado = Crud<Certificado>.Create(new Certificado
            {
                Id = 0,
                Nombre = nombre,
                FechaEmision = DateTime.Now,
                ParticipanteId = participanteId,
                EventoId = eventoId
            });

            Console.WriteLine($"  Certificado creado: ID={certificado.Id}, Nombre={certificado.Nombre}, ParticipanteId={certificado.ParticipanteId}, EventoId={certificado.EventoId}");
            return certificado;
        }


        /*
        private static void MostrarResumenDatos()
        {
            Console.WriteLine("\n=== RESUMEN DE DATOS AGREGADOS ===");

            // Mostrar eventos
            Crud<Evento>.EndPoint = "https://localhost:7270/api/Eventos";
            var eventos = Crud<Evento>.GetAll();
            Console.WriteLine($"\nEventos ({eventos.Count}):");
            foreach(var e in eventos)
            {
                Console.WriteLine($"  ID={e.Id}, Nombre={e.Nombre}, Fecha={e.Fecha:dd/MM/yyyy}, Lugar={e.Lugar}, Tipo={e.Tipo}");
            }

            // Mostrar sesiones
            Crud<Sesion>.EndPoint = "https://localhost:7270/api/Sesiones";
            var sesiones = Crud<Sesion>.GetAll();
            Console.WriteLine($"\nSesiones ({sesiones.Count}):");
            foreach(var s in sesiones)
            {
                Console.WriteLine($"  ID={s.Id}, Inicio={s.HoraInicio:HH:mm}, Fin={s.HoraFin:HH:mm}, Lugar={s.Lugar}, EventoId={s.EventoId}");
            }

            // Mostrar ponentes
            Crud<Ponente>.EndPoint = "https://localhost:7270/api/Ponentes";
            var ponentes = Crud<Ponente>.GetAll();
            Console.WriteLine($"\nPonentes ({ponentes.Count}):");
            foreach(var p in ponentes)
            {
                Console.WriteLine($"  ID={p.Id}, Nombre={p.Nombre} {p.Apellido}, EventoId={p.EventoId}");
            }

            // Mostrar participantes
            Crud<Participante>.EndPoint = "https://localhost:7270/api/Participantes";
            var participantes = Crud<Participante>.GetAll();
            Console.WriteLine($"\nParticipantes ({participantes.Count}):");
            foreach(var p in participantes)
            {
                Console.WriteLine($"  ID={p.Id}, Nombre={p.Nombre} {p.Apellido}, Teléfono={p.Telefono}, EventoId={p.EventoId}, SesionId={p.SesionId}");
            }
        }


        */



    }
}