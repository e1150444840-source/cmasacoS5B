using cmasacoS5B.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmasacoS5B.Repositorio
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLite.SQLiteConnection _conn;
        public string Status { get; set; }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (_conn is not null)
                return;
            _conn = new (_dbPath);
            _conn.CreateTable<Persona>();
        }

        public void AddNewPerson(string name)
        {
            int result = 0 ;

            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es Requerido");

                Persona person = new() { Nombre=name };
                result = _conn.Insert(person);
                Status = string.Format("Dato ingresado");            
            }

            catch (Exception ex)
            {
                Status = string.Format("Error" + ex.Message);
                
            }
        }

        public List<Persona> GetAllPerson()
        {
            try
            {
                Init();
                return _conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                Status = string.Format("Error" + ex.Message);
            }
            return new List<Persona>();
        }

        public void DeletePerson(Persona persona)
        {
            try
            {
                Init(); 
                int result = _conn.Delete(persona);
                Status = string.Format("registros eliminados" + result);
            }
            catch (Exception ex)
            {
                Status = string.Format("Error al eliminar:" + ex.Message);
            }
        }

    }
}
