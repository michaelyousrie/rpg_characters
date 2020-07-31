using System;
using System.Collections.Generic;
using System.Linq;
using App.Data;
using App.Models;

namespace App.Repos
{
    public class CharacterRepo : IRepo<Character>
    {
        private readonly MysqlContext _DB;

        public CharacterRepo(MysqlContext context)
        {
            _DB = context;
        }

        public bool NameExists(string name)
        {
            return _DB.Characters.FirstOrDefault(c => c.Name == name) != null;
        }

        public override Character Create(Character character)
        {
            _DB.Add(character);
            _DB.SaveChanges();

            return character;
        }

        public override void Delete(Character character)
        {
            _DB.Characters.Remove(character);
            SaveChanges();
        }

        public override void DeleteById(int id)
        {
            var character = _DB.Characters.FirstOrDefault(c => c.Id == id);

            if (character == null) {
                throw new Exception("No character exists with that id!");
            }

            Delete(character);
        }

        public override IEnumerable<Character> GetAll()
        {
            return _DB.Characters.ToList();
        }

        public override Character GetById(int id)
        {
            return _DB.Characters.FirstOrDefault(c => c.Id == id);
        }

        public override void Update(Character character)
        {
            _DB.Characters.Update(character);
            SaveChanges();
        }

        public override void SaveChanges()
        {
            _DB.SaveChanges();
        }
    }
}
