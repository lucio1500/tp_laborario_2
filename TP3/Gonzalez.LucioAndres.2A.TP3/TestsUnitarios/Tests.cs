using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using Excepciones;
using Clases_Instanciables;
using EntidadesAbstractas;

namespace TestsUnitarios
{
    [TestClass]
    public class Tests
    {
        /// <summary>
        /// Testea una Excepcion.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalido_Exception()
        {            
            Alumno a = new Alumno(1,"Lucio","Gonzalez","DniErroneo",Persona.ENacionalidad.Argentino,Universidad.EClases.Laboratorio);                
        }

        /// <summary>
        /// Testea una Excepcion.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void SinProfesor_Exception()
        {            
            Universidad u = new Universidad();

            Profesor profe = (u == Universidad.EClases.Programacion);                     
        }


        /// <summary>
        /// Testea que se haya instanciado un atributo de tipo coleccion de alguna clase.
        /// </summary>
        [TestMethod]
        public void JornadaAlumnoInstanciado()
        {
            Jornada j = new Jornada(Universidad.EClases.Programacion, new Profesor());

            Assert.IsNotNull(j.Alumnos);          
        }
    }

}
