using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Archivos;
using ClasesAbstractas;
using ClasesInstanciables;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAlumnoRepetidoExcepcion()
        {
            Universidad uni = new Universidad();

            Alumno a1 = new Alumno(1, "Arley", "Ducau", "41856359", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
            Alumno a2 = new Alumno(2, "Roberto", "Rodriguez", "41856359", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
            Alumno a3 = new Alumno(1, "Juan", "Carlos", "90342324", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD, Alumno.EEstadoCuenta.Becado);
            

            try
            {
                uni += a1;
                uni += a2;
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }


            try
            {
                uni += a1;
                uni += a3;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }
        
        [TestMethod]
        [ExpectedException (typeof(SinProfesorException))]
        public void TestSinProfesorException()
        {
            Universidad u = new Universidad();
            
            u += Universidad.EClases.Programacion;
            
        }

        [TestMethod]
        public void TestDni()
        {
            Alumno a1 = new Alumno(1, "Arley", "Ducau", "41.856.359", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Alumno a2 = new Alumno(2, "Roberto", "Rodriguez", "32412524", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            Profesor i1 = new Profesor(1, "Juan", "Perez", "91.434.685", Persona.ENacionalidad.Extranjero);
            Profesor i2 = new Profesor(2, "Marcos", "Aguinis", "98461385", Persona.ENacionalidad.Extranjero);

            Assert.IsTrue(41856359 == a1.Dni);
            Assert.IsTrue(32412524 == a2.Dni);
            Assert.IsTrue(91434685 == i1.Dni);
            Assert.IsTrue(98461385 == i2.Dni);
        }

        [TestMethod]
        public void TestUniversidadListas()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Alumnos);
            Assert.IsNotNull(uni.Instructores);
            Assert.IsNotNull(uni.Jornadas);

        }

    }
}
