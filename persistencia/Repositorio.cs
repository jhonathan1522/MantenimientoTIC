using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace persistencia
{
    public class Repositorio: IRepositorio
    {
        private readonly ApplicationContext _applicationContext;

        public Repositorio(ApplicationContext applicationContext){
            _applicationContext = applicationContext;
        }

        public Repositorio(){}

        Persona IRepositorio.Add(Persona persona)
        {
            var new_persona = _applicationContext.personas.Add(persona);
            _applicationContext.SaveChanges();
            return new_persona.Entity;
        }

         void IRepositorio.Delete(int idPersona)
         {
            var personaEncontrada = _applicationContext.personas.FirstOrDefault(
                p => p.Id == idPersona
            );

            if(personaEncontrada == null)
            return;
            _applicationContext.Remove(personaEncontrada);
            _applicationContext.SaveChanges();
         }

         IEnumerable<Persona> IRepositorio.GetAll(){
            return _applicationContext.personas;
         }

         Persona IRepositorio.Get(int IdPersona){
            return _applicationContext.personas.FirstOrDefault(
                p => p.Id == IdPersona
            );             
         }

        Persona IRepositorio.Update(Persona persona){
            var personaEncontrada = _applicationContext.personas.FirstOrDefault(
                p => p.Id == persona.Id
            );

            if(personaEncontrada != null){
                personaEncontrada.Nombre = persona.Nombre;
                personaEncontrada.Edad = persona.Edad;
                personaEncontrada.Apellidos = persona.Apellidos;
            }
            _applicationContext.SaveChanges();
            return personaEncontrada;
        }  





    }
}