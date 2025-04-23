using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeshiStoryLibrary
{
    public class Class1
    {
        public class Escenario
        {
            public string Descripcion { get; set; }
            public Dictionary<int, Decision> Decisiones { get; set; }

            public Escenario(string descripcion)
            {
                Descripcion = descripcion;
                Decisiones = new Dictionary<int, Decision>();
            }

            public void AgregarDecision(int clave, Decision decision)
            {
                if (Decisiones.ContainsKey(clave))
                {
                    throw new ArgumentException($"La decisión con la clave {clave} ya existe en el escenario.");
                }
                Decisiones[clave] = decision;
            }

            public Escenario ObtenerSiguienteEscenario(int eleccion)
            {
                if (Decisiones.ContainsKey(eleccion))
                {
                    return Decisiones[eleccion].EscenarioSiguiente;
                }
                Console.WriteLine($"Advertencia: La decisión con la clave {eleccion} no existe en el escenario actual.");
                return null;
            }
        }

        public class Decision
        {
            public string Texto { get; set; }
            public Escenario EscenarioSiguiente { get; set; }

            public Decision(string texto, Escenario escenarioSiguiente)
            {
                Texto = texto;
                EscenarioSiguiente = escenarioSiguiente;
            }
        }

        public class HistoriaVillano
        {
            public List<Escenario> Escenarios { get; private set; }

            public HistoriaVillano()
            {
                Escenarios = new List<Escenario>();
                InicializarEscenarios();
            }

            private void InicializarEscenarios()
            {
                // Crear todos los escenarios
                var inicio = CrearEscenario("Takeshi observa su dominio desde la cima de una colina, planeando su próximo movimiento.");
                var reunionGenerales = CrearEscenario("Takeshi se reúne con sus generales para discutir la estrategia.");
                var traicion = CrearEscenario("Uno de los generales sugiere traicionar a Takeshi.");
                var batalla = CrearEscenario("La batalla contra los aldeanos ha comenzado.");
                var victoria = CrearEscenario("Takeshi ha ganado la batalla y se siente invencible.");
                var caida = CrearEscenario("Takeshi se enfrenta a una revuelta en su propia aldea.");
                var conspiracion = CrearEscenario("Takeshi descubre que hay una conspiración en su contra.");
                var redencion = CrearEscenario("Takeshi se encuentra con un viejo amigo que le recuerda su pasado.");
                var traicionFinal = CrearEscenario("Un aliado cercano traiciona a Takeshi.");
                var muerte = CrearEscenario("Takeshi enfrenta su destino final.");

                // Crear todas las decisiones
                var decision1 = CrearDecision("Enviar a sus hombres a saquear la aldea", CrearEscenario("Los hombres de Takeshi se preparan para atacar la aldea."));
                var decision2 = CrearDecision("Reunir información sobre los aldeanos", CrearEscenario("Takeshi decide enviar espías para conocer mejor a sus enemigos."));
                var decision3 = CrearDecision("Atacar la aldea de inmediato", CrearEscenario("Los generales están de acuerdo en que deben atacar antes de que los aldeanos se fortalezcan."));
                var decision4 = CrearDecision("Esperar y observar", CrearEscenario("Takeshi decide que es mejor esperar y observar los movimientos de los aldeanos."));
                var decision5 = CrearDecision("Deshacerse del general traidor", CrearEscenario("Takeshi decide eliminar a la amenaza antes de que crezca."));
                var decision6 = CrearDecision("Escuchar al general y considerar su propuesta", CrearEscenario("Takeshi se siente intrigado por la idea de traición."));
                var decision7 = CrearDecision("Luchar con todas sus fuerzas", CrearEscenario("Takeshi lidera a sus hombres en la batalla, buscando aplastar a los aldeanos."));
                var decision8 = CrearDecision("Retirarse y reagruparse", CrearEscenario("Takeshi decide que es mejor retirarse y reagruparse para un ataque más fuerte."));
                var decision9 = CrearDecision("Expandir su dominio a otras aldeas", CrearEscenario("Takeshi planea su próximo ataque a una aldea cercana."));
                var decision10 = CrearDecision("Consolidar su poder en la aldea conquistada", CrearEscenario("Takeshi decide asegurarse de que la aldea conquistada no se rebela."));
                var decision11 = CrearDecision("Reprimir la revuelta con mano dura", CrearEscenario("Takeshi ordena a sus hombres que repriman la revuelta sin piedad."));
                var decision12 = CrearDecision("Buscar una solución pacífica", CrearEscenario("Takeshi considera que tal vez sea mejor negociar con los rebeldes."));
                var decision13 = CrearDecision("Investigar la conspiración", CrearEscenario("Takeshi decide investigar quiénes son los traidores en su corte."));
                var decision14 = CrearDecision("Ignorar la conspiración", CrearEscenario("Takeshi decide que no tiene tiempo para conspiraciones y se enfoca en la guerra."));
                var decision15 = CrearDecision("Reconsiderar sus acciones y buscar redención", CrearEscenario("Takeshi comienza a cuestionar su camino y busca una forma de redimirse."));
                var decision16 = CrearDecision("Desestimar el consejo de su amigo", CrearEscenario("Takeshi decide que su ambición es más importante que la amistad."));
                var decision17 = CrearDecision("Buscar venganza contra el traidor", CrearEscenario("Takeshi jura vengarse de su antiguo aliado."));
                var decision18 = CrearDecision("Perdonar al traidor", CrearEscenario("Takeshi decide que la venganza no es el camino correcto."));
                var decision19 = CrearDecision("Luchar hasta el final", CrearEscenario("Takeshi decide que no se rendirá sin luchar."));
                var decision20 = CrearDecision("Rendir su espada", CrearEscenario("Takeshi se da cuenta de que ha perdido y decide rendirse."));

                // Agregar decisiones a los escenarios
                AgregarDecisionesAEscenario(inicio, new[] { (1, decision1), (2, decision2) });
                AgregarDecisionesAEscenario(reunionGenerales, new[] { (1, decision3), (2, decision4) });
                AgregarDecisionesAEscenario(traicion, new[] { (1, decision5), (2, decision6) });
                AgregarDecisionesAEscenario(batalla, new[] { (1, decision7), (2, decision8) });
                AgregarDecisionesAEscenario(victoria, new[] { (1, decision9), (2, decision10) });
                AgregarDecisionesAEscenario(caida, new[] { (1, decision11), (2, decision12) });
                AgregarDecisionesAEscenario(conspiracion, new[] { (1, decision13), (2, decision14) });
                AgregarDecisionesAEscenario(redencion, new[] { (1, decision15), (2, decision16) });
                AgregarDecisionesAEscenario(traicionFinal, new[] { (1, decision17), (2, decision18) });
                AgregarDecisionesAEscenario(muerte, new[] { (1, decision19), (2, decision20) });

                // Agregar todos los escenarios a la lista
                Escenarios.AddRange(new[]
                {
                    inicio, reunionGenerales, traicion, batalla, victoria, caida, conspiracion, redencion, traicionFinal, muerte
                });
            }

            private Escenario CrearEscenario(string descripcion)
            {
                return new Escenario(descripcion);
            }

            private Decision CrearDecision(string texto, Escenario escenarioSiguiente)
            {
                return new Decision(texto, escenarioSiguiente);
            }

            private void AgregarDecisionesAEscenario(Escenario escenario, (int clave, Decision decision)[] decisiones)
            {
                foreach (var (clave, decision) in decisiones)
                {
                    escenario.AgregarDecision(clave, decision);
                }
            }
        }
    }
}
